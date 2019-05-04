using System;
using System.Collections.Generic;
using System.Linq;

namespace KillerSudokuSolver
{
    [Serializable]
    public class KillerSudoku
    {
        public Board board { get; set; }

        public List<Cage> cages { get; set; }

        public List<Cage> tempooraryCages { get; set; }

        public List<Cage> combinedCages => cages.Concat(tempooraryCages).ToList();

        public KillerSudoku(List<Cage> cages, Board board)
        {
            this.board = board;
            this.cages = cages;
            this.cages.ForEach(cage => 
            {
                cage.coordinates.ForEach(cor => { cage.fields.Add(GetField(cor)); GetField(cor).cage = cage; } );
            });
        }

        public Field GetField(Tuple<int, int> coordinate)
        {
            return board.board[coordinate.Item2][coordinate.Item1];
        }

        public int completionRate => Helper.concatBoard(board).Where(x => x.value != 0).Count();

        public List<Cage> getCages(Tuple<int, int> coordinates)
        {
            return cages.Where(x => x.coordinates.Contains(coordinates)).ToList();
        }

        public void Print()
        {
            board.Print();

            board.logger.Log("------------------Cages-------------------", true);

            board.PrintCages();
        }
    }

    [Serializable]
    public class Board
    {
        public List<List<Field>> board { get; }

        public Board(List<Field> fields = null, Logger logger = null)
        {
            this.logger = logger;
            if (this.logger == null) this.logger = new Logger();
            board = new List<List<Field>>(9);
            for (var y = 0; y < 9; y++)
            {
                board.Add(new List<Field>(9));
                List<Field> row = board[y];
                for (var x = 0; x < 9; x++)
                {
                    row.Add(new Field(new Tuple<int, int>(x, y)));
                }
            }

            if(fields != null)
            {
                fields.ForEach(field =>
                {
                    board[field.coordinates.Item2][field.coordinates.Item1] = field;
                });
            }

            this.board = board;
        }

        public List<Field> getColumn(int column)
        {
            List<Field> columnList = new List<Field>();
            board.ForEach(row => columnList.Add(row[column]));
            return columnList;
        }

        public List<Field> getRow(int row)
        {
            return board[row];
        }

        public List<Field> allUncompletedFields()
        {
            List<Field> res = new List<Field>();
            board.ForEach(row =>
            {
                row.ForEach(field =>
                {
                    if(field.value == 0)
                    {
                        res.Add(field);
                    }
                });
            });
            return res;
        }

        public List<Field> getKube(Tuple<int, int> kube)
        {
            List<Field> kubeList = new List<Field>();
            board.ForEach(row => row.ForEach(field =>
            {
                if (field.kube.Item1 == kube.Item1 && field.kube.Item2 == kube.Item2)
                {
                    kubeList.Add(field);
                }
            }));
            return kubeList;
        }

        public void Print()
        {
            logger.LogBoard(this);
        }

        public Logger logger { get; set; }

        public List<Field> allFields()
        {
            List<Field> res = new List<Field>();
            board.ForEach(row =>
            {
                res = res.Concat(row).ToList();
            });
            return res;
        }

        public List<List<Field>> GetRowColKubesOfField(Field field)
        {
            return Helper.getAllRowColKubes(this)
                .Where(x => x.Any(y => y == field))
                .ToList();
        }

        public void PrintCages()
        {
            logger.LogCages(this);
        }
    }

    [Serializable]
    public class Cage
    {
        public List<Field> fields { get; set; }

        public int combinedValue { get; set; }

        public List<Tuple<int, int>> coordinates { get; }

        public Cage(List<Tuple<int, int>> fields, int combinedValue, bool cloned = false)
        {
            this.coordinates = fields;
            this.combinedValue = combinedValue;
            this.fields = new List<Field>();
            this.cloned = cloned;
        }

        public Cage completedCage()
        {
            Cage newCage = new Cage(new List<Tuple<int, int>>(), 0);
            newCage.fields = fields.Where(x => x.value == 0).ToList();
            newCage.combinedValue = fields.Select(x => x.value).Aggregate((res, item) => res + item);
            return newCage;
        }

        public bool cloned;
    }

