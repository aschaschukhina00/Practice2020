using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice10_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = null;
            int size = 0;
            Console.WriteLine("Программа предназначена для обхода дерева по ярусам\nВыберите:\n1.Сформировать дерево\n2.Напечатать дерево\n" +
                "3.Посчитать количество уровней и вершин\n4.Выход");
            var menu1 = Read("Ввод: ", 1, 4);
            do
            {
                switch (menu1)
                {
                    case 1:
                        //Задание массив, из которого будет сформировано дерево
                        size = Read("Введите количество элементов в дереве: ", 2, 100);
                        int[] arr = new int[size];
                        Console.WriteLine("Выбор способа ввода элементов дерева:\n1.С помощью датчика случаных чисел\n" +
                "2.Ввести с клавиатуры");
                        var menu2 = Read("Ввод: ", 1, 2);
                        switch (menu2)
                        {
                            case 1:
                                InpRandom(size, arr);
                                break;
                            case 2:
                                InpHand(size, arr);
                                break;
                        }

                        //Формирование дерева
                        tree = new Tree();
                        Tree.MakeTree(arr, tree);
                        Console.WriteLine("Дерево успешно сформировано");
                        break;
                    case 2:
                        if (tree != null)
                        {
                            //Печать дерева
                            Console.WriteLine("Дерево: ");
                            Tree.WriteTree(tree.Root, size);
                        }
                        else Console.WriteLine("Необходимо сфoрмировать дерево");
                        break;
                    case 3:
                        if (tree != null)
                        {
                            //Количество ярусов и вершин
                            Console.WriteLine($"Количество ярусов в дереве: {tree.Value}");
                        int[] k = tree.LevelPoints();
                        for (var i = 0; i < tree.Value; i++)
                            Console.WriteLine($"Количество вершин на ярусе {i + 1} равно {k[i]}");
                        Console.ReadKey(true);
                        }
                        else Console.WriteLine("Необходимо сфoрмировать дерево");
                        break;
                }
            } while (menu1 != 4);
        }

        //С помощью ДСЧ
        public static void InpRandom(int size, int[]arr)
        {
            Random rnd = new Random();
            for (var i = 0; i < size; i++)
                arr[i] = rnd.Next(-100, 100);
        }

        //Ввод с клавиатуры
        public static void InpHand(int size, int[] arr)
        {
            for (var i = 0; i < size; i++)
            {
                arr[i] = Read($"Введите значение {i + 1} элемента", -100, 100);
            }
        }

        public static int Read(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
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
