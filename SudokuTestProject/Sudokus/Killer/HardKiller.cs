using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Killer
{
    public class HardKiller : ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Cage> cages = new List<Cage>
            {
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0), new Tuple<int, int>(2, 1), new Tuple<int, int>(3, 0) }, 19),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 0), new Tuple<int, int>(3, 1), new Tuple<int, int>(4, 1) }, 14),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(6, 0), new Tuple<int, int>(7, 0) }, 23),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0), new Tuple<int, int>(8, 1), new Tuple<int, int>(7, 1) }, 11),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 1), new Tuple<int, int>(6, 1) }, 6),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 2), new Tuple<int, int>(1, 3) }, 33),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 2), new Tuple<int, int>(2, 3) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 2), new Tuple<int, int>(4, 2), new Tuple<int, int>(3, 3), new Tuple<int, int>(4, 3) }, 24),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2), new Tuple<int, int>(6, 2) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 2), new Tuple<int, int>(8, 2) }, 7),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 3), new Tuple<int, int>(6, 3) }, 10),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3), new Tuple<int, int>(8, 3) }, 11),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 7),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 4), new Tuple<int, int>(2, 4), new Tuple<int, int>(3, 4) }, 18),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4), new Tuple<int, int>(6, 4), new Tuple<int, int>(7, 4) }, 16),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 4), new Tuple<int, int>(4, 5), new Tuple<int, int>(4, 6) }, 11),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 5), new Tuple<int, int>(8, 4) }, 8),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6) }, 10),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 5), new Tuple<int, int>(1, 6) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(3, 5) }, 9),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 6), new Tuple<int, int>(3, 6), new Tuple<int, int>(3, 7) }, 15),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 7), new Tuple<int, int>(0, 8), new Tuple<int, int>(1, 7), new Tuple<int, int>(1, 8), new Tuple<int, int>(2, 7) }, 28),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 8), new Tuple<int, int>(3, 8), new Tuple<int, int>(4, 8), new Tuple<int, int>(4, 7) }, 19),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 5), new Tuple<int, int>(5, 6), new Tuple<int, int>(5, 7), new Tuple<int, int>(5, 8) }, 18),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 5), new Tuple<int, int>(6, 6), new Tuple<int, int>(7, 5), new Tuple<int, int>(7, 6) }, 23),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 6), new Tuple<int, int>(8, 7), new Tuple<int, int>(7, 7), new Tuple<int, int>(8, 8) }, 21),
                new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 7), new Tuple<int, int>(6, 8), new Tuple<int, int>(7, 8) }, 17)
            };

            return new KillerSudoku(cages, new Board(null, new Logger(logging)), "hard killer");
        }
    }
}
