using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class FillInSinglePossibleValues : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            Board board = killerSudoku.Board;
            bool res = false;
            board.allFields()
                .Where(x => x.PossibleValues.Count == 1)
                .Where(x => x.Value == 0)
                .ToList()
                .ForEach(field =>
                {
                    field.Value = field.PossibleValues.ToList().FirstOrDefault();

                    board.Logger.Log($"Filled in {field.Coordinates} with {field.Value} because it's the only value it can have", true);
                    res = true;
                });
            return new Tuple<KillerSudoku, bool>(killerSudoku, res);
        }
    }
}
