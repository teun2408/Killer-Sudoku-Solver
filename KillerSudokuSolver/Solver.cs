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
                    killerSudoku.Board.Logger.ErrorCount += 1;
                    return killerSudoku;
            }

            List<IStratagy> stratagies = new List<IStratagy>
            {
                new CalculatePossibleValues(),
                new FindTemporaryCages(),
                new CageSplitting(),
                new InnieOutie(),
                new CalculatePossibleValuesCages(),
                new CageCombinations(),
                new HiddenPairs(),
                new XWing(),
                new PointingPairs(),
                new BoxLineReduction(),
                new CageUnitOverlap(),
                new FillInSinglePossibilityOfRow(),
                new FillInSinglePossibleValues()
            };

            List<IStratagy> list = stratagies.Where(strat => strat.Execute(killerSudoku).Item2).ToList();

            switch (Validator.GetStatus(killerSudoku))
            {
                case Status.Completed:
                    killerSudoku.Board.Logger.Log("Completed the sudoku", true);
                    killerSudoku.Board.Logger.Log($"entered {killerSudoku.randomCount} random values", true);
                    killerSudoku.Board.Print();
                    return killerSudoku;
                case Status.Invalid:
                    killerSudoku.Board.Logger.Log("Invalid Sudoku", true);
                    killerSudoku.Board.Logger.ErrorCount += 1;
                    return killerSudoku;
            }

            if (list.Count() == 0)
            {
                Tuple<KillerSudoku, bool> result = new FillInRandomValue().Execute(killerSudoku);
                return result.Item1;
            }

            return Solve(killerSudoku);
        }
    }
}
