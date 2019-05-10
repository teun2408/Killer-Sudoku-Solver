using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;

namespace KillerSudokuSolver.Strattagies
{
    public class PointingPairs : IStrattagy
    {
        public Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku)
        {
            if(Run(killerSudoku))
            {
                Execute(killerSudoku);
                return new Tuple<KillerSudoku, bool>(killerSudoku, true);
            }

            return new Tuple<KillerSudoku, bool>(killerSudoku, false);
        }

        public bool Run(KillerSudoku killerSudoku)
        {
            bool removedPossibility = false;
            Board board = killerSudoku.Board;

            List<List<Field>> rowColKubes = Helper.GetAllRowColKubes(killerSudoku);
            rowColKubes.ForEach(rowColKube =>
            {
                rowColKube.ForEach(field =>
                {
                    List<Field> samePosibilities = rowColKube
                        .Where(x => x.PossibleValues.SetEquals(field.PossibleValues))
                        .ToList();

                    if (samePosibilities.Count == field.PossibleValues.Count())
                    {
                        rowColKube.ForEach(field2 =>
                        {
                            if (!samePosibilities.Contains(field2))
                            {
                                samePosibilities
                                    .First().PossibleValues
                                    .ToList()
                                    .ForEach(num =>
                                    {
                                        if (field2.PossibleValues.Contains(num))
                                        {
                                            field2.PossibleValues.Remove(num);
                                            removedPossibility = true;
                                        }
                                    });
                            }
                        });
                    }
                });
            });
            return removedPossibility;
        }
    }
}
