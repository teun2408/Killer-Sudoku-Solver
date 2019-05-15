using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Normal
{
    public class MediumNormal: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Field> prefilledFields = new List<Field>
            {
                new Field(new Tuple<int, int>(0, 3), 3),
                new Field(new Tuple<int, int>(0, 4), 5),

                new Field(new Tuple<int, int>(1, 2), 3),
                new Field(new Tuple<int, int>(1, 5), 2),
                new Field(new Tuple<int, int>(1, 7), 4),
                new Field(new Tuple<int, int>(1, 8), 6),

                new Field(new Tuple<int, int>(2, 1), 6),
                new Field(new Tuple<int, int>(2, 6), 3),
                new Field(new Tuple<int, int>(2, 7), 8),

                new Field(new Tuple<int, int>(3, 0), 1),
                new Field(new Tuple<int, int>(3, 3), 7),
                new Field(new Tuple<int, int>(3, 8), 5),

                new Field(new Tuple<int, int>(4, 1), 4),
                new Field(new Tuple<int, int>(4, 4), 8),
                new Field(new Tuple<int, int>(4, 7), 3),

                new Field(new Tuple<int, int>(5, 0), 9),
                new Field(new Tuple<int, int>(5, 3), 1),
                new Field(new Tuple<int, int>(5, 8), 4),

                new Field(new Tuple<int, int>(6, 1), 8),
                new Field(new Tuple<int, int>(6, 6), 2),
                new Field(new Tuple<int, int>(6, 7), 6),

                new Field(new Tuple<int, int>(7, 2), 1),
                new Field(new Tuple<int, int>(7, 5), 9),
                new Field(new Tuple<int, int>(7, 7), 7),
                new Field(new Tuple<int, int>(7, 8), 8),

                new Field(new Tuple<int, int>(8, 3), 6),
                new Field(new Tuple<int, int>(8, 4), 7)
            };

            Board board = new Board(prefilledFields, new Logger(logging));
            return new KillerSudoku(new List<Cage>(), board, "medium normal");
        }
    }
}
