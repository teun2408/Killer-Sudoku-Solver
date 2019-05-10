using KillerSudokuSolver;
using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SudokuTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //easy1();
            //easyKiller();
            //mediumKiller();
            //mediumKiller2();
            //hardKiller();

            //noCages();
            //noCagesMed();
            //noCagesHard();

            //noCagesHard2();

            noCagesEvil();

            //test();

            //test2();

            //SortedSet<int> posibilities = CageCombinationFinder.CagePossibilities(8, 3);
            Console.Write("");
        }

        public static void easy1()
        {
            List<Cage> cages = new List<Cage>();
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1)}, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 2)}, 1));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3)}, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 8)}, 7));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 1)}, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 2)}, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3)}, 2));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 5)}, 5));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 7)}, 4));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 4)}, 4));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 6)}, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 8)}, 3));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 0)}, 2));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 3)}, 1));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 4)}, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 6)}, 3));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 0)}, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 1)}, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 7)}, 5));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 8)}, 1));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2)}, 4));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4)}, 2));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4)}, 2));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 8)}, 8));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0)}, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 2)}, 5));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 4)}, 9));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 1)}, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3)}, 4));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 5)}, 2));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 6)}, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 7)}, 3));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0) }, 1));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 5) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 6) }, 4));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 7) }, 6));

            KillerSudoku killerSudoku = new KillerSudoku(cages, new Board());

            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void easyKiller()
        {
            List<Cage> cages = new List<Cage>();
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0) }, 3));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(1, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 2) }, 25));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 0), new Tuple<int, int>(3, 0), new Tuple<int, int>(4, 0) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(5, 1), new Tuple<int, int>(4, 1), new Tuple<int, int>(4, 2) }, 22));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 1), new Tuple<int, int>(3, 1) }, 17));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 2), new Tuple<int, int>(3, 2), new Tuple<int, int>(3, 3)}, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0), new Tuple<int, int>(6, 1) }, 4));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 0), new Tuple<int, int>(7, 1) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0), new Tuple<int, int>(8, 1), new Tuple<int, int>(8, 2), new Tuple<int, int>(8, 3) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 2), new Tuple<int, int>(7, 2), new Tuple<int, int>(6, 3) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3), new Tuple<int, int>(2, 3) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 4), new Tuple<int, int>(2, 4), new Tuple<int, int>(1, 5) }, 13));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 4), new Tuple<int, int>(3, 5), new Tuple<int, int>(3, 6) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 3), new Tuple<int, int>(4, 4), new Tuple<int, int>(4, 5) }, 17));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2), new Tuple<int, int>(5, 3), new Tuple<int, int>(5, 4) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3), new Tuple<int, int>(7, 4), new Tuple<int, int>(6, 4) }, 17));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 5), new Tuple<int, int>(7, 5) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 4), new Tuple<int, int>(8, 5) }, 12));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6), new Tuple<int, int>(0, 7), new Tuple<int, int>(0, 8) }, 27));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(2, 6), new Tuple<int, int>(1, 6) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 7), new Tuple<int, int>(1, 8) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 7), new Tuple<int, int>(2, 8) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(2, 6), new Tuple<int, int>(1, 6) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 5), new Tuple<int, int>(5, 6), new Tuple<int, int>(6, 6) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 8), new Tuple<int, int>(6, 8), new Tuple<int, int>(4, 8) }, 13));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 7), new Tuple<int, int>(6, 7) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 6), new Tuple<int, int>(8, 6), new Tuple<int, int>(7, 7), new Tuple<int, int>(8, 7) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 8), new Tuple<int, int>(8, 8) }, 17));

            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 7), new Tuple<int, int>(4, 6), new Tuple<int, int>(4, 7), new Tuple<int, int>(3, 8) }, 10));


            KillerSudoku killerSudoku = new KillerSudoku(cages, new Board(null, new Logger(true)));
            
            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            KillerSudoku killerSudoku1 = Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void mediumKiller()
        {
            List<Cage> cages = new List<Cage>();
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2) }, 12));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 0), new Tuple<int, int>(1, 1) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 0), new Tuple<int, int>(2, 1) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 0), new Tuple<int, int>(4, 0) }, 12));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 1), new Tuple<int, int>(4, 1) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(5, 1) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0), new Tuple<int, int>(7, 0) }, 11));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 1), new Tuple<int, int>(7, 1) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 2), new Tuple<int, int>(7, 2) }, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0), new Tuple<int, int>(8, 1), new Tuple<int, int>(8, 2) }, 18));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 2), new Tuple<int, int>(5, 2) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 2), new Tuple<int, int>(3, 2) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3), new Tuple<int, int>(1, 2), new Tuple<int, int>(2, 3) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 3), new Tuple<int, int>(4, 3) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 3), new Tuple<int, int>(6, 3) }, 12));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4), new Tuple<int, int>(6, 4), new Tuple<int, int>(7, 4), new Tuple<int, int>(7, 3) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 3), new Tuple<int, int>(8, 4) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 4), new Tuple<int, int>(2, 4) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 4), new Tuple<int, int>(4, 4) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(1, 5) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(3, 5), new Tuple<int, int>(4, 5) }, 13));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 5), new Tuple<int, int>(5, 6) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 5), new Tuple<int, int>(6, 6) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 5), new Tuple<int, int>(7, 6), new Tuple<int, int>(7, 7) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 5), new Tuple<int, int>(8, 6) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 6), new Tuple<int, int>(0, 7) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 8), new Tuple<int, int>(1, 7), new Tuple<int, int>(1, 8), new Tuple<int, int>(2, 7), new Tuple<int, int>(2, 8) }, 29));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 6), new Tuple<int, int>(2, 6), new Tuple<int, int>(3, 6), new Tuple<int, int>(3, 7) }, 18));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 8), new Tuple<int, int>(4, 8) }, 11));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 6), new Tuple<int, int>(4, 7) }, 3));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 7), new Tuple<int, int>(5, 8), new Tuple<int, int>(6, 7), new Tuple<int, int>(6, 8) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 8), new Tuple<int, int>(8, 7), new Tuple<int, int>(8, 8) }, 17));

            KillerSudoku killerSudoku = new KillerSudoku(cages, new Board(null, new Logger(true)));

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            KillerSudoku killerSudoku1 = Solver.Solve(killerSudoku);
            killerSudoku.Board.Logger = new Logger(true);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void mediumKiller2()
        {
            List<Cage> cages = new List<Cage>();
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0), new Tuple<int, int>(2, 1), new Tuple<int, int>(3, 0) }, 19));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 0), new Tuple<int, int>(3, 1), new Tuple<int, int>(4, 1) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(6, 0), new Tuple<int, int>(7, 0) }, 23));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 0), new Tuple<int, int>(8, 1), new Tuple<int, int>(7, 1) }, 11));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 1), new Tuple<int, int>(6, 1) }, 6));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 1), new Tuple<int, int>(1, 2), new Tuple<int, int>(1, 3) }, 33));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 2), new Tuple<int, int>(2, 3) }, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 2), new Tuple<int, int>(4, 2), new Tuple<int, int>(3, 3), new Tuple<int, int>(4, 3) }, 24));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 2), new Tuple<int, int>(6, 2) }, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 2), new Tuple<int, int>(8, 2) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 3), new Tuple<int, int>(6, 3) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3), new Tuple<int, int>(8, 3) }, 11));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 7));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 4), new Tuple<int, int>(2, 4), new Tuple<int, int>(3, 4) }, 18));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 4), new Tuple<int, int>(6, 4), new Tuple<int, int>(7, 4) }, 16));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 4), new Tuple<int, int>(4, 5), new Tuple<int, int>(4, 6) }, 11));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 5), new Tuple<int, int>(8, 4) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 5), new Tuple<int, int>(1, 6) }, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 5), new Tuple<int, int>(3, 5) }, 9));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 6), new Tuple<int, int>(3, 6), new Tuple<int, int>(3, 7) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 7), new Tuple<int, int>(0, 8), new Tuple<int, int>(1, 7), new Tuple<int, int>(1, 8), new Tuple<int, int>(2, 7) }, 28));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 8), new Tuple<int, int>(3, 8), new Tuple<int, int>(4, 8), new Tuple<int, int>(4, 7) }, 19));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 5), new Tuple<int, int>(5, 6), new Tuple<int, int>(5, 7), new Tuple<int, int>(5, 8) }, 18));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 5), new Tuple<int, int>(6, 6), new Tuple<int, int>(7, 5), new Tuple<int, int>(7, 6) }, 23));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 6), new Tuple<int, int>(8, 7), new Tuple<int, int>(7, 7), new Tuple<int, int>(8, 8) }, 21));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 7), new Tuple<int, int>(6, 8), new Tuple<int, int>(7, 8) }, 17));

            KillerSudoku killerSudoku = new KillerSudoku(cages, new Board(null, new Logger(true)));
            killerSudoku.Print();


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            KillerSudoku killerSudoku1 = Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void hardKiller()
        {
            //http://www.sudokuwiki.org/killersudoku.htm?bd=111212111322212223333444333121141121123141321443333344441121144311121113333222333,080000171222150000270000000000000020000000200000000000051713000010001314000041000000000000150000000000001800000025003319000000220000000000000019000000000000000000
            List<Cage> cages = new List<Cage>();
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 0), new Tuple<int, int>(1, 0), new Tuple<int, int>(2, 0) }, 8));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 0), new Tuple<int, int>(3, 1), new Tuple<int, int>(1, 1), new Tuple<int, int>(2, 1) }, 17));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 0), new Tuple<int, int>(4, 1) }, 12));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 0), new Tuple<int, int>(5, 1), new Tuple<int, int>(6, 1), new Tuple<int, int>(7, 1) }, 22));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(6, 0), new Tuple<int, int>(7, 0), new Tuple<int, int>(8, 0) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1), new Tuple<int, int>(0, 2), new Tuple<int, int>(1, 2), new Tuple<int, int>(2, 2) }, 27));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(3, 2), new Tuple<int, int>(4, 2), new Tuple<int, int>(5, 2), new Tuple<int, int>(4, 3), new Tuple<int, int>(4, 4) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 1), new Tuple<int, int>(8, 2), new Tuple<int, int>(7, 2), new Tuple<int, int>(6, 2) }, 20));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 3), new Tuple<int, int>(0, 4) }, 5));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 3), new Tuple<int, int>(1, 4) }, 17));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 3), new Tuple<int, int>(3, 3), new Tuple<int, int>(3, 4) }, 13));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 3), new Tuple<int, int>(5, 4), new Tuple<int, int>(6, 3) }, 10));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 3), new Tuple<int, int>(7, 4) }, 13));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 3), new Tuple<int, int>(8, 4) }, 14));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6), new Tuple<int, int>(1, 5), new Tuple<int, int>(1, 6) }, 15));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(2, 4), new Tuple<int, int>(2, 5), new Tuple<int, int>(3, 5), new Tuple<int, int>(4, 5), new Tuple<int, int>(5, 5), new Tuple<int, int>(6, 5), new Tuple<int, int>(6, 4) }, 41));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(7, 5), new Tuple<int, int>(7, 6), new Tuple<int, int>(8, 5), new Tuple<int, int>(8, 6) }, 18));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(0, 7), new Tuple<int, int>(0, 8), new Tuple<int, int>(1, 8), new Tuple<int, int>(2, 8) }, 22));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(1, 7), new Tuple<int, int>(2, 6), new Tuple<int, int>(3, 6), new Tuple<int, int>(2, 7), new Tuple<int, int>(3, 7) }, 25));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(8, 7), new Tuple<int, int>(8, 8), new Tuple<int, int>(7, 8), new Tuple<int, int>(6, 8) }, 19));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(5, 6), new Tuple<int, int>(5, 7), new Tuple<int, int>(6, 6), new Tuple<int, int>(6, 7), new Tuple<int, int>(7, 7) }, 19));
            cages.Add(new Cage(new List<Tuple<int, int>>() { new Tuple<int, int>(4, 6), new Tuple<int, int>(4, 7), new Tuple<int, int>(4, 8), new Tuple<int, int>(3, 8), new Tuple<int, int>(5, 8) }, 33));

            KillerSudoku killerSudoku = new KillerSudoku(cages, new Board(null, new Logger(true)));
            killerSudoku.Print();


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            KillerSudoku killerSudoku1 = Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }


        public static void noCages()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 1), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 2), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 3), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 8), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 1), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 2), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 3), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 5), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 7), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 4), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 6), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 8), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 0), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 3), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 4), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 6), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 0), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 1), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 7), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 8), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 2), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 4), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 4), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 8), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 0), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 2), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 4), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 1), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 3), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 5), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 6), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 7), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 0), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 5), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 6), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 7), 6));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Solver.Solve(killerSudoku);

        }

        public static void noCagesMed()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 3), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 4), 5));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 2), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 5), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 7), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 8), 6));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 1), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 6), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 7), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(3, 0), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 3), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 8), 5));

            prefilledFields.Add(new Field(new Tuple<int, int>(4, 1), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 4), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 7), 3));

            prefilledFields.Add(new Field(new Tuple<int, int>(5, 0), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 3), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 8), 4));

            prefilledFields.Add(new Field(new Tuple<int, int>(6, 1), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 6), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 7), 6));

            prefilledFields.Add(new Field(new Tuple<int, int>(7, 2), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 5), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 7), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 8), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(8, 3), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 4), 7));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void noCagesHard()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 0), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 4), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 7), 9));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 6), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 8), 7));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 1), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 3), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 5), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 8), 4));

            prefilledFields.Add(new Field(new Tuple<int, int>(3, 0), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 2), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 6), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 8), 6));

            prefilledFields.Add(new Field(new Tuple<int, int>(5, 0), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 2), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 6), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 8), 3));

            prefilledFields.Add(new Field(new Tuple<int, int>(6, 1), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 3), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 5), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 8), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(7, 6), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 8), 2));

            prefilledFields.Add(new Field(new Tuple<int, int>(8, 0), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 4), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 7), 5));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void noCagesHard2()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 0), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 3), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 7), 2));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 0), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 3), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 7), 3));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 5), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 6), 7));

            prefilledFields.Add(new Field(new Tuple<int, int>(3, 0), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 1), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 5), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 6), 4));

            prefilledFields.Add(new Field(new Tuple<int, int>(4, 2), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 6), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(5, 2), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 3), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 7), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 8), 7));

            prefilledFields.Add(new Field(new Tuple<int, int>(6, 2), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 3), 4));

            prefilledFields.Add(new Field(new Tuple<int, int>(7, 1), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 5), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 8), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(8, 1), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 5), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 8), 1));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void noCagesEvil()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 1), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 6), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 7), 3));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 5), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 6), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 0), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 2), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 4), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 6), 9));

            prefilledFields.Add(new Field(new Tuple<int, int>(3, 4), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 5), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(4, 0), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 4), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 8), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(5, 4), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 3), 4));

            prefilledFields.Add(new Field(new Tuple<int, int>(6, 2), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 4), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 6), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 8), 6));

            prefilledFields.Add(new Field(new Tuple<int, int>(7, 2), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 3), 5));

            prefilledFields.Add(new Field(new Tuple<int, int>(8, 1), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 2), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 7), 2));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Solver.Solve(killerSudoku);
            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);
        }

        public static void test()
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 3), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 4), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 1), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 2), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 5), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 6), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 7), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 8), 1));

            Board board = new Board(prefilledFields);
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), board);

            killerSudoku.Print();

            Solver.Solve(killerSudoku);
        }

        public static void test2()
        {
            KillerSudoku killerSudoku = new KillerSudoku(new List<Cage>(), new Board());
            killerSudoku.Print();
            Solver.Solve(killerSudoku);
        }
    }
}
