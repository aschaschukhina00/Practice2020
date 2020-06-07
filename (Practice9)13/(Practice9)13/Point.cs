using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice9_13
{
    //Класс элементов списка
    class Point
    {
        public Point Next { get; set; }
        public int Element { get; set; }

        public Point(int Element)
        {
            this.Element = Element;
            this.Next = null;
        }
    }
}
