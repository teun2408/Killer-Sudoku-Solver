using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Normal
{
    public class Easy2Normal : ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
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

            Board board = new Board(prefilledFields, new Logger(logging));
            return new KillerSudoku(new List<Cage>(), board, "easy2 normal");
        }
    }
}
