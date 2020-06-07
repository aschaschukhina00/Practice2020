using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice4_119a
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = Input();
            double sum = Summ(e);
            Console.WriteLine("Ответ:" + sum);
        }

        public static double Summ(double e)
        {
            double sum =0;
            double cur = 0;
            int i = 1;
            do
            {
                cur = 1 / (Math.Pow(i, 2));
                sum += cur;
                i++;
            } while (Math.Abs(cur) >= e);
            return sum;
        }

        public static double Input()
        {
            double e = 0;
            bool tr;
            do
            {
                Console.WriteLine("Введите точность");
                tr = double.TryParse(Console.ReadLine(), out e);
                if (!tr && e<0)
                    Console.WriteLine("Ошибка! Введите положительное число");

            }
            while (!tr);

            return e;
        }
    }
}
