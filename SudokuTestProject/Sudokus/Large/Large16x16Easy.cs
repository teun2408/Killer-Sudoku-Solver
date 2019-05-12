using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Large
{
    class Large16x16Normal : ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<Field> prefilledFields = new List<Field>();
            prefilledFields.Add(new Field(new Tuple<int, int>(0, 0), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 0), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 0), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 0), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 0), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(10, 0), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 0), 7));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 1), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 1), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 1), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 1), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(13, 1), 10));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 1), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 1), 11));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 2), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 2), 10));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 2), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 2), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 2), 11));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 2), 14));

            prefilledFields.Add(new Field(new Tuple<int, int>(0, 3), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 3), 15));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 3), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 3), 14));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 3), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 3), 12));

            prefilledFields.Add(new Field(new Tuple<int, int>(0, 4), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 4), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 4), 10));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 4), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(10, 4), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 4), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(13, 4), 15));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 5), 11));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 5), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 5), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 5), 16));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 5), 15));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 5), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 5), 13));

            prefilledFields.Add(new Field(new Tuple<int, int>(3, 6), 10));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 6), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 6), 15));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 6), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 6), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 6), 11));

            prefilledFields.Add(new Field(new Tuple<int, int>(0, 7), 16));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 7), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 7), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 7), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 7), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 7), 8));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 8), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 8), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(10, 8), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 8), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 8), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 8), 3));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 9), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 9), 15));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 9), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 9), 14));
            prefilledFields.Add(new Field(new Tuple<int, int>(10, 9), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 9), 16));

            prefilledFields.Add(new Field(new Tuple<int, int>(0, 10), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 10), 8));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 10), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 10), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 10), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(13, 10), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 10), 15));

            prefilledFields.Add(new Field(new Tuple<int, int>(2, 11), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 11), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 11), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 11), 16));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 11), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 11), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 11), 5));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 12), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 12), 12));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 12), 6));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 12), 4));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 12), 11));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 12), 16));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 13), 7));
            prefilledFields.Add(new Field(new Tuple<int, int>(4, 13), 16));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 13), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(8, 13), 14));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 13), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(14, 13), 2));

            prefilledFields.Add(new Field(new Tuple<int, int>(0, 14), 11));
            prefilledFields.Add(new Field(new Tuple<int, int>(1, 14), 1));
            prefilledFields.Add(new Field(new Tuple<int, int>(2, 14), 15));
            prefilledFields.Add(new Field(new Tuple<int, int>(3, 14), 9));
            prefilledFields.Add(new Field(new Tuple<int, int>(6, 14), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(9, 14), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(13, 14), 14));

            prefilledFields.Add(new Field(new Tuple<int, int>(1, 15), 14));
            prefilledFields.Add(new Field(new Tuple<int, int>(5, 15), 11));
            prefilledFields.Add(new Field(new Tuple<int, int>(7, 15), 2));
            prefilledFields.Add(new Field(new Tuple<int, int>(10, 15), 13));
            prefilledFields.Add(new Field(new Tuple<int, int>(11, 15), 3));
            prefilledFields.Add(new Field(new Tuple<int, int>(12, 15), 5));
            prefilledFields.Add(new Field(new Tuple<int, int>(15, 15), 12));

            Board board = new Board(prefilledFields, new Logger(logging), 16);
            return new KillerSudoku(new List<Cage>(), board, "large 16 x 16 normal");
        }
    }
}
