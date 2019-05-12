using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class FillInRandomValue : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.Logger.Log("Couldn't get further, entering random value", true);
            killerSudoku.Board.Print();
            killerSudoku.randomCount++;
            bool res = false;

            Field field = killerSudoku.Board
                .allUncompletedFields()
                .OrderBy(x => x.PossibleValues.Count)
                .FirstOrDefault();

            List<List<Field>> rowColKube = Helper.GetAllRowColKubes(killerSudoku)
                .Where(x => x.Contains(field))
                .ToList();

            List<int> posval = rowColKube.SelectMany(x => x.SelectMany(y => y.PossibleValues))
                .Where(x => field.PossibleValues.Contains(x))
                .GroupBy(x => x)
                .Select(x => new Tuple<int, int>(x.Key, x.Count()))
                .OrderBy(x => x.Item2)
                .Select(x => x.Item1)
                .ToList();

            posval
                .ForEach(val =>
                {
                    if (Validator.GetStatus(killerSudoku) == Status.Valid)
                    {
                        KillerSudoku possibility = killerSudoku.Clone();
                        Field randomField = possibility.GetField(field.Coordinates);
                        randomField.Value = val;
                        randomField.PossibleValues = new SortedSet<int>();
                        killerSudoku.Board.Logger.Log($"Filling in {val} to {field.Coordinates} as a random value", true);

                        KillerSudoku result = Solver.Solve(possibility);

                        if (Validator.GetStatus(result) == Status.Completed)
                        {
                            killerSudoku = result;
                            res = true;
                        }
                    }
                });

            return new Tuple<KillerSudoku, bool>(killerSudoku, res);
        }
    }
}
