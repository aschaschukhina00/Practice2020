using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y;
            bool tr;

            do
            {
                Console.WriteLine("Введите кординату Х");
                tr = double.TryParse(Console.ReadLine(), out x);
                if (!tr)
                    Console.WriteLine("Введено недопустимое значение");

            }
            while (!tr);

            do
            {
                Console.WriteLine("Введите координату Y");
                tr = double.TryParse(Console.ReadLine(), out y);
                if (!tr)
                    Console.WriteLine("Введено недопустимое значение");
            }
            while (!true);

            bool output = isOwned(x, y);
            if (output)
            {
                Console.WriteLine("Точка (" + x + ";" + y + ") принадлежит заданной области");
            }
            else
            {
                Console.WriteLine("Точка (" + x + ";" + y + ") не принадлежит заданной области");
            }
        }

        public static bool isOwned(double x, double y)
        {
            if ((y>=1) || (x >= -1 && y >= x) || (x<=1 && y>=x))
            {
                return true;
            }
            return false;
        }
    }
}

