using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    struct Wave
    {
        List<int> points;
        public int Cost { get; set; }
        public int Previous { get; set; }
        public int Position { get; set; }
        public List<int> Points => points;

        public Wave(int position, int previous, int cost)
        {
            Cost = cost;
            Position = position;
            Previous = previous;
            points = new List<int>();
            points.Add(position);
        }

        public Wave(int position, int previous, int cost, List<int> points)
        {
            Cost = cost;
            Position = position;
            Previous = previous;
            this.points = points;
        }

        public void AddPoint (int point)
        {
            points.Add(point);
        }
    }
}
