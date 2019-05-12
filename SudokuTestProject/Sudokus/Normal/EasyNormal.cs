using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuTestProject.Sudokus.Normal
{
    class EasyNormal: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Cage> cages = new List<Cage>
            {
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 2) }, 1),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 8) }, 7),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 1) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 2) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3) }, 2),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 5) }, 5),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 7) }, 4),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 4) }, 4),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 6) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 8) }, 3),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 0) }, 2),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 3) }, 1),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 4) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 6) }, 3),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 0) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 1) }, 7),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 7) }, 5),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 8) }, 1),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2) }, 4),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4) }, 2),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4) }, 2),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 8) }, 8),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0) }, 7),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 2) }, 5),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 4) }, 9),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 1) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3) }, 4),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 5) }, 2),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 6) }, 7),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 7) }, 3),

                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0) }, 1),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 5) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 6) }, 4),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 7) }, 6)
            };

            return new KillerSudoku(cages, new Board(null, new Logger(logging)), "easy normal");
        }
    }
}
