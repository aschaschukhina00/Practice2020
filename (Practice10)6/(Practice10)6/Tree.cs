using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice10_6
{
    class Tree
    {

        //Класс узла дерева
        public class Point
        {
            public int Data;
            public Point Left { get; set; }
            public Point Right { get; set; }

            public Point(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }

            public int Value()
            {
                if (Right == null && Left == null)
                    return 1;

                if (Left == null)
                    return Right.Value() + 1;

                if (Right == null)
                    return Left.Value() + 1;
                return Math.Max(Right.Value(), Left.Value()) + 1;
            }

            //Список для уровней
            public List<int> levels(int i)
            {
                if (i == 0)
                    return new List<int> { Data };

                var l = new List<int>(0);

                if (Left != null)
                    l.AddRange(Left.levels(i - 1));
                if (Right != null)
                    l.AddRange(Right.levels(i - 1));               
                return l;
            }

        }
        public Point Root;

        public List<int> Levels(int levels)
        {
            return Root.levels(levels);
        }

        public int Value => Root.Value();

        //Констрктор без параметра
        public Tree() 
        {
            Root = null;
        }

        //Конструктор с параметром
        public Tree(int value)
        {
            Root = new Point(value); 
        }

        //Добавление
        public void AddElement(int data)
        {
            //Если элемент не существует, то генерируем новый и добавляем
            if (Root == null) 
            {
                Root = new Point(data);
                return;
            }

            Point current = Root;
            bool add = false;

            //Обход дерева
            do
            {
                //Влево
                if (data >= current.Data)
                {
                    if (current.Right == null)
                    {
                        current.Right = new Point(data);
                        add = true;
                    }
                    else current = current.Right;                  
                }

                //Вправо
                if (data < current.Data)
                {
                    if (current.Left == null)
                    {
                        current.Left = new Point(data);
                        add = true;
                    }
                    else current = current.Left;                    
                }
            } while (!add);
        }

        //Формирование дерева
        public static void MakeTree(int[] data, Tree tree)
        {
            foreach (var tr in data) tree.AddElement(tr);            
        }

        //Печать дерева
        public static void WriteTree(Point p, int size)
        {
            if (p != null)
            {
                //Переход к левому поддереву
                WriteTree(p.Left, size + 4);
                for (int i = 0; i < size; i++) Console.Write("  ");
                Console.WriteLine(p.Data);

                //Переход к правому поддереву
                WriteTree(p.Right, size + 4);
            }
        }

        private int[] levelPoints;

        //Подсчет уровней
        public int[] LevelPoints()
        {
            levelPoints = new int[Value];

            var result = new List<int>(0);
            for (int i = 0; i < Value; i++)
            {
                result.AddRange(Levels(i));
                levelPoints[i] = Root.levels(i).Count;
            }
            return levelPoints;
        }


    }
}
