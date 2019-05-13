using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class XWing : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            List<List<Field>> rows = killerSudoku.Board.board;
            List<List<Field>> columns = new List<List<Field>>();

            for (var i = 0; i < killerSudoku.Board.board.Count; i++) { columns.Add(killerSudoku.Board.getColumn(i)); };

            bool RowXWing = LookForXWing(rows, killerSudoku, true);
            bool ColXWing = LookForXWing(columns, killerSudoku, false);

            return new Tuple<KillerSudoku, bool>(killerSudoku, RowXWing || ColXWing);
        }

        public static bool LookForXWing(List<List<Field>> rows, KillerSudoku killerSudoku, bool lookingInRows)
        {
            List<Tuple<int, Tuple<Field, Field>>> halfXWings = new List<Tuple<int, Tuple<Field, Field>>>();
            bool result = false;

            rows.ForEach(row =>
            {
                Helper.PossibleValues(killerSudoku).ToList().ForEach(val =>
                {
                    List<Field> fieldswithvaluex = row.Where(field => field.PossibleValues.Contains(val)).ToList();
                    if(fieldswithvaluex.Count == 2)
                    {
                        halfXWings.Add(new Tuple<int, Tuple<Field, Field>>(val, new Tuple<Field, Field>(fieldswithvaluex[0], fieldswithvaluex[1])));
                    }
                });
            });

            halfXWings.ForEach(halfXWing =>
            {
                List<Tuple<int, Tuple<Field, Field>>> matchedXWings = new List<Tuple<int, Tuple<Field, Field>>>();
                if (lookingInRows)
                {
                    matchedXWings = halfXWings
                        .Where(x => x.Item1 == halfXWing.Item1 &&
                                x.Item2.Item1.Coordinates.Item1 == halfXWing.Item2.Item1.Coordinates.Item1 &&
                                x.Item2.Item2.Coordinates.Item1 == halfXWing.Item2.Item2.Coordinates.Item1)
                        .ToList();
                }
                else
                {
                    matchedXWings = halfXWings
                        .Where(x => x.Item1 == halfXWing.Item1 &&
                                x.Item2.Item1.Coordinates.Item2 == halfXWing.Item2.Item1.Coordinates.Item2 &&
                                x.Item2.Item2.Coordinates.Item2 == halfXWing.Item2.Item2.Coordinates.Item2)
                        .ToList();
                }

                if (matchedXWings.Count == 2)
                {
                    matchedXWings.ForEach(matchedxwing =>
                    {
                        killerSudoku.Board.GetRowColKubesOfField(killerSudoku, matchedxwing.Item2.Item1)
                            .Where(x => x.Contains(matchedxwing.Item2.Item2))
                            .ToList()
                            .ForEach(row =>
                            {
                                if(row.Where(x => x != matchedxwing.Item2.Item1 && x != matchedxwing.Item2.Item2)
                                    .ToList()
                                    .Any(field => field.PossibleValues.Remove(matchedxwing.Item1)))
                                    result = true;
                            });
                    });
                }
            });

            return result;
        }
    }
}
