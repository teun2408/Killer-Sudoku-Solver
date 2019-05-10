using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudokuSolver.Strattagies
{
    public interface IStrattagy
    {
        Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku);
    }
}
