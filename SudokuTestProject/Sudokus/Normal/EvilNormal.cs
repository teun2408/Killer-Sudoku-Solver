using System;
using System.Collections.Generic;
using System.Text;
using KillerSudokuSolver.Models;

namespace SudokuTestProject.Sudokus.Normal
{
    public class EvilNormal: ISudoku
    {
        public KillerSudoku CreateSudoku(bool logging)
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

            Board board = new Board(prefilledFields, new Logger(logging));
            return new KillerSudoku(new List<Cage>(), board, "evil normal");
        }
    }
}
