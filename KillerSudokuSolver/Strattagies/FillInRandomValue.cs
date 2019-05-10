using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Strattagies
{
    public class FillInRandomValue : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.Logger.Log("Couldn't get further, entering random value", true);
            killerSudoku.Board.Print();
            killerSudoku.randomCount++;

            Field field = killerSudoku.Board
                .allUncompletedFields()
                .OrderBy(x => x.PossibleValues.Count)
                .FirstOrDefault();

            field.PossibleValues
                .ToList()
                .ForEach(val =>
                {
                    if (!Validator.Completed(killerSudoku))
                    {
                        KillerSudoku possibility = killerSudoku.Clone();
                        Field randomField = possibility.GetField(field.Coordinates);
                        randomField.Value = val;
                        randomField.PossibleValues = new SortedSet<int>();
                        killerSudoku.Board.Logger.Log($"Filling in {val} to {field.Coordinates} as a random value", true);

                        KillerSudoku result = Solver.Solve(possibility);

                        if (Validator.Completed(result))
                        {
                            killerSudoku = result;
                        }
                    }
                });

            return new Tuple<KillerSudoku, bool>(killerSudoku, Validator.Completed(killerSudoku));
        }
    }
}
