using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;
using KillerSudokuSolver.Helpers;

namespace KillerSudokuSolver.Strattagies
{
    public class CalculatePossibleValues : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            Board board = killerSudoku.Board;
            board.board.ForEach(row => row.ForEach(col =>
            {
                if (col.Value == 0)
                {
                    //Add col.PossibleValues
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku, board.getColumn(col.Coordinates.Item1));
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku, board.getRow(col.Coordinates.Item2), col.PossibleValues);
                    col.PossibleValues = ValidValueCombiner.ValidValues(killerSudoku,
                        board.getKube(killerSudoku, col.Kube(board.allFields().Count)),
                        col.PossibleValues);
                }
            }));

            return new Tuple<KillerSudoku, bool>(killerSudoku, true);
        }
    }
}
