using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Stratagies
{
    public class BoxLineReduction : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            if (RunStrattagy(killerSudoku))
            {
                Execute(killerSudoku);
                return (new Tuple<KillerSudoku, bool>(killerSudoku, true));
            }

            return (new Tuple<KillerSudoku, bool>(killerSudoku, false));
        }

        public bool RunStrattagy(KillerSudoku killerSudoku)
        {
            bool result = false;
            Helper.GetAllRowColKubes(killerSudoku)
                .ForEach(row =>
                {
                    row.SelectMany(x => x.PossibleValues)
                        .ToList()
                        .GroupBy(x => x)
                        .Where(x => x.Count() == 2)
                        .Select(x => x.Key)
                        .ToList()
                        .ForEach(num =>
                        {
                            List<Field> fields = row.Where(x => x.PossibleValues.Contains(num)).ToList();
                            killerSudoku.Board.GetRowColKubesOfField(killerSudoku, fields.FirstOrDefault())
                                .Where(x => x.Contains(fields[0]) && x.Contains(fields[1]))
                                .ToList()
                                .ForEach(col =>
                                {
                                    col.Where(x => x != fields[0] && x != fields[1])
                                        .ToList()
                                        .ForEach(field =>
                                        {
                                            if (field.PossibleValues.Contains(num))
                                            {
                                                result = true;
                                            }
                                            field.PossibleValues.Remove(num);
                                        });
                                });

                            killerSudoku.CombinedCages
                                .Where(x => x.Fields.Contains(fields[0]) && x.Fields.Contains(fields[1]))
                                .ToList()
                                .ForEach(cage =>
                                {
                                    cage.Fields
                                        .Where(x => x != fields[0] && x != fields[1])
                                        .ToList()
                                        .ForEach(field =>
                                        {
                                            if (field.PossibleValues.Contains(num))
                                            {
                                                field.PossibleValues.Remove(num);
                                                result = true;
                                            }
                                        });
                                });
                        });
                });
            return result;
        }
    }
}
