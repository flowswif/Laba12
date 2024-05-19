using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using Laba10;

namespace Laba12_1_2
{
    public class Point<T> where T : new()
    {
        public T Data { get; set; }
        public Point<T> Next { get; set; }
        public Point<T> Pred { get; set; }
        public static Point<T> MakeRandomData()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).IRandomInit();
            }
            else
            {
                throw new Exception("Type T does not implement the Ilist interface");
            }
            return new Point<T>(data);
        }
        public static T MakeRandomItem()
        {
            T data = new T();
            if (data is IInit)
            {
                (data as IInit).IRandomInit();
            }
            else
            {
                throw new Exception("Type T does not implement the Ilist interface");
            }
            return data;
        }

        public Point()
        {
            this.Data = default(T);
            this.Pred = null;
            this.Next = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Pred = null;
            this.Next = null;
        }

        public override string ToString()
        {
            return Data == null ? "" : Data.ToString();

        }

    }
}
