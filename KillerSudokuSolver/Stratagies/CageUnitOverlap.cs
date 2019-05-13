using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class CageUnitOverlap : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            bool result = false;

            killerSudoku.CombinedCages.ForEach(cage =>
            {
                SortedSet<int> cageRequiredValues = new SortedSet<int>();

                cage.Fields.ForEach(field =>
                {
                    Helper.GetAllRowColKubes(killerSudoku)
                          .Where(x => x.Contains(field))
                          .ToList()
                          .ForEach(rowcolkube =>
                          {
                              List<Field> temprowColKube = new List<Field>();
                              rowcolkube.ForEach(field => temprowColKube.Add(field));

                              List<int> values = Helper.PossibleValues(killerSudoku)
                                  .Where(x => !temprowColKube.Any(y => y.Value == x))
                                  .ToList();
                              cage.Fields.ForEach(field => temprowColKube.Remove(field));

                              List<int> allpos = temprowColKube.SelectMany(field => field.PossibleValues)
                                                              .ToList();

                              values
                                  .Where(val => !allpos.Contains(val))
                                  .ToList()
                                  .ForEach(x => cageRequiredValues.Add(x));

                              //temprowColKube.ForEach(field => values.ForEach(val => field.PossibleValues.Remove(val)));
                          });
                });

                if(cageRequiredValues.Count > 0)
                {
                    Console.Write("");
                }

                cage.CagePossibilities = cage.CagePossibilities
                    .Where(pos => cageRequiredValues.All(x => pos.Contains(x)))
                    .ToList();

                SortedSet<int> posibilities = new SortedSet<int>();
                cage.CagePossibilities.ForEach(x => x.ToList().ForEach(y => posibilities.Add(y)));

                cage.Fields
                    .Where(x => x.Value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        SortedSet<int> validValues = ValidValueCombiner.KeepJoinedPossibilities(field.PossibleValues, posibilities);
                        if (validValues.Count != field.PossibleValues.Count)
                        {
                            result = true;
                        }
                        field.PossibleValues = validValues;
                    });
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, result);
        }
    }
}
