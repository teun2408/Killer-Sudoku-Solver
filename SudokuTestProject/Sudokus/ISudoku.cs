using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuTestProject.Sudokus
{
    public interface ISudoku
    {
        KillerSudoku CreateSudoku(bool logging);
    }
}
