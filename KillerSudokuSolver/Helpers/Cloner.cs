using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace KillerSudokuSolver.Helpers
{
    public static class Cloner
    {
        public static KillerSudoku Clone(this KillerSudoku source)
        {
            Board cloneBoard = new Board(null, source.Board.Logger);
            List<Cage> clonedCages = new List<Cage>();
            for (int i = 0; i < source.Board.board.Count; i++)
            {
                List<Field> newRow = new List<Field>();
                source.Board.board[i].ForEach(field =>
                {
                    Field newField = new Field(field.Coordinates, field.Value);
                    field.PossibleValues.ToList().ForEach(x => newField.PossibleValues.Add(x));
                    newRow.Add(newField);
                });
                cloneBoard.board[i] = newRow;
            }

            source.Cages.ForEach(cage =>
            {
                clonedCages.Add(new Cage(cage.Coordinates, cage.CombinedValue));
            });
            return new KillerSudoku(clonedCages, cloneBoard, source.Name) { randomCount = source.randomCount };
        }
    }
}
