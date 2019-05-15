using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class HiddenPairs : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            bool result = false;
            Helper.GetAllRowColKubes(killerSudoku)
                .ForEach(rowcolkube =>
                {
                    List<Tuple<int, Tuple<Field, Field>>> halfHiddenPairs = new List<Tuple<int, Tuple<Field, Field>>>();

                    Helper.PossibleValues(killerSudoku)
                    .Where(val => rowcolkube.Any(field => field.Value == val) == false)
                    .Where(val => killerSudoku.Board.board.Count <= 9)
                    .ToList()
                    .ForEach(val =>
                    {
                        List<Field> fieldswithvaluex = rowcolkube.Where(field => field.PossibleValues.Contains(val)).ToList();
                        if (fieldswithvaluex.Count == 2 && fieldswithvaluex.Any(field => field.PossibleValues.Count > 2))
                        {
                            halfHiddenPairs.Add(new Tuple<int, Tuple<Field, Field>>(val, new Tuple<Field, Field>(fieldswithvaluex[0], fieldswithvaluex[1])));
                        }
                    });

                    halfHiddenPairs.ForEach(halfHiddenPair =>
                    {
                        Tuple<int, Tuple<Field, Field>> halfHidenPairCombo = halfHiddenPairs.Where(x => x != halfHiddenPair)
                                        .Where(x => x.Item2.Equals(halfHiddenPair.Item2))
                                        .FirstOrDefault();

                        if(halfHidenPairCombo != null)
                        {
                            SortedSet<int> hiddenpaircomboval = new SortedSet<int>()
                            {
                                halfHiddenPair.Item1,
                                halfHidenPairCombo.Item1
                            };
                            rowcolkube
                                .Where(x => x.PossibleValues.Contains(halfHidenPairCombo.Item1))
                                .ToList()
                                .ForEach(field =>
                                {
                                    field.PossibleValues.ToList().ForEach(val =>
                                    {
                                        if (!hiddenpaircomboval.Contains(val))
                                        {
                                            field.PossibleValues.Remove(val);
                                            result = true;
                                        }
                                    });
                                });
                        }
                    });
                });
            return new Tuple<KillerSudoku, bool>(killerSudoku, result);
        }
    }
}
