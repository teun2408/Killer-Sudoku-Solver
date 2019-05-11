using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Helpers
{
    public class Validator
    {
        public static Status GetStatus(KillerSudoku killerSudoku)
        {
            if (!StillValid(killerSudoku)) return Status.Invalid;
            if (Completed(killerSudoku)) return Status.Completed;
            return Status.Valid;
        }

        private static bool Completed(KillerSudoku killerSudoku)
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

        private static bool StillValid(KillerSudoku killerSudoku)
        {
            List<Field> zeroPos = killerSudoku.Board.allFields()
                    .Where(x => x.PossibleValues.Count == 0)
                    .Where(x => x.Value == 0)
                    .ToList();

            int fieldwithzerovalues = killerSudoku.Board.allFields().Where(x => x.Value == 0).Count();
            bool zeroPossibleValues = zeroPos.Count() == 0 || zeroPos.Count() == fieldwithzerovalues;

            bool doubleValues = Helper.GetAllRowColKubes(killerSudoku)
                .Where(box =>
                {
                    int res = box.Where(x => x.Value != 0)
                        .GroupBy(x => x.Value)
                        .Where(x => x.Count() > 1)
                        .Count();
                    return res != 0;
                })
                .Count() == 0;

            bool cages = killerSudoku.Cages.Where(cage => cage.CombinedValue < cage.Fields
                                .Select(x => x.Value)
                                .Aggregate((a, b) => a + b))
                                .ToList()
                                .Count() == 0;

            return zeroPossibleValues && doubleValues && cages;
        }
    }
}
