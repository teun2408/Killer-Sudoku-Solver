using KillerSudokuSolver.Helpers;
using KillerSudokuSolver.Models;
using KillerSudokuSolver.Stratagies;
using Newtonsoft.Json;
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
                    if(field.Value == 0)
                    {
                        field.PossibleValues = Helper.PossibleValues(killerSudoku);
                    }
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

            List<IStratagy> stratagies = new List<IStratagy>
            {
                new CalculatePossibleValues(),
                new FindTemporaryCages(),
                new CalculatePossibleValuesCages(),
                new HiddenPairs(),
                new XWing(),
                new PointingPairs(),
                new BoxLineReduction(),
                new CageUnitOverlap(),
                new FillInSinglePossibilityOfRow(),
                new FillInSinglePossibleValues(),
            };

            if (stratagies.Where(strat => strat.Execute(killerSudoku).Item2).Count() == 0)
            {
                return new FillInRandomValue().Execute(killerSudoku).Item1;
            }

            return Solve(killerSudoku);
        }
    }
}
