using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Helpers
{
    public class ValidValueCombiner
    {
        public static SortedSet<int> ValidValues(KillerSudoku killersudoku, List<Field> list, SortedSet<int> baseValues = null)
        {
            if (baseValues == null) baseValues = Helper.PossibleValues(killersudoku);

            list.ForEach(item => baseValues.Remove(item.Value));
            return baseValues;
        }

        public static SortedSet<int> KeepJoinedPossibilities(SortedSet<int> in1, SortedSet<int> in2)
        {
            SortedSet<int> result = new SortedSet<int>();
            in1.ToList().ForEach(x =>
            {
                if (in2.Contains(x))
                {
                    result.Add(x);
                }
            });
            return result;
        }
    }
}
