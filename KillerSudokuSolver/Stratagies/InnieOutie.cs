using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Stratagies
{
    public class InnieOutie : IStratagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            int cageCount = killerSudoku.InnieOutieCages.Count;
            killerSudoku.InnieOutieCages = new List<Cage>();

            List<List<Field>> rows = killerSudoku.Board.board;
            List<List<Field>> columns = Helper.GetAllColumns(killerSudoku);
            List<List<Field>> kubes = Helper.GetAllKubes(killerSudoku);

            FindDoubleInnieOutie(killerSudoku, rows);
            FindDoubleInnieOutie(killerSudoku, columns);
            FindDoubleInnieOutie(killerSudoku, kubes);

            if (killerSudoku.InnieOutieCages.Count != cageCount)
            {
                return new Tuple<KillerSudoku, bool>(killerSudoku, true);
            }

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }

        public void FindDoubleInnieOutie(KillerSudoku killerSudoku, List<List<Field>> rows)
        {
            //The ammount of columns to look for innie and outies
            //http://www.sudokuwiki.org/Innies_And_Outies
            List<int> InieOutieMaxSize = new List<int>()
            {
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9
            };

            InieOutieMaxSize.ForEach(size =>
            {
                for (int i = 0; i < rows.Count - size + 1; i++)
                {
                    List<Field> combinedRows = new List<Field>();

                    for(int y = 0; y < size; y++)
                    {
                        combinedRows = combinedRows.Concat(rows[i + y]).ToList();
                    }

                    int totalValue = Helper.TotalRowValue(killerSudoku) * size;
                    List<Field> temporaryCageList = combinedRows.Select(x => x).ToList();

                    combinedRows
                        .Select(x => x.Cage)
                        .Distinct()
                        .Where(x => x != null)
                        .Where(cage => cage.CompletedCage().Fields.All(field => combinedRows.Contains(field)))
                        .SelectMany(cage =>
                        {
                            totalValue -= cage.CombinedValue;
                            return cage.Fields;
                        })
                        .ToList()
                        .ForEach(field =>
                        {
                            if(!combinedRows.Contains(field))
                            {
                                totalValue += field.Value;
                            }
                            temporaryCageList.Remove(field);
                        });

                    if (totalValue < Helper.TotalRowValue(killerSudoku) * size && totalValue >= 0)
                    {
                        Cage temporaryCage = new Cage(Helper.ToTupleList(temporaryCageList), totalValue);
                        temporaryCage.Coordinates.ForEach(cor => temporaryCage.Fields.Add(killerSudoku.GetField(cor)));
                        temporaryCage.Fields.ForEach(field => field.InnieOutieCages.Add(temporaryCage));
                        if (temporaryCage.Fields.All(field => field.Coordinates.Item1 == temporaryCage.Fields.First().Coordinates.Item1) || temporaryCage.Fields.All(field => field.Coordinates.Item2 == temporaryCage.Fields.First().Coordinates.Item2))
                        {
                            killerSudoku.InnieOutieCages.Add(temporaryCage);
                        }
                    }
                }
            });
        }
    }
}
