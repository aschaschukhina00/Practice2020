using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice5_402b
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            //Ввод n
            int n = Input();

            // Формирование матрицы
            int[,] matrix = new int[n, n];

            // Массив для последовательности b
            int[] b = new int[n];

            //Формирование матрицы
            Matrix(matrix, b);

            Console.Clear();
            OutputMatrix(matrix);

            // Печать последовательности
            Output(b);
        }

        // Печать последовательности
        public static void Output(int[] b)
        {
            Console.Write("Последовательность: ");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
        }

        // Печать матрицы
        public static void OutputMatrix(int[,] m)
        {
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    // Вывод элемента матрицы на экран
                    Console.Write(m[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //Ввод n
        public static int Input()
        {
            int n;
            bool ok;
            do
            {
                Console.Write("Введите n: ");
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok || n < 2)
                    Console.WriteLine("Ошибка! Введите натуральноe число больше 1");
            } while (!ok || n < 2);
            return n;
        }

        //Выбор способа формирования матрицы
        public static int InpMethod()
        {
            Console.WriteLine("Выберите способ формирование матрицы:\n1.С помощью ручного ввода\n2.С помощью ДСЧ");
            int n;
            bool ok;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok || n > 2 || n < 1)
                    Console.WriteLine("Ошибка! Введите число 1 или 2");
            } while (!ok || n > 2 || n < 1);
            return n;
        }
        
        public static int Read(int i, int j)
        {
            Console.WriteLine($"Ввведите элемент {i+1}.{j+1}"); 
            int n;
            bool ok;
            do
            {
                ok = Int32.TryParse(Console.ReadLine(), out n);
                if (!ok)
                    Console.WriteLine("Ошибка! Ввведите целочисленное значение");
            } while (!ok);
            return n;
        }

        //Формирование матрицы
        public static void Matrix(int[,] matrix, int[] b)
        {
            Console.WriteLine("Формирование матрицы.................");
           int method=InpMethod();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //Возрастает?
                bool increase = true;

                //Убывает?
                bool decraese = true;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (method == 2)
                        matrix[i, j] = rnd.Next(-100, 101);
                    else matrix[i, j] = Read(i,j);

                    if (j > 0)
                    {
                        // Если текущий элемент больше чем предыдущий - не убывает
                        if (matrix[i, j] >= matrix[i, j - 1])
                            decraese = false;

                        // Если текущий элемент меньше чем предыдущий - не возрастает
                        if (matrix[i, j] <= matrix[i, j - 1])
                            increase = false;
                    }
                }

                if (decraese || increase)
                    b[i] = 1;
                else b[i] = 0;
            }
        }
    }
}