    [Serializable]
    public class Field
    {
        public Tuple<int, int> coordinates { get; }

        public Cage cage { get; set; }

        public List<Cage> temporaryCages { get; set; }

        public int value { get; set; }

        public Tuple<int, int> kube => new Tuple<int, int>(coordinates.Item1 / 3, coordinates.Item2 / 3);

        public SortedSet<int> possibleValues { get; set; }

        public Field(Tuple<int, int> coordinates, int value = 0, bool cloned = false)
        {
            this.coordinates = coordinates;
            this.value = value;
            this.possibleValues = new SortedSet<int>();
            this.cloned = cloned;
            this.temporaryCages = new List<Cage>();
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public bool cloned;
    }

    public class Logger
    {
        public bool log;

        public Logger(bool log = true)
        {
            this.log = log;
        }

        public void Log(string mes, bool line = false)
        {
            if(log)
            {
                if (line) Console.WriteLine(mes);
                else Console.Write(mes);
            }
        }

        public void LogBoard(Board board)
        {
            if (log)
            {
                board.board.ForEach(row =>
                {
                    row.ForEach(field => Console.Write(field.value + " "));
                    Console.WriteLine("");
                });
            }
        }

        public void LogCages(Board board)
        {
            if(log)
            {
                board.board.ForEach(row =>
                {
                    row.ForEach(field => Console.Write(field.cage?.combinedValue == null ? 0.ToString() + "   " : field.cage.combinedValue >= 10 ? field.cage.combinedValue + "  " : field.cage.combinedValue + "   "));
                    Console.WriteLine("");
                    Console.WriteLine("");
                });
            }
        }
    }

    public class Helper
    {
        public static SortedSet<int> possibleValues => new SortedSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static List<List<Field>> getAllRowColKubes(Board board)
        {
            List<List<Field>> rowColKubes = new List<List<Field>>();
            board.board.ForEach(row => rowColKubes.Add(row));
            for (var i = 0; i < 9; i++) { rowColKubes.Add(board.getColumn(i)); };
            for (var i = 0; i < 9; i++) { rowColKubes.Add(board.getKube(new Tuple<int, int>(i / 3, i % 3))); };
            return rowColKubes;
        }

        public static List<Field> concatBoard(Board board)
        {
            List<Field> fields = new List<Field>();
            board.board.ForEach(row => fields = fields.Concat(row).ToList());
            return fields;
        }

        public static void HashBoard(Board board)
        {
            board.allFields().Select(x => x.value)
                .Where(x => x != 0)
                .ToList()
                .ForEach(x => Console.Write(x));

        }

        public static bool StillValid(KillerSudoku killerSudoku)
        {
            int zeroPos = concatBoard(killerSudoku.board)
                    .Where(x => x.possibleValues.Count == 0)
                    .Where(x => x.value == 0)
                    .Count();

            bool zeroPossibleValues = zeroPos == 0 || zeroPos == 81;

            List<Field> fileds = concatBoard(killerSudoku.board)
                    .Where(x => x.possibleValues.Count == 0)
                    .Where(x => x.value == 0)
                    .ToList();

            bool doubleValues = getAllRowColKubes(killerSudoku.board)
                .Where(box =>
                {
                    int res = box.Where(x => x.value != 0)
                        .GroupBy(x => x.value)
                        .Where(x => x.Count() > 1)
                        .Count();
                    return res != 0;
                })
                .Count() == 0;

            bool cages = killerSudoku.cages.Where(cage => cage.combinedValue < cage.fields
                                .Select(x => x.value)
                                .Aggregate((a, b) => a + b))
                                .ToList()
                                .Count() == 0;

            List<Cage> ressdf = killerSudoku.cages.Where(cage => cage.combinedValue < cage.fields
                                .Select(x => x.value)
                                .Aggregate((a, b) => a + b))
                                .ToList();

            if (!cages)
            {
                killerSudoku.board.logger.Log($"", true);
            }

            return zeroPossibleValues && doubleValues && cages;
        }

        public static List<Tuple<int, int>> ToTupleList(List<Field> fields)
        {
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            fields.ForEach(field => res.Add(field.coordinates));
            return res;
        }
    }
}
