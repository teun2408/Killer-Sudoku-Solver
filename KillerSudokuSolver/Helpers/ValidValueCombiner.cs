using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
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
    }
}
