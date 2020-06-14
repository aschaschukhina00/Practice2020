using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice8_27
{
    class Program
    {

        public static Random rnd = new Random();
        public static int count=0;
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("Программа для поиска клики заданного размера");

            List<char> top = new List<char>();
            List<string> edge = new List<string>();

            do
            {
                Console.WriteLine("1. Сформировать граф\n" +
                                  "2. Найти клику размерности K\n" +
                                  "3. Выход из программы");

                option = ReadNumber("Ввод:", 1, 3); //Меню выбора. Варианта default нет, так как из метода ReadNumber
                switch (option)                         //на выходе получается число строго из заданных границ
                {
                    case (1):
                        CreateGraph(top,edge);

                        foreach (string l in edge)
                            Console.Write(l + " ");
                        Console.WriteLine();
                        break;
                    case (2):
                        if (top == null) Console.WriteLine("Ошибка! Необходимо сформировать граф");
                        else
                        {
                            clique = "";
                            count = 0;
                            SearchK(top, edge);
                        }
                        break;

                }
            } while (option != 3);


        }

        //Вывод искомой клики
        public static void KPrint(int K)
        {
            if (clique == "")
                Console.WriteLine($"Клики размера {K} не существует в графе");
            else
            {
                Console.Write("В графе найдеa кликa размера " + K +": ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(clique[i]);
                }
                Console.WriteLine();
            }
        }

        //Поиск клики
        public static void SearchK(List<char> top, List<string> edge)
        {            
            int K ;
            int count_edge;

                Console.WriteLine("Введите число вершин (К) искомой клики");
                K = ReadNumber("Ввод К: ", 2, top.Count);
                count_edge = K * (K - 1) / 2;
                if (count_edge > edge.Count)
                    Console.WriteLine("Заданная клика отсутствует в графе"); //Мало рёбер

            int end;
            if (K == 2)
                end = edge.Count - 1;
            else
                end = edge.Count - K;
            Recursion(edge, K, count_edge, end, 0, "");
           KPrint(K);

        }
        public static string clique = "";

        //Рекурсия
        public static string Recursion(List<string> edge, int K, int count_edge, int end, int begin, string set)
        {
            if (clique == "")
            {
                //Если в set лежит необходимое количество ребер, то проверяем их на наличие необходимой клики
                if (count_edge == 0)
                {
                    Check(set, K);
                    return "";
                }
                else
                {
                    // если end вышел за пределы индекса.
                    if (end >= edge.Count)
                        end = edge.Count - 1;

                    //Перебираем строки
                    for (int i = begin; i <= end; i++)
                    {
                        set += edge[i];

                        //Переход к следующему ребру (строке)
                        set += Recursion(edge, K, count_edge - 1, end + 1, i + 1, set);

                        //Замена линий
                        set = set.Substring(0, set.Length - 2);

                    }
                }
            }
            return "";
            
        }

        public static char[] top = null;

        //Проверка набора граней на необходимую клику
        public static void Check(string set, int K)
        {
            top = set.ToCharArray(); //Массив вершин

            //Сортировка
            Array.Sort(top);

            bool ok = true;

            for (int i = 0; i < top.Length; i += K - 1)
            {
                //Рассматриваем буквы: для клика необходимо чтобы количество каждой буквы совпадали
                for (int j = i; j < i + K - 2; j++)
                {
                    if (top[j] != top[j + 1])
                    {
                        ok = false;
                        break;
                    }
                }
                if (!ok)
                    break;
            }

            //Найденная клика сохраняется
            if (ok)
            {
                for (int i = 0; i < top.Length; i += K - 1)
                {
                    clique += top[i];
                }
                clique += " ";
                count++;

            }
        }

        //Ввод числового значения
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

        //Формирование графа
        public static void CreateGraph(List<char> top , List<string> edge)
        {       
            Console.WriteLine("Формирование графа.....................");

            //Ввод вершин графа
            Console.WriteLine("Введите список вершин графа.\nВершины графа обозначаются ТОЛЬКО буквами. " +
                "После ввода каждой вершины нажмите ENTER.\nДля окончания ввода введите 0\nВвод: ");
            do
            {
                top.Add(ImpTop());
            }
            while (top.Last().ToString() != "0");

            // Удаление нуля
            top.Remove(top.Last());

            Console.WriteLine("Введите список ребер графа. \n Ребра графа обозначаются двумя буквами без пробела. " +
                "После ввода каждого ребра нажмите ENTER.\nДля окончания ввода введите 0\nВвод: ");
            do
            {
                edge.Add(ImpEdge(top));
            }
            while (edge.Last() != "0");

            // Удаление нуля
            edge.Remove(edge.Last());


            //Сортировка
            top.Sort();
            edge.Sort();

            //Удаление дубликатов
            top.Distinct();
            edge.Distinct();

            DeletePolinomail(edge);

        }

        //Ввод вершин
        public static char ImpTop()
        {
            bool ok;
            char point;

            do
            {
                string input = Console.ReadLine();

                //Проверка на ввод только одного символа
                
            ok = char.TryParse(input, out point);
                if (!ok) Console.Write("Ошибка! Необходимо ввести одну букву\nПовторите ввод: ");

                //Проверка на ввод букв
                ok = char.IsLetter(point);
                if (!ok && point.ToString() != "0") Console.Write("Ошибка! Необходимо ввести букву\nПовторите ввод: ");

                //Проверка на окончание ввода
                if (point.ToString() == "0") ok = true;
            }
            while (!ok);

            return point;
        }

        //Ввод ребер
        public static string ImpEdge(List<char> list)
        {
            bool ok;
            string point;

            do
            {
                point = Console.ReadLine();

                //Проверка на два символа
                ok = point.Length == 2;
                if (!ok && point.ToString() != "0") Console.Write("Ошибка! Запись ребра должна состоять из двух букв\nПовторите ввод: ");

                //Проверка на наличие введенных вершин в ребре
                if ((!(list.Contains(point[0])) || !(list.Contains(point[1]))) && point.ToString() != "0")
                {
                    ok = false;
                    Console.Write("Ошибка! Запись ребра должна состоять из и введеных ранее вершин\nПовторите ввод: ");
                }

                //Проверка на окончание ввода
                if (point == "0") ok = true;
            }
            while (!ok);

            return point;
        }

        //Удаление полиномов
        public static void DeletePolinomail(List<string> edge)
        {
            List<string> edge2 = new List<string>() ;

            List<string> reverse = edge;
            edge2.Add(edge[0]);
            int size = edge2.Count;
            //Переворачиваем все строки в списке
            for (int i = 0; i< reverse.Count; i++)
            {
                char[] str = reverse[i].ToCharArray();
                Array.Reverse(str);
                reverse[i] = new string(str);
            }

            int j;
            for (int i = 1; i < edge.Count; i++)
            {
                for ( j = 0; j < size; j++)
                {
                    if (edge2[j] == reverse[i]) break;
                }

                if (j == size)
                { edge2.Add(edge[i]);
                    size++;
                }
            }

            edge.Clear();
            edge.AddRange(edge2);
        }
    }
}

