using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice2__Archery
{
    class Program
    {
        static void Main(string[] args)
        {
            //Считываем файл
            string[] input = File.ReadAllLines("INPUT.TXT");

            int n = Convert.ToInt32(input[0]); //размер массива - количество участников

            //Получаем массив из очков участников
            string[] str = input[1].Replace("  ", " ").Split(' ');
            int[] point = new int[n];
            for (int i = 0; i < n; i++)
            {
                point[i] = Convert.ToInt32(str[i]);
                    }

            int winnerPoint = 0; //максимальный результат - очки победителя
            int idmax = -1; //индекс 
            for (int i = 0; i+1 < n; i++)
            {
                if (point[i] > winnerPoint) { winnerPoint = point[i]; idmax = i; }
            }

            int maxPoint = -1; // максимальный результат, который мог быть по условиям
            int winner = 0; // количество победителей

            //поиск результата, подходящего по всем условиям
            for (int i = 0; i < n - 1; i++)
            {
                if (point[i] % 10 == 5 && point[i + 1] < point[i] && winner >=1 )
                {
                    if (point[i] > maxPoint) { maxPoint = point[i]; }
                }

                if (point[i] == winnerPoint) winner++;
            }

            int k = 1;
            if (maxPoint != -1)
            {
                for (int i = 0; i < n; i++)
                {
                    if (point[i] > maxPoint) { k++; }
                }
            }//если не найдено, то вывод нуля
            else k = 0; 

            //вывод в файл
            File.WriteAllText("OUTPUT.TXT", (k).ToString());
        }
    }

}
