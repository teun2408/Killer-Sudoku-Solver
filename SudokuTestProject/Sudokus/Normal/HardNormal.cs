using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Normal
{
    public class HardNormal: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Field> prefilledFields = new List<Field>
            {
                new Field(new Tuple<int, int>(0, 0), 6),
                new Field(new Tuple<int, int>(0, 4), 4),
                new Field(new Tuple<int, int>(0, 7), 9),

                new Field(new Tuple<int, int>(1, 6), 1),
                new Field(new Tuple<int, int>(1, 8), 7),

                new Field(new Tuple<int, int>(2, 1), 7),
                new Field(new Tuple<int, int>(2, 3), 3),
                new Field(new Tuple<int, int>(2, 5), 6),
                new Field(new Tuple<int, int>(2, 8), 4),

                new Field(new Tuple<int, int>(3, 0), 5),
                new Field(new Tuple<int, int>(3, 2), 4),
                new Field(new Tuple<int, int>(3, 6), 8),
                new Field(new Tuple<int, int>(3, 8), 6),

                new Field(new Tuple<int, int>(5, 0), 7),
                new Field(new Tuple<int, int>(5, 2), 2),
                new Field(new Tuple<int, int>(5, 6), 9),
                new Field(new Tuple<int, int>(5, 8), 3),

                new Field(new Tuple<int, int>(6, 1), 9),
                new Field(new Tuple<int, int>(6, 3), 4),
                new Field(new Tuple<int, int>(6, 5), 7),
                new Field(new Tuple<int, int>(6, 8), 8),

                new Field(new Tuple<int, int>(7, 6), 4),
                new Field(new Tuple<int, int>(7, 8), 2),

                new Field(new Tuple<int, int>(8, 0), 1),
                new Field(new Tuple<int, int>(8, 4), 8),
                new Field(new Tuple<int, int>(8, 7), 5)
            };

            Board board = new Board(prefilledFields, new Logger(logging));
            return new KillerSudoku(new List<Cage>(), board, "hard normal");
        }
    }
}
