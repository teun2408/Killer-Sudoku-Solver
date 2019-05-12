using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;
using KillerSudokuSolver.Helpers;

namespace KillerSudokuSolver.Stratagies
{
    public class CalculatePossibleValues : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            Board board = killerSudoku.Board;
            board.allFields().ForEach(col =>
            {
                if (col.Value == 0)
                {
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku, board.getColumn(col.Coordinates.Item1), col.PossibleValues);
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku, board.getRow(col.Coordinates.Item2), col.PossibleValues);
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku,
                        board.getKube(killerSudoku, col.Kube(board.board.Count)),
                        col.PossibleValues);
                }
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }
    }
}
