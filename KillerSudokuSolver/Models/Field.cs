using System;
using System.Collections.Generic;
using System.Text;

namespace KillerSudokuSolver.Models
{
    [Serializable]
    public class Field
    {
        public Tuple<int, int> Coordinates { get; }

        public Cage Cage { get; set; }

        public List<Cage> TemporaryCages { get; set; }

        public int Value { get; set; }

        public Tuple<int, int> Kube(int size)
        {
            int kubecount = Convert.ToInt32(Math.Sqrt(size));
            Tuple<int, int> kube = new Tuple<int, int>(Coordinates.Item1 / kubecount, Coordinates.Item2 / kubecount);
            return kube;
        }

        public SortedSet<int> PossibleValues { get; set; }

        public Field(Tuple<int, int> coordinates, int value = 0)
        {
            this.Coordinates = coordinates;
            this.Value = value;
            this.PossibleValues = new SortedSet<int>();
            this.TemporaryCages = new List<Cage>();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
