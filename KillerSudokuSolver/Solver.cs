using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;
using KillerSudokuSolver.Strattagies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver
{
    public class Solver
    {
        public static KillerSudoku Solve(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.Logger.Log("---------------New run------------------", true);
            killerSudoku.Board.Print();

            if (Validator.Completed(killerSudoku))
            {
                killerSudoku.Board.Logger.Log("Completed the sudoku", true);
                Console.WriteLine($"entered {killerSudoku.randomCount} random values");
                killerSudoku.Board.Print();
                return killerSudoku;
            }

            List<IStrattagy> stratagies = new List<IStrattagy>
            {
                new CalculatePossibleValues(),
                new FindTemporaryCages(),
                new CalculatePossibleValuesCages(),
                //new BoxLineReduction(),
                //new PointingPairs()
            };
            stratagies.ForEach(strat => 
            {
                strat.Execute(killerSudoku);
                if (!Helper.StillValid(killerSudoku))
                {
                    killerSudoku.Board.Logger.Log("Invalid Sudoku", true);
                }

            });

            if (!Helper.StillValid(killerSudoku))
            {
                killerSudoku.Board.Logger.Log("Invalid Sudoku", true);
                return killerSudoku;
            }

            bool filledinSingle = new FillInSinglePossibilityOfRow().Execute(killerSudoku).Item2;
            if (new FillInSinglePossibleValues().Execute(killerSudoku).Item2 || filledinSingle)
            {
                //Next round
                return Solve(killerSudoku);
            }
            else
            {
                //Fill in random value
                killerSudoku.Board.Logger.Log("before random", true);

                killerSudoku.Board.Print();

                List<Cage> sf = killerSudoku.CombinedCages
                    .Where(x => x.Fields.Contains(killerSudoku.GetField(new Tuple<int, int>(3, 2))))
                    .ToList();

                KillerSudoku randomkiller = new FillInRandomValue().Execute(killerSudoku).Item1;

                if(Validator.Completed(randomkiller))
                {
                    return randomkiller;
                }
                else
                {
                    return killerSudoku;
                }
            }
        }
    }
}
