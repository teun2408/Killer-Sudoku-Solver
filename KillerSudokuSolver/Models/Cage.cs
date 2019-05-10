using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillerSudokuSolver.Models
{
    [Serializable]
    public class Cage
    {
        public List<Field> Fields { get; set; }

        public int CombinedValue { get; set; }

        public List<Tuple<int, int>> Coordinates { get; }

        public Cage(List<Tuple<int, int>> fields, int combinedValue)
        {
            this.Coordinates = fields;
            this.CombinedValue = combinedValue;
            this.Fields = new List<Field>();
        }

        public Cage completedCage()
        {
            Cage newCage = new Cage(new List<Tuple<int, int>>(), 0);
            newCage.Fields = Fields.Where(x => x.Value == 0).ToList();
            newCage.CombinedValue = Fields.Select(x => x.Value).Aggregate((res, item) => res + item);
            return newCage;
        }
    }
}
