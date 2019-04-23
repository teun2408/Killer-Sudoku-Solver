using System;
using System.Collections.Generic;
using System.Linq;

namespace KillerSudokuSolver
{
    public class KillerSudoku
    {
        public Board board { get; }

        public List<Cage> cages { get; }

        public List<Cage> tempooraryCages { get; set; }

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

        public void Print()
        {
            board.Print();

            Console.WriteLine("------------------Cages-------------------");

            board.PrintCages();
        }
    }

    public class Board
    {
        public List<List<Field>> board { get; }

        public Board(List<Field> fields = null)
        {
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
            board.ForEach(row =>
            {
                row.ForEach(field => Console.Write(field.value + " "));
                Console.WriteLine("");
            });
        }

        public void PrintCages()
        {
            board.ForEach(row =>
            {
                row.ForEach(field =>
                {
                    if (field.cage?.combinedValue == null)
                    {
                        Console.WriteLine(field.coordinates);
                    }
                });

                row.ForEach(field => Console.Write(field.cage?.combinedValue == null ? 0.ToString() + "  un " : field.cage.combinedValue >= 10 ? field.cage.combinedValue + "  " : field.cage.combinedValue + "   "));
                Console.WriteLine("");
                Console.WriteLine("");
            });
        }
    }

    public class Cage
    {
        public List<Field> fields { get; }

        public int combinedValue { get; }

        public List<Tuple<int, int>> coordinates { get; }

        public Cage(List<Tuple<int, int>> fields, int combinedValue)
        {
            this.coordinates = fields;
            this.combinedValue = combinedValue;
            this.fields = new List<Field>();
        }
    }

    public class Field
    {
        public Tuple<int, int> coordinates { get; }

        public Cage cage { get; set; }

        public int value { get; set; }

        public Tuple<int, int> kube => new Tuple<int, int>(coordinates.Item1 / 3, coordinates.Item2 / 3);

        public SortedSet<int> possibleValues { get; set; }

        public Field(Tuple<int, int> coordinates, int value = 0)
        {
            this.coordinates = coordinates;
            this.value = value;
            this.possibleValues = new SortedSet<int>();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class Helper
    {
        public static void PrintRowOrColumn(List<Field> fields)
        {
            fields.ForEach(field => Console.Write(field.value + " "));
            Console.WriteLine();
        }

        public static void PrintKube(List<Field> fields)
        {
            for(int i = 0; i < 9; i++)
            {
                if ((i) % 3 == 0) Console.WriteLine();
                Console.Write(fields[i].value + " ");
            }
            Console.WriteLine();
        }

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
    }
}
