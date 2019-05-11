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

        public Cage CompletedCage()
        {
            List<Field> uncompletedFields = Fields.Where(x => x.Value == 0).ToList();
            if(uncompletedFields.Count == 0)
            {
                return new Cage(new List<Tuple<int, int>>(), 0);
            }

            Cage newCage = new Cage(new List<Tuple<int, int>>(), 0)
            {
                Fields = uncompletedFields,
                CombinedValue = this.CombinedValue - Fields.Select(x => x.Value).Aggregate((res, item) => res + item)
            };
            return newCage;
        }
    }
}
