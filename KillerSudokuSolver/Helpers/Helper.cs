using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Helpers
{
    public class Helper
    {
        public static SortedSet<int> PossibleValues(KillerSudoku killerSudoku)
        {
            int count = killerSudoku.Board.board.Count;
            SortedSet<int> result = new SortedSet<int>();

            for(var i = 1; i < count; i++)
            {
                result.Add(i);
            }

            return result;
        }

        public static List<List<Field>> GetAllRowColKubes(KillerSudoku killerSudoku)
        {
            List<List<Field>> rowColKubes = new List<List<Field>>();
            Board board = killerSudoku.Board;
            board.board.ForEach(row => rowColKubes.Add(row));

            for (var i = 0; i < board.board.Count - 1; i++) { rowColKubes.Add(board.getColumn(i)); };

            int kubeCount = Convert.ToInt32(Math.Sqrt(board.board.Count));

            for (var i = 0; i < board.board.Count - 1; i++)
            {
                rowColKubes.Add(board.getKube(killerSudoku, new Tuple<int, int>(i / kubeCount, i % kubeCount)));
            };

            return rowColKubes;
        }

        public static List<Field> ConcatBoard(Board board)
        {
            List<Field> fields = new List<Field>();
            board.board.ForEach(row => fields = fields.Concat(row).ToList());
            return fields;
        }

        public static void HashBoard(Board board)
        {
            board.allFields().Select(x => x.Value)
                .Where(x => x != 0)
                .ToList()
                .ForEach(x => Console.Write(x));
        }

        public static bool StillValid(KillerSudoku killerSudoku)
        {
            int zeroPos = ConcatBoard(killerSudoku.Board)
                    .Where(x => x.PossibleValues.Count == 0)
                    .Where(x => x.Value == 0)
                    .Count();

            bool zeroPossibleValues = zeroPos == 0 || zeroPos == ConcatBoard(killerSudoku.Board).Count;

            bool doubleValues = GetAllRowColKubes(killerSudoku)
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

        public static List<Tuple<int, int>> ToTupleList(List<Field> fields)
        {
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            fields.ForEach(field => res.Add(field.Coordinates));
            return res;
        }

        public static int TotalRowValue(KillerSudoku killerSudoku)
        {
            return PossibleValues(killerSudoku)
                .Aggregate((a, b) => a + b);
        }
    }
}
