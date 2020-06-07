using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice9_13
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Программа для работы с циклическим списком: ");
            int menu;
            do
            {
                Console.WriteLine("1. Создать циклический список\n" +
                                  "2. Найти элемент\n" +
                                  "3. Удалить элемент\n" +
                                  "4. Выход из программы");

                menu = ReadNumber("Ввод: ", 1, 4); //Меню выбора
                switch (menu)
                {
                    case (1):
                        //Получаем N
                        int N = ReadNumber("Введите N: ", 2, 999);
                        MakeList(N);
                        Console.WriteLine();
                        break;
                    case (2):
                        if (List.End == null) Console.WriteLine("Ошибка! Необходимо создать список.");
                        else
                        {
                            //Ввод элемента для поиска
                            int el = ReadNumber("Введите элемент для поиска: ", 1, 999);

                            //Поиск элемента
                            Point searchedEl = List.Search(List.Begin, List.End, el);

                            //Если элемент пустой, то вывод сообщения об отсутсвии искомого элемента в списке
                            //
                            if (searchedEl.Next == null)
                                Console.WriteLine("Искомый элемент не существует в списке");
                            else
                                Console.WriteLine("Элемент успешно найден");
                            Console.WriteLine();
                        }
                            break;
                    case (3):
                        if (List.End == null) Console.WriteLine("Ошибка! Необходимо создать список.");
                        else
                        {
                            //Ввод элемента для удаления
                            int elem = ReadNumber("Введите элемент для удаления из списка: ", 1, 999);

                            //Новый список
                            List.End = List.Delete(List.Begin, List.End, elem, List.End);
                            List.Write();
                            Console.WriteLine();
                        }
                        break;                       
                }

            } while (menu < 4);


        }
    
        public static void MakeList(int N)
        {
            //Создаем список
            Console.WriteLine("Создание списка: ");
            List list = new List();
            List.CreateList(N);
            List.Write();
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
    }
}
