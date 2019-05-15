using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class CalculatePossibleValuesCages : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            bool result = false;
            killerSudoku.Cages.ForEach(cage => cage.CagePossibilities = new List<SortedSet<int>>());

            killerSudoku.CombinedCages.ForEach(cage =>
            {
                Cage completedCage = cage.CompletedCage();
                int combinedTemporary = completedCage.CombinedValue;
                int emtpyTiles = completedCage.Fields.Count;

                SortedSet<int> fieldPossibilities = new SortedSet<int>();
                cage.Fields.SelectMany(x => x.PossibleValues)
                    .ToList()
                    .ForEach(x => fieldPossibilities.Add(x));

                List<int> valInCages = cage.Fields.Select(field => field.Value)
                                        .Where(val => val != 0)
                                        .ToList();


                List<SortedSet<int>> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles, fieldPossibilities, killerSudoku);


                //Remove possibilities with a value already in the cage
                cagePosibilities = cagePosibilities
                            .Where(possibility => possibility
                                     .ToList()
                                     .Any(val => !valInCages.Contains(val))
                                  )
                            .ToList();

                SortedSet<int> res = new SortedSet<int>();
                cagePosibilities.ForEach(x => x.ToList().ForEach(y => res.Add(y)));
                cage.CagePossibilities = cagePosibilities;

                cage.Fields
                    .Where(x => x.Value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        SortedSet<int> validValues = ValidValueCombiner.KeepJoinedPossibilities(field.PossibleValues, res);
                        if(validValues.Count != field.PossibleValues.Count)
                        {
                            result = true;
                        }
                        field.PossibleValues = validValues;
                    });
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, result);
        }

        public List<SortedSet<int>> RemoveInvalidPossibilities(List<SortedSet<int>> possibilities, Cage cage)
        {
            //http://www.sudokuwiki.org/Killer_Cage_Combination_Example
            return possibilities.Where(possibility =>
            {
                List<Tuple<List<Field>, int>> valluesWithPossibleFields = possibility
                    .ToList()
                    .Select(val =>
                    {
                        List<Field> fieldsWithPossibility = cage.Fields.Where(field => field.PossibleValues.Contains(val)).ToList();
                        return new Tuple<List<Field>, int>(fieldsWithPossibility, val);
                    })
                    .OrderBy(tuple => tuple.Item1.Count)
                    .ToList();

                valluesWithPossibleFields
                    .ForEach(pos =>
                    {
                        if (pos.Item1.Count == 1)
                        {
                            valluesWithPossibleFields.ForEach(item =>
                            {
                                if (item != pos)
                                {
                                    item.Item1.Remove(pos.Item1.FirstOrDefault());
                                }
                            });
                        }
                    });
                return valluesWithPossibleFields.All(pos => pos.Item1.Count > 0);
            })
            .ToList();
        }
    }
}
