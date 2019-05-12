using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudokuSolver.Models
{
    public class Logger
    {
        public bool log;

        public Logger(bool log = true)
        {
            this.log = log;
        }

        public void Log(string mes, bool line = false)
        {
            if (log)
            {
                if (line) Console.WriteLine(mes);
                else Console.Write(mes);
            }
        }

        public void LogBoard(Board board)
        {
            if (log)
            {
                if(board.board.Count > 9)
                {
                    board.board.ForEach(row =>
                    {
                        row.ForEach(field => 
                        {
                            if (field.Value < 10) Console.Write(field.Value + "  ");
                            else Console.Write(field.Value + " ");
                        });
                        Console.WriteLine("");
                    });
                }
                else
                {
                    board.board.ForEach(row =>
                    {
                        row.ForEach(field => Console.Write(field.Value + " "));
                        Console.WriteLine("");
                    });
                }
            }
        }

        public void LogCages(Board board)
        {
            if (log)
            {
                board.board.ForEach(row =>
                {
                    row.ForEach(field => Console.Write(field.Cage?.CombinedValue == null ? 0.ToString() + "  " : field.Cage.CombinedValue >= 10 ? field.Cage.CombinedValue + " " : field.Cage.CombinedValue + "   "));
                    Console.WriteLine("");
                });
            }
        }
    }
}
