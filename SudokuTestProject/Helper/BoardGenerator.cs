using KillerSudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuTestProject.Helper
{
    public class BoardGenerator
    {
        public static List<Field> GenerateBoard(List<List<int>> prefiledPoints)
        {
            List<Field> result = new List<Field>();
            for(int x = 0; x < prefiledPoints.Count; x++)
            {
                List<int> row = prefiledPoints[x];
                for(int y = 0; y < row.Count; y++)
                {
                    int val = row[y];
                    if(val != 0)
                    {
                        result.Add(new Field(new Tuple<int, int>(y, x), val));
                    }
                }
            }
            return result;
        }
    }
}
