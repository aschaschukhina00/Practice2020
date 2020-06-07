using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice9_13
{
    //Класс цклического списка
    class List
    {
        //Начало списка
        public static Point Begin { get; set; }

        //Конец списка
        public static Point End { get; set; }

        public List()
        {
            Begin = null;
            End = null;
        }

        //Создание циклического списка из N элементов
        public static void CreateList(int N)
        {
            Point begin = new Point(N);
            Point end = new Point(1);

            // Объединяем начало и конец списка, чтобы получить циклический список
            begin.Next = end;
            end.Next = begin;

            //Добавляем элементы в список
            Add(N - 1, begin,end);

            Begin = end.Next;
            End = end;
        }

        //Добавление элементов в список
        public static void Add(int N, Point beg, Point end)
        {
            if (N == 1)
            {
                return;
            }
            else
            {
                //buf - временная переменная
                Point buf = new Point(N);

                //Ставим временную переменную между началом и концом
                beg.Next = buf;
                buf.Next = end;

                //Добавляем следующий элемент, смещая начало
                Add(N - 1, buf, end);
            }
        }

        //Печать списка
        public static void Write()
        {
            Console.Write("Список: ");
            Point curEl = Begin;
            do
            {
                Console.Write(curEl.Element + "  ");
                curEl = curEl.Next;
            } while (curEl != Begin);
        }

        //Поиск элемента в списке
        public static Point Search(Point currentEl, Point end, int element)
        {
            if ((currentEl.Element == end.Element && currentEl.Next == end.Next) || currentEl.Element == element)
            {
                if (currentEl.Element == element) return currentEl;
                else return new Point(0); //Если элемент не найден, то создается пустой объект
            }
            else
            {
                Point searched = Search(currentEl.Next, end, element);
                return searched;
            }
        }

        // Удалеие элемента
        public static Point Delete(Point currentEl, Point end, int element, Point previous)
        {
            if ((currentEl.Element == end.Element && currentEl.Next == end.Next) || currentEl.Element == element)
            {
                //Если элемент найден, то удаляем его, сдвигая элементы списка. Иначе- сообщение об ошибке
                if (currentEl.Element == element)
                {
                    previous.Next = currentEl.Next;
                                        Console.WriteLine("Удаление элемента произведено успешно");

                }
                else Console.WriteLine("Ошибка! Заданный элемент не существует в списке");

                return end;
            }
            else
            {
                Point delete = Delete(currentEl.Next, end, element, previous.Next);
                return delete.Next;
            }
        }

    }

}
