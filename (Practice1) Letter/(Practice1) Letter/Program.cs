using System;
using System.IO;
using System.Text;

namespace _Practice1__Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Считываем файл в массив
            Encoding encoding = Encoding.GetEncoding("cp866");
            string[] input = File.ReadAllLines("INPUT.TXT", encoding);

            int k = 0;//Ширина листа
            int n=0; //Количество строк
            string[] output = new string[n];// Массив для отформатированного сообщения

            //Получаем числа k и n
            string[] numbers = input[0].Replace(" ", " ").Split(' ');
            if (Check(numbers[0], 1, 100) && Check(numbers[1], 1, 1000))
            {
                k = int.Parse(numbers[0]);
                n = int.Parse(numbers[1]);

                //Массив для отформатированного сообщения
                output = new string[n];
                char[] charsToTrim = { ' ' };

                //Удяляем ведущие и концевые пробелы в каждой строке
                for (int i = 1; i < input.Length; i++)
                {
                    input[i] = input[i].Trim(charsToTrim);
                }

                for (int i = 1; i < input.Length; i++)
                {
                    //Если длина строки сообщения не больше ширины листа
                    if (input[i].Length <= k)
                    {
                        //Добавляем в строку ведущие пробелы
                        for (int l = 0; l < (k - input[i].Length) / 2; l++)
                            output[i - 1] += " ";

                        //Добавляем в строку сообщение
                        output[i - 1] += input[i];

                        //Добавляем в строку концевые пробелы
                        for (int l = (k - input[i].Length) / 2 + input[i].Length; l < k; l++)
                            output[i - 1] += " ";
                    }
                    else
                    {
                        output = new string[1];
                        output[0] = "Impossible.";
                        break;
                    }
                }
            }
            else
            {
                output = new string[1];
                output[0] = "Impossible.";
           }

            //Вывод строки в файл
            File.WriteAllLines("OUTPUT.TXT", output, encoding);
        }

        //Проверка значений
        public static bool Check(string num, int minValue, int maxValue) // Проверка корректности ввода числа
        { //На выходе получаем целое число в границах от minValue до maxValue
            bool ok = true;
            int value ;
                string buf = num;
                ok = int.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
            if (!ok || value < minValue || value > maxValue) //Если не целое число или целое число, но не в указанных границах
                return false;
            return true;

        }
    }
}
