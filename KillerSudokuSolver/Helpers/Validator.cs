using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Helpers
{
    public class Validator
    {
        public static bool Completed(KillerSudoku killerSudoku)
        {
            for (var i = 0; i < killerSudoku.Board.board.Count - 1; i++)
            {
                if (!Helper.PossibleValues(killerSudoku).All(num => killerSudoku.Board.getRow(i).Select(field => field.Value).Contains(num))) return false;
                if (!Helper.PossibleValues(killerSudoku).All(num => killerSudoku.Board.getColumn(i).Select(field => field.Value).Contains(num))) return false;

                int kubeCount = Convert.ToInt32(Math.Sqrt(killerSudoku.Board.board.Count));
                if (!Helper.PossibleValues(killerSudoku).All(num => killerSudoku.Board.getKube(killerSudoku, new Tuple<int, int>(i / kubeCount, i % kubeCount)).Select(field => field.Value).Contains(num))) return false;
            }

            for(var i = 0; i < killerSudoku.Cages.Count; i++)
            {
                Cage cage = killerSudoku.Cages[i];
                if (cage.Fields.Select(x => x.Value)
                    .Aggregate((a, b) => a + b) != cage.CombinedValue)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
