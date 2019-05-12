using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Killer
{
    public class EasyKiller: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Cage> cages = new List<Cage>
            {
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0) }, 3),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 2) }, 25),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 0), new Tuple<int, int>(3, 0), new Tuple<int, int>(4, 0) }, 15),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(5, 1), new Tuple<int, int>(4, 1), new Tuple<int, int>(4, 2) }, 22),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 1), new Tuple<int, int>(3, 1) }, 17),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 2), new Tuple<int, int>(3, 2), new Tuple<int, int>(3, 3) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0), new Tuple<int, int>(6, 1) }, 4),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 0), new Tuple<int, int>(7, 1) }, 16),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0), new Tuple<int, int>(8, 1), new Tuple<int, int>(8, 2), new Tuple<int, int>(8, 3) }, 15),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 2), new Tuple<int, int>(7, 2), new Tuple<int, int>(6, 3) }, 20),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3), new Tuple<int, int>(2, 3) }, 14),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 4), new Tuple<int, int>(2, 4), new Tuple<int, int>(1, 5) }, 13),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 4), new Tuple<int, int>(3, 5), new Tuple<int, int>(3, 6) }, 20),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 3), new Tuple<int, int>(4, 4), new Tuple<int, int>(4, 5) }, 17),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2), new Tuple<int, int>(5, 3), new Tuple<int, int>(5, 4) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3), new Tuple<int, int>(7, 4), new Tuple<int, int>(6, 4) }, 17),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 5), new Tuple<int, int>(7, 5) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 4), new Tuple<int, int>(8, 5) }, 12),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6), new Tuple<int, int>(0, 7), new Tuple<int, int>(0, 8) }, 27),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(2, 6), new Tuple<int, int>(1, 6) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 7), new Tuple<int, int>(1, 8) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 7), new Tuple<int, int>(2, 8) }, 16),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(2, 6), new Tuple<int, int>(1, 6) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 5), new Tuple<int, int>(5, 6), new Tuple<int, int>(6, 6) }, 20),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 8), new Tuple<int, int>(6, 8), new Tuple<int, int>(4, 8) }, 13),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 7), new Tuple<int, int>(6, 7) }, 15),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 6), new Tuple<int, int>(8, 6), new Tuple<int, int>(7, 7), new Tuple<int, int>(8, 7) }, 14),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 8), new Tuple<int, int>(8, 8) }, 17),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 7), new Tuple<int, int>(4, 6), new Tuple<int, int>(4, 7), new Tuple<int, int>(3, 8) }, 10)
            };

            return new KillerSudoku(cages, new Board(null, new Logger(logging)), "easy killer");
        }
    }
}
