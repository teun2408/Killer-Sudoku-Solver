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
            killerSudoku.CombinedCages.ForEach(cage =>
            {
                Cage completedCage = cage.CompletedCage();
                int combinedTemporary = completedCage.CombinedValue;
                int emtpyTiles = completedCage.Fields.Count;

                SortedSet<int> fieldPossibilities = new SortedSet<int>();
                cage.Fields.SelectMany(x => x.PossibleValues)
                    .ToList()
                    .ForEach(x => fieldPossibilities.Add(x));

                List<SortedSet<int>> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles, fieldPossibilities);
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
