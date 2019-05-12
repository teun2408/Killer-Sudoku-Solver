using KillerSudokuSolver;
using KillerSudokuSolver.Models;
using SudokuTestProject.Sudokus;
using SudokuTestProject.Sudokus.Killer;
using SudokuTestProject.Sudokus.Large;
using SudokuTestProject.Sudokus.Normal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SudokuTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISudoku> sudokus = new List<ISudoku>
            {
                new EasyKiller(),
                new MediumKiller(),
                new HardKiller(),
                new EvilKiller(),
                new EasyNormal(),
                new Easy2Normal(),
                new MediumNormal(),
                new HardNormal(),
                new Hard2Normal(),
                new EvilNormal(),
                new Large16x16Normal(),
                new Large16x16Medium()
            };

            sudokus.ForEach(sudoku =>
            {
                KillerSudoku killerSudoku = sudoku.CreateSudoku(false);
                killerSudoku.Print();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                killerSudoku = Solver.Start(killerSudoku);
                stopwatch.Stop();

                Console.WriteLine($"Completed the sudoku {killerSudoku.Name} in {stopwatch.Elapsed} with {killerSudoku.randomCount} random values");
            });
        }
    }
}
