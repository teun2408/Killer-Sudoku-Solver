using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class FillInSinglePossibilityOfRow : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            bool res = false;
            Board board = killerSudoku.Board;

            Helper.GetAllRowColKubes(killerSudoku)
                .ForEach(row =>
                {
                    row.SelectMany(x => x.PossibleValues.ToList())
                        .GroupBy(x => x)
                        .Where(group => group.Count() == 1)
                        .Select(group => group.Key)
                        .ToList()
                        .ForEach(val =>
                        {
                            Field field = row.Where(x => x.PossibleValues.Contains(val))
                                .FirstOrDefault();

                            if (field.Value == 0)
                            {
                                field.Value = val;
                                board.Logger.Log($"Filled in {field.Coordinates} with {field.Value} because it's the only field in the {Helper.GetRowType(row)} that can have this value", true);
                                res = true;
                            }
                        });
                });
            return new Tuple<KillerSudoku, bool>(killerSudoku, res);
        }
    }
}
