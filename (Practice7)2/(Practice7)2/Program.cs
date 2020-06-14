 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTask7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа, определяющая к каким из 5 замкнутых классов принадлежит " +
                "заданная булева функция\n");

            string vector = MakeVector();

            //Вывод результата
            string str = "";
            if(CheckT0(vector)) str+="T0 - множество функций, сохраняющих 0\n";
            if (CheckT1(vector)) str += "T1 - множество функций, сохраняющих 1\n";
            if (CheckL(vector)) str += "L - линейные функции\n";
            if (CheckS(vector)) str += "S - самодвойственные функции 0\n";
            if (CheckM(vector)) str += "S - самодвойственные функции 0\n";
            if (str != "") Console.WriteLine("Заданная функция принадлежит следующим замкнутым классам:\n" + str);
            else Console.WriteLine("Заданная функция не принадлежит ни одному из пяти замкнутых классов");
        }

        // Меню формирования вектора
        public static string MakeVector()
        {
            string vector="";
            Console.WriteLine("Выберите способ формирования вектора:\n1. Случайным образом\n" +
                      "2. С помощью ввода с клавиатуры");

            int option = ReadNumber("Ввод:", 1, 2); //Меню выбора. Варианта default нет, так как из метода ReadNumber
            switch (option)                         //на выходе получается чисо строго из заданных границ
            {
                case (2):
                    vector = InpVector();
                    Console.WriteLine("Сформированный вектор: " + vector);
                    break;

                case (1):
                    vector = RandomVector();
                    Console.WriteLine("Сформированный вектор: " + vector);
                    break;

            }
            return vector;
        }

        // T0
        public static bool CheckT0(string vector)
        {
            if (vector[0] == '0') return true ;
            return false;
        }

        // T1
        public static bool CheckT1(string vector)
        {
            if (vector[vector.Length - 1] == '1') return true;
            return false;
        }

        // L
        public static bool CheckL(string vector)
        {
            int[,] trianglePascal = PascalTriangleGeneration(vector);
            string polynom_vector = PolinomVectorCreate(trianglePascal);

            return Lin(polynom_vector);
        }

        // S
        public static bool CheckS(string vector)
        {
            for (int i = 0; i < vector.Length / 2; i++)
            {
                if (vector[i] == vector[vector.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        // M
        public static bool CheckM(string vector)
        {
            if (vector.Length == 1) return true;
            string v1 = vector.Substring(0, vector.Length / 2);
            string v2= vector.Substring(vector.Length / 2, vector.Length / 2);

            if (v1.Length != 1 && v2.Length != 1)
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    if ((int)v1[i] > (int)v2[i])
                        return false;
                }
                return CheckM(vector) && CheckM(vector);
            }
            else return Convert.ToInt32(v1) <= Convert.ToInt32(v2);            
        }

            //формирование вектора с помощью дсч
            public static string RandomVector()
       {
            string str = string.Empty;
            Random rnd = new Random();
            int count = rnd.Next(1, 20);
            for (int i = 0; i < count; i++)
            {
                str += Convert.ToString(rnd.Next(0, 2));
            }
            return str;
       }

       //формирование вектора
        public static string InpVector()
        {
            string str = string.Empty;
            bool ok = true;
            Console.Write("Введите вектор (последовательность из 0 и 1): ");
            do
            {
                str = Console.ReadLine();
                if (str != "")
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] != '0' && str[i] != '1')
                        {
                            ok = false;
                            Console.Write("Ошибка! Вектор задается последовательностью 0 и 1. Повторите ввод: ");
                            break;
                        }
                    }
                else
                {
                    ok = false;
                    Console.Write("Ошибка! Введена пустая строка. Повторите ввод: ");
                }
            } while (!ok);
            return str;
        }

        public static int ReadNumber(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
		{ //На выходе получаем целое число в границах от minValue до maxValue
			bool ok;
			int value;
			do
			{
				Console.Write(invitation);
				string buf = Console.ReadLine();
				ok = int.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
				if (!ok || value < minValue || value > maxValue) //Если не целое число или целое число, но не в указанных границах
					Console.WriteLine($"Неправильный формат ввода. Пожалуйста, введите число от {minValue} до {maxValue}");
			} while (!ok || value < minValue || value > maxValue);
			Console.WriteLine();
			return value;
		}

        static int[,] PascalTriangleGeneration(string vector)
        {
            int[,] matrix = new int[vector.Length, vector.Length];

            for (int i = 0; i < vector.Length; i++)
            {
                matrix[0, i] = (vector[i] - 48);
            }

            for (int i = 1; i < vector.Length; i++)
            {
                for (int j = 0; j < vector.Length - i; j++)
                {
                    if (matrix[i - 1, j] == 0)
                    {
                        if (matrix[i - 1, j + 1] == 1)
                        {
                            matrix[i, j] = 1;
                        }
                        else
                        {
                            matrix[i, j] = 0;
                        }

                    }
                    else
                    {
                        if (matrix[i - 1, j + 1] == 1)
                        {
                            matrix[i, j] = 0;
                        }
                        else
                        {
                            matrix[i, j] = 1;
                        }
                    }
                }
            }

            return matrix;
        }

        static void PascalTrianglePrint(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(' ');
                }

                for (int j = 0; j < matrix.GetLength(0) - i; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        static string PolinomVectorCreate(int[,] triangle)
        {
            string polinom = "";
            for (int i = 0; i < triangle.GetLength(0); i++)
            {
                polinom += triangle[i, 0];
            }
            return polinom;
        }
    }
}