using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Strattagies
{
    public class CalculatePossibleValuesCages : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.allFields()
                .ForEach(field => field.PossibleCageCombinations = new List<SortedSet<int>>());

            killerSudoku.CombinedCages.ForEach(cage =>
            {
                Cage completedCage = cage.CompletedCage();
                int combinedTemporary = completedCage.CombinedValue;
                int emtpyTiles = completedCage.Fields.Count;

                SortedSet<int> fieldPossibilities = new SortedSet<int>();
                cage.Fields.SelectMany(x => x.PossibleValues)
                    .ToList()
                    .ForEach(x => fieldPossibilities.Add(x));

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
                          });
                });

                List<SortedSet<int>> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles, fieldPossibilities, killerSudoku);
                cagePosibilities = cagePosibilities
                    .Where(pos => cageRequiredValues.All(x => pos.Contains(x)))
                    .ToList();
                SortedSet<int> res = new SortedSet<int>();
                cagePosibilities.ForEach(x => x.ToList().ForEach(y => res.Add(y)));

                cage.Fields
                    .Where(x => x.Value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        SortedSet<int> validValues = ValidValueCombiner.KeepJoinedPossibilities(field.PossibleValues, res);
                        field.PossibleValues = validValues;
                    });
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }
    }
}
