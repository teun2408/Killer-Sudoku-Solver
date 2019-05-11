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
        public static KillerSudoku Start(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.allFields()
                .ForEach(field =>
                {
                    field.PossibleValues = Helper.PossibleValues(killerSudoku);
                });

            return Solve(killerSudoku);
        }

        public static KillerSudoku Solve(KillerSudoku killerSudoku)
        {
            killerSudoku.Board.Logger.Log("---------------New run------------------", true);
            killerSudoku.Board.Print();

            switch(Validator.GetStatus(killerSudoku))
            {
                case Status.Completed:
                    killerSudoku.Board.Logger.Log("Completed the sudoku", true);
                    killerSudoku.Board.Logger.Log($"entered {killerSudoku.randomCount} random values", true);
                    killerSudoku.Board.Print();
                    return killerSudoku;
                case Status.Invalid:
                    killerSudoku.Board.Logger.Log("Invalid Sudoku", true);
                    return killerSudoku;
            }

            List<IStrattagy> stratagies = new List<IStrattagy>
            {
                new CalculatePossibleValues(),
                new FindTemporaryCages(),
                new CalculatePossibleValuesCages(),
                new BoxLineReduction(),
                new PointingPairs()
            };

            stratagies.ForEach(strat => 
            {
                strat.Execute(killerSudoku);
            });

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
                KillerSudoku randomkiller = new FillInRandomValue().Execute(killerSudoku).Item1;

                if(Validator.GetStatus(randomkiller) == Status.Completed)
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
