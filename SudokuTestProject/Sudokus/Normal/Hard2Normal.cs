using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Normal
{
    public class Hard2Normal: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Field> prefilledFields = new List<Field>
            {
                new Field(new Tuple<int, int>(0, 0), 5),
                new Field(new Tuple<int, int>(0, 3), 8),
                new Field(new Tuple<int, int>(0, 7), 2),

                new Field(new Tuple<int, int>(1, 0), 9),
                new Field(new Tuple<int, int>(1, 3), 7),
                new Field(new Tuple<int, int>(1, 7), 3),

                new Field(new Tuple<int, int>(2, 5), 6),
                new Field(new Tuple<int, int>(2, 6), 7),

                new Field(new Tuple<int, int>(3, 0), 7),
                new Field(new Tuple<int, int>(3, 1), 9),
                new Field(new Tuple<int, int>(3, 5), 1),
                new Field(new Tuple<int, int>(3, 6), 4),

                new Field(new Tuple<int, int>(4, 2), 3),
                new Field(new Tuple<int, int>(4, 6), 8),

                new Field(new Tuple<int, int>(5, 2), 8),
                new Field(new Tuple<int, int>(5, 3), 3),
                new Field(new Tuple<int, int>(5, 7), 5),
                new Field(new Tuple<int, int>(5, 8), 7),

                new Field(new Tuple<int, int>(6, 2), 6),
                new Field(new Tuple<int, int>(6, 3), 4),
                new Field(new Tuple<int, int>(6, 6), 2),

                new Field(new Tuple<int, int>(7, 1), 2),
                new Field(new Tuple<int, int>(7, 5), 5),
                new Field(new Tuple<int, int>(7, 8), 8),

                new Field(new Tuple<int, int>(8, 1), 7),
                new Field(new Tuple<int, int>(8, 5), 3),
                new Field(new Tuple<int, int>(8, 8), 1)
            };

            Board board = new Board(prefilledFields, new Logger(logging));
            return new KillerSudoku(new List<Cage>(), board, "hard2 normal");
        }
    }
}
