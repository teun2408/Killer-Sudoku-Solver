using KillerSudokuSolver.Models;
using SudokuTestProject.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuTestProject.Sudokus.Large
{
    public class Large16x16Medium : ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
        {
            List<List<int>> fieldslist = new List<List<int>>
            {
                new List<int>() { 0, 4, 0, 0, 8, 0, 16, 0, 11, 0, 1, 0, 0, 6, 0, 14 },
                new List<int>() { 3, 0, 0, 9, 0, 15, 0, 4, 10, 7, 0, 13, 0, 0, 12, 0 },
                new List<int>() { 0, 6, 0, 0, 2, 11, 0, 0, 8, 0, 0, 0, 3, 0, 0, 0 },
                new List<int>() { 15, 0, 0, 0, 0, 0, 0, 13, 0, 0, 14, 0, 0, 2, 0, 4 },

                new List<int>() { 0, 0, 0, 8, 0, 3, 0, 0, 7, 0, 0, 0, 5, 0, 0, 0 },
                new List<int>() { 0, 0, 0, 0, 0, 0, 14, 0, 0, 0, 0, 10, 0, 16, 0, 13 },
                new List<int>() { 0, 0, 9, 2, 5, 0, 13, 0, 0, 8, 0, 0, 11, 0, 0, 0 },
                new List<int>() { 12, 0, 1, 0, 0, 0, 0, 16, 0, 0, 13, 0, 0, 0, 3, 0 },

                new List<int>() { 0, 0, 0, 12, 15, 0, 0, 0, 0, 6, 0, 0, 13, 0, 4, 7 },
                new List<int>() { 16, 1, 13, 0, 10, 0, 0, 3, 0, 0, 7, 0, 0, 9, 0, 0 },
                new List<int>() { 6, 0, 0, 15, 0, 0, 11, 0, 4, 0, 0, 9, 0, 0, 2, 10 },
                new List<int>() { 0, 3, 0, 0, 0, 16, 0, 6, 0, 14, 8, 0, 0, 11, 0, 0 },

                new List<int>() { 5, 11, 3, 10, 0, 0, 0, 8, 0, 0, 12, 4, 0, 0, 0, 1 },
                new List<int>() { 0, 14, 0, 0, 11, 9, 0, 1, 0, 13, 15, 0, 4, 10, 5, 0 },
                new List<int>() { 13, 0, 4, 0, 6, 0, 0, 0, 0, 0, 0, 2, 0, 12, 0, 9 },
                new List<int>() { 0, 12, 0, 16, 0, 13, 0, 0, 0, 1, 0, 0, 6, 0, 15, 0 }
            };

            List<Field> fields = BoardGenerator.GenerateBoard(fieldslist);
            Board board = new Board(fields, new Logger(logging), 16);
            return new KillerSudoku(new List<Cage>(), board, "large 16 x 16 normal");
        }
    }
}
