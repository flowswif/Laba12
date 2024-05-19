using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12_3
{
    public class Point<T> : IComparable<Point<T>> where T : IComparable
    {
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }

        public Point()
        {
            this.Data = default(T);
            this.Left = null;
            this.Right = null;
        }

        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public override string ToString()
        {
            return Data?.ToString() ?? "";
        }

        public int CompareTo(Point<T>? other)
        {
            if (other == null) return 1; // если other равен null, текущий объект больше
            return Data.CompareTo(other.Data);
        }
    }
}
