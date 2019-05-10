using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Strattagies
{
    public class CalculatePossibleValuesCages : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            killerSudoku.CombinedCages.ForEach(cage =>
            {
                int combinedTemporary = cage.CombinedValue;
                int emtpyTiles = cage.Fields
                    .Where(x => x.Value == 0)
                    .Count();

                cage.Fields
                    .Where(x => x.Value != 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        combinedTemporary -= field.Value;
                    });

                List<SortedSet<int>> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles);

                SortedSet<int> fieldPossibilities = new SortedSet<int>();
                cage.Fields.SelectMany(x => x.PossibleValues)
                    .ToList()
                    .ForEach(x => fieldPossibilities.Add(x));

                SortedSet<int> res = new SortedSet<int>();

                cagePosibilities.ForEach(pos =>
                {
                    if (pos.All(x => fieldPossibilities.Contains(x)))
                    {
                        pos.ToList()
                            .ForEach(y => res.Add(y));
                    }
                });

                cage.Fields
                    .Where(x => x.Value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        field.PossibleValues.RemoveWhere(x => !res.Contains(x));
                    });
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }
    }
}
