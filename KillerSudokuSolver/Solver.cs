using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver
{
    public class Solver
    {
        public static KillerSudoku Solve(KillerSudoku killerSudoku)
        {
            killerSudoku.board.logger.Log("---------------New run------------------", true);
            killerSudoku.board.Print();

            if (completed(killerSudoku.board))
            {
                killerSudoku.board.logger.Log("Completed the sudoku", true);
                killerSudoku.board.Print();
                return killerSudoku;
            }

            CalculatePossibleValues(killerSudoku.board);
            FindTemporaryCages(killerSudoku);
            BoxLineReduction(killerSudoku.board);
            CalculatePossibleValuesCages(killerSudoku);
            removeSamePosibilities(killerSudoku.board);

            if (!Helper.StillValid(killerSudoku))
            {
                killerSudoku.board.logger.Log("Invalid Sudoku", true);
                return killerSudoku;
            }

            bool filledinSingle = findSinglePossibility(killerSudoku.board);
            if (FillInSinglePossibleValues(killerSudoku.board) || filledinSingle)
            {
                //Next round
                return Solve(killerSudoku);
            }
            else
            {
                //Fill in random value
                killerSudoku.board.logger.Log("before random", true);
                return Solve(FillInRandomValue(killerSudoku));
            }
        }

        public void RemovePossibilities(KillerSudoku killerSudoku)
        {
            CalculatePossibleValues(killerSudoku.board);
            bool res2 = FindTemporaryCages(killerSudoku);
            bool res3 = BoxLineReduction(killerSudoku.board);
            CalculatePossibleValuesCages(killerSudoku);
            bool res5 = removeSamePosibilities(killerSudoku.board);

            if(res2 || res3 || res5)
            {
                RemovePossibilities(killerSudoku);
            }
        }

        public static KillerSudoku FillInRandomValue(KillerSudoku killerSudoku)
        {
            killerSudoku.board.logger.Log("Couldn't get further, entering random value", true);
            killerSudoku.board.Print();

            Field field = killerSudoku.board
                .allUncompletedFields()
                .OrderBy(x => x.possibleValues.Count)
                .FirstOrDefault();
            
            field.possibleValues
                .ToList()
                .ForEach(val =>
                {
                    if(field.possibleValues.Contains(7) && field.possibleValues.Contains(9))
                    {
                        Helper.HashBoard(killerSudoku.board);
                        Console.WriteLine("");
                       
                    }
                    if (!completed(killerSudoku.board))
                    {
                        KillerSudoku possibility = killerSudoku.Clone2();
                        Field randomField = possibility.GetField(field.coordinates);
                        randomField.value = val;
                        randomField.possibleValues = new SortedSet<int>();
                        killerSudoku.board.logger.Log($"Filling in {val} to {field.coordinates} as a random value", true);

                        KillerSudoku result = Solve(possibility);

                        if (completed(result.board))
                        {
                            killerSudoku = result;
                        }
                    }
                });
            return killerSudoku;
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
                        board.logger.Log($"Filled in {col.coordinates} with {col.value} because it's the only possible value", true);

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
                }
            }));
        }

        public static void CalculatePossibleValuesCages(KillerSudoku killerSudoku)
        {
            killerSudoku.combinedCages.ForEach(cage =>
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

                List<SortedSet<int>> cagePosibilities = CageCombinationFinder.CagePossibilities(combinedTemporary, emtpyTiles);

                SortedSet<int> fieldPossibilities = new SortedSet<int>();
                cage.fields.SelectMany(x => x.possibleValues)
                    .ToList()
                    .ForEach(x => fieldPossibilities.Add(x));

                SortedSet<int> res = new SortedSet<int>();

                cagePosibilities.ForEach(pos =>
                {
                    if(pos.All(x => fieldPossibilities.Contains(x)))
                    {
                        pos.ToList()
                            .ForEach(y => res.Add(y));
                    }
                });

                cage.fields
                    .Where(x => x.value == 0)
                    .ToList()
                    .ForEach(field =>
                    {
                        field.possibleValues.RemoveWhere(x => !res.Contains(x));
                    });
            });
        }

        public static bool removeSamePosibilities(Board board)
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
                removeSamePosibilities(board);
            }
            return removedPossibility;
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

        public static bool BoxLineReduction(Board board)
        {
            bool result = false;
            Helper.getAllRowColKubes(board)
                .ForEach(row =>
                {
                    row.SelectMany(x => x.possibleValues)
                        .ToList()
                        .GroupBy(x => x)
                        .Where(x => x.Count() == 2)
                        .Select(x => x.Key)
                        .ToList()
                        .ForEach(num => 
                        {
                            List<Field> fields = row.Where(x => x.possibleValues.Contains(num)).ToList();
                            board.GetRowColKubesOfField(fields.FirstOrDefault())
                                .Where(x => x.Contains(fields[0]) && x.Contains(fields[1]))
                                .ToList()
                                .ForEach(col =>
                                {
                                    col.Where(x => x != fields[0] && x != fields[1])
                                        .ToList()
                                        .ForEach(field =>
                                        {
                                            if(field.possibleValues.Contains(num))
                                            {
                                                result = true;
                                            }
                                            field.possibleValues.Remove(num);
                                        });
                                });
                        });
                });
            return result;
        }

        public static bool findSinglePossibility(Board board)
        {
            bool res = false;

            board.allFields()
                .Where(x => x.possibleValues.Count == 1)
                .Where(x => x.value == 0)
                .ToList()
                .ForEach(field =>
                {
                    field.value = field.possibleValues.ToList().FirstOrDefault();

                    board.logger.Log($"Filled in {field.coordinates} with {field.value} because it's the only value it can have", true);
                    res = true;
                });

            Helper.getAllRowColKubes(board)
                .ForEach(row =>
                {
                    List<int> resdfs = row.SelectMany(x => x.possibleValues.ToList()).ToList();

                    row.SelectMany(x => x.possibleValues.ToList())
                        .GroupBy(x => x)
                        .Where(group => group.Count() == 1)
                        .Select(group => group.Key)
                        .ToList()
                        .ForEach(val =>
                        {
                            Field field = row.Where(x => x.possibleValues.Contains(val))
                                .FirstOrDefault();

                            if(field.value == 0)
                            {
                                field.value = val;
                                board.logger.Log($"Filled in {field.coordinates} with {field.value} because it's the only field in the row that can have this value", true);
                                res = true;
                            }
                        });
                });
            return res;

            //List<List<Field>> rowColKubes = Helper.getAllRowColKubes(board);
            //rowColKubes.ForEach(rowColKube =>
            //{
            //    List<int> allPossibilities = new List<int>();
            //    rowColKube.ForEach(field =>
            //    {
            //        allPossibilities = allPossibilities.Concat(field.possibleValues).ToList();
            //    });

            //    List<int> onePossibility = allPossibilities.GroupBy(x => x)
            //        .Where(group => group.Count() == 1)
            //        .Select(group => group.Key)
            //        .ToList();

            //    onePossibility.ForEach(val =>
            //    {
            //        Field field = rowColKube.Where(x => x.possibleValues.Contains(val)).First();
            //        if(field.value == 0)
            //        {
            //            field.value = val;
            //            res = true;
            //            Console.WriteLine($"Filled in {field.coordinates} with {field.value} because it's the only field in the row that can have this value");
            //        }
            //    });
            //});
            //return res;
        }

        public static bool FindTemporaryCages(KillerSudoku killerSudoku)
        {
            killerSudoku.tempooraryCages = new List<Cage>();

            List<List<Field>> rowColKubes = Helper.getAllRowColKubes(killerSudoku.board);
            rowColKubes.ForEach(rowColKube =>
            {
                int totalValue = 45;
                List<Field> temporaryCageList = new List<Field>();

                rowColKube.ForEach(x => temporaryCageList.Add(x));

                HashSet<Cage> cages = new HashSet<Cage>();
                rowColKube.ForEach(field =>
                {
                    cages.Add(field.cage);
                });

                cages
                    .Where(x => x != null)
                    .ToList()
                    .ForEach(cage =>
                    {
                        if(cage.completedCage().fields.All(x => rowColKube.Contains(x)))
                        {
                            cage.fields
                                .Where(x => rowColKube.Contains(x))
                                .ToList()
                                .ForEach(field => temporaryCageList.Remove(field));

                            cage.fields
                                .Where(x => !rowColKube.Contains(x))
                                .ToList()
                                .ForEach(x => totalValue += x.value);

                            totalValue -= cage.combinedValue;
                            if (totalValue <= 0)
                            {
                                killerSudoku.board.logger.Log("");
                            }
                        }
                        else
                        {
                            killerSudoku.board.logger.Log("");
                        }
                    });

                if(totalValue != 45)
                {
                    if(totalValue <= 0)
                    {
                        killerSudoku.board.logger.Log("");
                    }
                    else
                    {
                        Cage temporaryCage = new Cage(Helper.ToTupleList(temporaryCageList), totalValue, false);
                        temporaryCage.coordinates.ForEach(cor => temporaryCage.fields.Add(killerSudoku.GetField(cor)));
                        temporaryCage.fields.ForEach(field => field.temporaryCages.Add(temporaryCage));
                        killerSudoku.tempooraryCages.Add(temporaryCage);

                    }

                }
            });

            return true;
        }
    }
}
