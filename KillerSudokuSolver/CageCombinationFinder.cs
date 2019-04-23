using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver
{
    public class CageCombinationFinder
    {
        public static SortedSet<int> CagePossibilities(int cageValue, int tiles)
        {
            List<SortedSet<int>> listResult = CalculatePosibilitiesNotAdd(cageValue, new SortedSet<int>(), 0)
                .Where(x => x.Count == tiles)
                .ToList();

            SortedSet<int> result = new SortedSet<int>();
            listResult.ForEach(x => x.ToList().ForEach(y => result.Add(y)));

            return result;
        }

        public static List<SortedSet<int>> CalculatePosibilitiesAdd(int remainingvalue, SortedSet<int> currentset, int nextValue)
        {
            SortedSet<int> newPosibility = new SortedSet<int>();
            currentset.ToList().ForEach(x => newPosibility.Add(x));
            remainingvalue -= nextValue;
            newPosibility.Add(nextValue);
            if(remainingvalue == 0)
            {
                return new List<SortedSet<int>>() { newPosibility };
            }
            if(remainingvalue < 0)
            {
                return new List<SortedSet<int>>();
            }
            if(nextValue >= 9)
            {
                return new List<SortedSet<int>>();
            }
            else
            {
                List<SortedSet<int>> res = CalculatePosibilitiesAdd(remainingvalue, newPosibility, nextValue + 1);
                List<SortedSet<int>> res2 = CalculatePosibilitiesNotAdd(remainingvalue, newPosibility, nextValue + 1);
                return res.Concat(res2).ToList();
            }
        }

        public static List<SortedSet<int>> CalculatePosibilitiesNotAdd(int remainingvalue, SortedSet<int> currentset, int nextValue)
        {
            if(nextValue >= 9)
            {
                return new List<SortedSet<int>>();
            }

            List<SortedSet<int>> res = CalculatePosibilitiesAdd(remainingvalue, currentset, nextValue + 1);
            List<SortedSet<int>> res2 = CalculatePosibilitiesNotAdd(remainingvalue, currentset, nextValue + 1);
            return res.Concat(res2).ToList();
        }
    } 
}
