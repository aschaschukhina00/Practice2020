using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice6_7
{

    class Program
    {
        public static int size = 0;
        static void Main(string[] args)
        {
            double M;
            int N;

            M = ReadNumberDouble("Введите M:",1,100);
            N = ReadNumberInt("Введите N (ожидаемое количество элементов в последовательности:",4,100);
            double[] aJ = new double[101];
            aJ[0] = ReadNumberDouble($"Введите а1 :", -100, 100);
            aJ[1] = ReadNumberDouble($"Введите а1 :", -100, 100);
            aJ[2] = ReadNumberDouble($"Введите а1 :", -100, 100);

            int cur = 2;
            MakeSequence(aJ[2], M, aJ, cur);

            Console.Write("Последовательность: ");
            Input(aJ,size);

            if (aJ[size-1] == M)
                Console.WriteLine($"Последний элемент последовательности a(j) равен M");
            else
                Console.WriteLine($"Последний элемент последовательности a(j) не равен M");

            int J = size;

            // Сравнение
            if (N > J)
                Console.WriteLine("N > J. Ожидаемое количество элементов больше, чем реальное");
            if (N == J)
                Console.WriteLine("N = J. Ожидаемое количество элементов совпадает с реальным");
            if (N < J)
                Console.WriteLine("N < J. Ожидаемое количество элементов меньше, чем реальное");

        }

        public static double ReadNumberDouble(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
        { //На выходе получаем целое число в границах от minValue до maxValue
            bool ok;
            double value;
            do
            {
                Console.Write(invitation);
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
                if (!ok || value < minValue || value > maxValue) //Если не число или число, но не в указанных границах
                    Console.WriteLine($"Неправильный формат ввода. Пожалуйста, введите число от {minValue} до {maxValue}");
            } while (!ok || value < minValue || value > maxValue);
            Console.WriteLine();
            return value;
        }

        public static int ReadNumberInt(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
        { //На выходе получаем целое число в границах от minValue до maxValue
            bool ok;
            int value;
            do
            {
                Console.Write(invitation);
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
                if (!ok || value < minValue || value > maxValue) //Если не число или число, но не в указанных границах
                    Console.WriteLine($"Неправильный формат ввода. Пожалуйста, введите целое число от {minValue} до {maxValue}");
            } while (!ok || value < minValue || value > maxValue);
            Console.WriteLine();
            return value;
        }


        static double MakeSequence(double a, double M, double[] aJ, int cur)
        {
            if (Math.Abs(a) > M)
            {
                // Рекурсия
                while (Math.Abs(a) > M)
                {
                    a = (3 * aJ[cur]) / 2 - (2 * aJ[cur - 1]) / 3 - (aJ[cur - 2] / 3);// Вычисляем а
                    aJ[cur + 1] = a;
                    cur = cur + 1;
                    MakeSequence(aJ[cur - 1], M, aJ, cur);
                }
                size = cur + 1;
            }
            else
            {
                size = cur + 1;
            }
            return size;
        }

        static void Input(double[]a, int end)
        {
            for (int i = 0; i < end; i++) Console.Write("{0:0.###}  ", a[i]);
        }
    }
}

