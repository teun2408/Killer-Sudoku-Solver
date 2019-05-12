using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudokuSolver.Stratagies
{
    public interface IStratagy
    {
        Tuple<KillerSudoku, bool> Execute(KillerSudoku killerSudoku);
    }
}
