using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Strattagies
{
    public class FindTemporaryCages : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            killerSudoku.TempooraryCages = new List<Cage>();

            List<List<Field>> rowColKubes = Helper.GetAllRowColKubes(killerSudoku);
            rowColKubes.ForEach(rowColKube =>
            {
                int totalValue = Helper.TotalRowValue(killerSudoku);
                List<Field> temporaryCageList = rowColKube.Select(x => x).ToList();

                rowColKube
                    .Select(x => x.Cage)
                    .Distinct()
                    .Where(x => x != null)
                    .ToList()
                    .ForEach(cage =>
                    {
                        if (cage.CompletedCage().Fields.All(x => rowColKube.Contains(x)))
                        {
                            cage.Fields
                                .Where(x => rowColKube.Contains(x))
                                .ToList()
                                .ForEach(field => temporaryCageList.Remove(field));

                            cage.Fields
                                .Where(x => !rowColKube.Contains(x))
                                .ToList()
                                .ForEach(x => totalValue += x.Value);

                            totalValue -= cage.CombinedValue;
                        }
                    });

                if (totalValue != Helper.TotalRowValue(killerSudoku) && totalValue >= 0)
                {
                    Cage temporaryCage = new Cage(Helper.ToTupleList(temporaryCageList), totalValue);
                    temporaryCage.Coordinates.ForEach(cor => temporaryCage.Fields.Add(killerSudoku.GetField(cor)));
                    temporaryCage.Fields.ForEach(field => field.TemporaryCages.Add(temporaryCage));
                    killerSudoku.TempooraryCages.Add(temporaryCage);
                }
            });

            return new Tuple<KillerSudoku, bool>(killerSudoku, true);
        }
    }
}
