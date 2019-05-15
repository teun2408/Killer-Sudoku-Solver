using KillerSudokuSolver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Models
{
    [Serializable]
    public class Board
    {
        public List<List<Field>> board { get; }

        public Board(List<Field> fields = null, Logger logger = null, int size = 9)
        {
            this.Logger = logger;
            if (this.Logger == null) this.Logger = new Logger();
            board = new List<List<Field>>(size);
            for (var y = 0; y < size; y++)
            {
                board.Add(new List<Field>(size));
                List<Field> row = board[y];
                for (var x = 0; x < size; x++)
                {
                    row.Add(new Field(new Tuple<int, int>(x, y)));
                }
            }

            if (fields != null)
            {
                fields.ForEach(field =>
                {
                    board[field.Coordinates.Item2][field.Coordinates.Item1] = field;
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
                    if (field.Value == 0)
                    {
                        res.Add(field);
                    }
                });
            });
            return res;
        }

        public List<Field> getKube(KillerSudoku killersudoku, Tuple<int, int> kube)
        {
            List<Field> kubeList = new List<Field>();
            board.ForEach(row => row.ForEach(field =>
            {
                if (field.Kube(killersudoku.Board.board.Count).Item1 == kube.Item1 && field.Kube(killersudoku.Board.board.Count).Item2 == kube.Item2)
                {
                    kubeList.Add(field);
                }
            }));
            return kubeList;
        }

        public void Print()
        {
            Logger.LogBoard(this);
        }

        public Logger Logger { get; set; }

        public List<Field> allFields()
        {
            List<Field> res = new List<Field>();
            board.ForEach(row =>
            {
                res = res.Concat(row).ToList();
            });
            return res;
        }

        public List<List<Field>> GetRowColKubesOfField(KillerSudoku killersudoku, Field field)
        {
            return Helper.GetAllRowColKubes(killersudoku)
                .Where(x => x.Any(y => y == field))
                .ToList();
        }

        public void PrintCages()
        {
            Logger.LogCages(this);
        }
    }
}
