using KillerSudokuSolver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KillerSudokuSolver.Models
{
    [Serializable]
    public class KillerSudoku
    {
        public Board Board { get; set; }

        public List<Cage> Cages { get; set; }

        public List<Cage> TempooraryCages { get; set; }

        public List<Cage> CombinedCages => Cages.Concat(TempooraryCages).ToList();

        public string Name { get; set; }

        public KillerSudoku(List<Cage> cages, Board board, string name)
        {
            this.Name = name;
            this.Board = board;
            this.Cages = cages;
            this.TempooraryCages = new List<Cage>();
            this.Cages.ForEach(cage => 
            {
                cage.Coordinates.ForEach(cor => { cage.Fields.Add(GetField(cor)); GetField(cor).Cage = cage; } );
            });
        }

        public Field GetField(Tuple<int, int> coordinate)
        {
            return Board.board[coordinate.Item2][coordinate.Item1];
        }

        public int CompletionRate => Helper.ConcatBoard(Board).Where(x => x.Value != 0).Count();

        public List<Cage> getCages(Tuple<int, int> coordinates)
        {
            return Cages.Where(x => x.Coordinates.Contains(coordinates)).ToList();
        }

        public int randomCount = 0;

        public void Print()
        {
            Board.Print();

            Board.Logger.Log("------------------Cages-------------------", true);

            Board.PrintCages();
        }
    }
}
