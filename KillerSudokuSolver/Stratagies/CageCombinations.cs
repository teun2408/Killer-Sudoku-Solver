using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class CageCombinations: IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            bool result = false;
            killerSudoku.CombinedCages.ForEach(cage =>
            {
                SortedSet<int> res = new SortedSet<int>();
                cage.CagePossibilities.ForEach(x => x.ToList().ForEach(y => res.Add(y)));
                cage.CagePossibilities = RemoveInvalidPossibilities(cage.CagePossibilities, cage);

                cage.Fields
                    .Where(x => x.Value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        SortedSet<int> validValues = ValidValueCombiner.KeepJoinedPossibilities(field.PossibleValues, res);
                        if (validValues.Count != field.PossibleValues.Count)
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
