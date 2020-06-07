using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice11_841
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с зашифрованными сообщениями.Выберите: " +
                "\n1.Расшифровать полученное сообщение\n2.Зашифровать сообщение\n3.Закрыть программу");

            int menu = ReadNumber(1, 3);

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Расшифровка сообщения...............");
                        TranscriptMessage();
                        break;
                    case 2:
                        Console.WriteLine("Зашифровка сообщения...............");
                        EncryptionMessage();
                        break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void EncryptionMessage()
        {
            string inpMessage;

            // сообщение
            Console.Write("Введите сообщение, состоящее из 0 и 1: ");
            do
            {
                inpMessage = Console.ReadLine();
                if (!Check(inpMessage))
                    Console.WriteLine("Ошибка! Строка может состоять только из символов 0 и 1. Повторите ввод");
            } while (!Check(inpMessage));

            string message = Encryption(inpMessage);
            Console.WriteLine($"Исходное сообщение: {inpMessage}\nЗашифрованное сообщение: {message}");

        }

        public static string Encryption(string inp)
        {
            string message = "";
            int summ = 0;

            for (int i = 0; i < inp.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    message += inp[i];
                }
            }
            return message;
        }

        public static void TranscriptMessage()
{
        string inpMessage;

        //Получение сообщения
        Console.Write("Введите сообщение, состоящее из 0 и 1: ");
        do
        {
            inpMessage = Console.ReadLine();
            if (inpMessage.Length % 3 != 0)
                Console.WriteLine("Ошибка! Количество символов должно быть кратно трем. Повторите ввод");
            if (!Check(inpMessage))
                Console.WriteLine("Ошибка! Строка может состоять только из символов 0 и 1. Повторите ввод");
        } while (inpMessage.Length % 3 != 0 || !Check(inpMessage));

        string message = Transcript(inpMessage);//Верное сообщение

        Console.WriteLine($"Полученное сообщение: {inpMessage}\nРасшивровка: {message}");
    }
        //
        public static bool Check(string m)
        {
            for (int i=0;i<m.Length;i++)
            {
                if (m[i] != '0' && m[i] != '1') return false;
            }
            return true;
        }

        //Расшифровка
        public static string Transcript(string inp)
        {
            string message = "";
            int summ = 0;
            //Двигаемся по тройкам
            for (int i = 0; i < inp.Length; i = i + 3)
            {
                for (int j = i; j < i + 3; j++)
                {
                    if (inp[j] == '1')
                        summ++;
                }

                //Если сумма больше единицы, значит в тройке точно не менее двух единиц
                if (summ > 1) message += "1";
                else message += "0";

                summ = 0;
            }
            return message;
        }

        public static int ReadNumber(int minValue, int maxValue) // Проверка корректности ввода числа
        { //На выходе получаем целое число 
            bool ok;
            int value;
            do
            {
                string buf = Console.ReadLine();
                ok = int.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
                if (!ok || value < minValue || value > maxValue) 
                    Console.WriteLine($"Неправильный формат ввода");
            } while (!ok || value < minValue || value > maxValue);
            Console.WriteLine();
            return value;
        }
    }
}
