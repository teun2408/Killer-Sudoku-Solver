using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class CageSplitting : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            int newCagesCount = killerSudoku.SplittedCages.Count;
            List<Cage> newTempCages = new List<Cage>();
            killerSudoku.CombinedCages.ForEach(tempCage =>
            {
                Cage containingCage = killerSudoku.CombinedCages
                    .Where(cage => cage != tempCage)
                    .Where(cage =>
                    {
                        return tempCage.Fields.All(tempCage => cage.Fields.Contains(tempCage));
                    })
                    .FirstOrDefault();

                if(containingCage != null)
                {
                    int restValue = containingCage.CombinedValue - tempCage.CombinedValue;
                    List<Field> restFields = containingCage.Fields
                                                    .Where(field => !tempCage.Fields.Contains(field))
                                                    .ToList();
                    Cage newTempCage = new Cage(Helper.ToTupleList(restFields), restValue);
                    newTempCages.Add(newTempCage);
                }
            });

            killerSudoku.SplittedCages = new List<Cage>(); 
            newTempCages.ForEach(tempCage => killerSudoku.SplittedCages.Add(tempCage));
            if(newTempCages.Count != killerSudoku.SplittedCages.Count)
            {
                return new Tuple<KillerSudoku, bool>(killerSudoku, true);
            }

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }
    }
}
