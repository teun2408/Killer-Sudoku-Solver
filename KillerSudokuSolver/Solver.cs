using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver
{
    public class Solver
    {
        public static Board Solve(KillerSudoku killerSudoku)
        {
            Console.WriteLine("---------------New run------------------");
            CalculatePossibleValues(killerSudoku.board);
            CalculatePossibleValuesCages(killerSudoku);
            removeSamePosibilities(killerSudoku.board);
            bool singlepos = findSinglePossibility(killerSudoku.board);
            if(FillInSinglePossibleValues(killerSudoku.board) || singlepos)
            {
                if(completed(killerSudoku.board))
                {
                    Console.WriteLine("Completed the sudoku");
                    killerSudoku.Print();
                }
                else
                {
                    return Solve(killerSudoku);
                }
            }
            else
            {
                if(completed(killerSudoku.board))
                {
                    Console.WriteLine("Completed the sudoku");
                    killerSudoku.Print();
                }
                else
                {
                    killerSudoku.board.Print();

                    Console.WriteLine("Failed to complete the sudoku");
                    Console.WriteLine($"Filled in {killerSudoku.completionRate} fields");
                }
            }
            return killerSudoku.board;
        }

        public static bool FillInSinglePossibleValues(Board board)
        {
            bool res = false;
            board.board.ForEach(row => row.ForEach(col =>
            {
                if(col.possibleValues.Count == 1)
                {
                    if(col.value == 0)
                    { 
                        col.value = col.possibleValues.First();
                        col.possibleValues = new SortedSet<int>();
                        Console.WriteLine($"Filled in {col.coordinates} with {col.value} because it's the only possible value");
                        res = true;
                    }
                }
            }));
            return res;
        }

        public static void CalculatePossibleValues(Board board)
        {
            board.board.ForEach(row => row.ForEach(col =>
            {
                if(col.value == 0)
                {
                    col.possibleValues = validValues(board.getColumn(col.coordinates.Item1));
                    col.possibleValues = validValues(board.getRow(col.coordinates.Item2), col.possibleValues);
                    col.possibleValues = validValues(board.getKube(col.kube), col.possibleValues);
                    Console.Write("");
                }
                else
                {
                    col.possibleValues = new SortedSet<int>();
                }
            }));
        }

        public static void CalculatePossibleValuesCages(KillerSudoku killerSudoku)
        {
            killerSudoku.cages.ForEach(cage =>
            {
                int combinedTemporary = cage.combinedValue;
                int emtpyTiles = cage.fields
                    .Where(x => x.value == 0)
                    .Count();

                cage.fields
                    .Where(x => x.value != 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        combinedTemporary -= field.value;
                    });

                SortedSet<int> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles);

                cage.fields
                    .Where(x => x.value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        field.possibleValues.RemoveWhere(x => !cagePosibilities.Contains(x));
                    });
            });
        }

        public static void removeSamePosibilities(Board board)
        {
            bool removedPossibility = false;
            List<List<Field>> rowColKubes = Helper.getAllRowColKubes(board);
            rowColKubes.ForEach(rowColKube =>
            {
                rowColKube.ForEach(field =>
                {
                    List<Field> samePosibilities = rowColKube
                        .Where(x => x.possibleValues.SetEquals(field.possibleValues))
                        .ToList();

                    if (samePosibilities.Count == field.possibleValues.Count())
                    {
                        rowColKube.ForEach(field2 =>
                        {
                            if (!samePosibilities.Contains(field2))
                            {
                                samePosibilities
                                    .First().possibleValues
                                    .ToList()
                                    .ForEach(num =>
                                    {
                                        if (field2.possibleValues.Remove(num)) removedPossibility = true;
                                    });
                            }
                        });
                    }
                });
            });
            if (removedPossibility)
            {
                Console.WriteLine("removed possiblities");
                removeSamePosibilities(board);
            } 
        }

        public static SortedSet<int> validValues(List<Field> list, SortedSet<int> baseValues = null)
        {
            if (baseValues == null) baseValues = Helper.possibleValues;

            list.ForEach(item => baseValues.Remove(item.value));
            return baseValues;
        }

        public static bool completed(Board board)
        {
            for(var i = 0; i < 9; i++)
            {
                if (!Helper.possibleValues.All(num => board.getRow(i).Select(field => field.value).Contains(num))) return false;
                if (!Helper.possibleValues.All(num => board.getColumn(i).Select(field => field.value).Contains(num))) return false;
                if (!Helper.possibleValues.All(num => board.getKube(new Tuple<int, int>(i / 3, i % 3)).Select(field => field.value).Contains(num))) return false;
            }

            return true;
        }

        public static bool findSinglePossibility(Board board)
        {
            bool res = false;

            List<List<Field>> rowColKubes = Helper.getAllRowColKubes(board);
            rowColKubes.ForEach(rowColKube =>
            {
                List<int> allPossibilities = new List<int>();
                rowColKube.ForEach(field =>
                {
                    allPossibilities = allPossibilities.Concat(field.possibleValues).ToList();
                });

                List<int> onePossibility = allPossibilities.GroupBy(x => x)
                    .Where(group => group.Count() == 1)
                    .Select(group => group.Key)
                    .ToList();

                onePossibility.ForEach(val =>
                {
                    Field field = rowColKube.Where(x => x.possibleValues.Contains(val)).First();
                    if(field.value == 0)
                    {
                        field.value = val;
                        res = true;
                        Console.WriteLine($"Filled in {field.coordinates} with {field.value} because it's the only field in the row that can have this value");
                    }
                });
            });
            return res;
        }

        //public static bool FindTemporaryCages(KillerSudoku killerSudoku)
        //{
        //    killerSudoku.tempooraryCages = new List<Cage>();

        //    List<List<Field>> rowColKubes = Helper.getAllRowColKubes(killerSudoku.board);
        //    rowColKubes.ForEach(rowColKube =>
        //    {
        //        int totalValue = 45;
        //        rowColKube.ForEach(field =>
        //        {

        //        });
        //    });
        //}
    }
}
