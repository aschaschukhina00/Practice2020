using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Practice12_1_11
{
    class Program
    {
        public static int countMove = 0;//Количество перемещений
        public static int countComp = 0;//Количество сравнений


        static void Main(string[] args)
        {
            Console.WriteLine("Формирование первого массива");
            double[] arr = CreateArray();
            Console.WriteLine("Формирование второго массива");
            double[] arr2 = CreateArray();
            Console.WriteLine("Сортировка пузырьком:");
            Sort1(arr);
            Console.WriteLine("Пирамидальная сортировка:");
            Sort2(arr2);
            Console.ReadKey();
        }

        //Создание массива
        public static double[] CreateArray() 
        {
            Random rnd = new Random();
            PrintCreatingMenu(out int size, out int option); //Выводим меню с выбором способа формирования массива и размера
            double[] array = new double[size];
            int i;
            if (option == 2) //Если выбрана генерация с использованием дсч
                for (i = 0; i < size; i++) array[i] = rnd.Next(-100, 100);
            else //Если выбран ввод с клавиатуры
                for (i = 0; i < size; i++) array[i] = ReadNumberDouble($"Введите элемент массива под номером {i + 1}: ", -100, 100);

            return array;
        }

        public static int ReadNumberInt(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
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

        public static double ReadNumberDouble(string invitation, int minValue, int maxValue) // Проверка корректности ввода числа
        { //На выходе получаем целое число в границах от minValue до maxValue
            bool ok;
            double value;
            do
            {
                Console.Write(invitation);
                string buf = Console.ReadLine();
                ok = double.TryParse(buf, out value); //Проверяем, ввели ли нам целое число
                if (!ok || value < minValue || value > maxValue) //Если не число или число, но не в указанных границах
                    Console.WriteLine($"Неправильный формат ввода. Пожалуйста, введите число от {minValue} до {maxValue}");
            } while (!ok || value < minValue || value > maxValue);
            Console.WriteLine();
            return value;
        }


        public static void PrintCreatingMenu(out int size, out int option) //Меню для выбора способа формирования массива и размера
        {
            Console.WriteLine("Каким образом вы хотите задать элементы массива?");
            option = ReadNumberInt("1. Вручную с клавиатуры\n2. С помощью датчика случайных чисел\nВвод: ", 1, 2);
            size = ReadNumberInt("Введите размер массива: ", 1, 1000);
        }

        //Работа с сортировкой пузырьком
        static void Sort1(double[] array)
        {
            //Сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: " + String.Join(", ", array));
            countComp = 0;
            countMove = 0;
            double[] sortArr = BubbleSorting(array);
            Console.WriteLine("Неупорядоченный массив:  " + String.Join(", ", sortArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");

            //Сортировка упорядоченного по возрастанию массива
            countComp = 0;
            countMove = 0;
            double[] increaseArr = BubbleSorting(sortArr);
            Console.WriteLine("Массив отсортированный по возрастанию: " + String.Join(", ", increaseArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");

            //Сортировка упорядоченного по убыванию массива
            countComp = 0;
            countMove = 0;
            double[] decreaseArr = BubbleSorting(Reverse(increaseArr));
            Console.WriteLine("Массив отсортированный по убыванию массив: " + String.Join(", ", decreaseArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");

        }

        //Работа с пирамидальной сортировкой
        static void Sort2(double[] array)
        {
            //Сортировка неупорядоченного массива
            Console.WriteLine("Несортированный массив: " + String.Join(", ", array));
            countComp = 0;
            countMove = 0;
            double[] sortArr = PyramidSorting(array, array.Length);
            Console.WriteLine("Неупорядоченный массив: " + String.Join(", ", sortArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");

            //Сортировка упорядоченного по возрастанию массива
            countComp = 0;
            countMove = 0;
            double[] increaseArr = PyramidSorting(sortArr, array.Length);
            Console.WriteLine("Массив отсортированный по возрастанию: " + String.Join(", ", increaseArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");

            //Сортировка упорядоченного по убыванию массива
            countComp = 0;
            countMove = 0;
            double[] decreaseArr = PyramidSorting(Reverse(increaseArr), array.Length);
            Console.WriteLine("Массив отсортированный по убыванию массив: \n" + String.Join(", ", decreaseArr));
            Console.WriteLine($"{countMove} пересылок, {countComp} сравнений");
        }

        public static double[] Reverse(double[] array)
        {
            Array.Reverse(array);
            return array;
        }

        //Пирамидальная сортировка
        public static double[] PyramidSorting(double[] array, int size)
        {
            //Шаг 1 - постройка пирамиды
            for (int i = size / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(array, i, size);
                if (prev_i != i) ++i;
                countComp++;
            }

            //Шаг 2 - сортировка
            double buf;
            for (int k = size - 1; k > 0; --k)
            {
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(array, i, k);
                }
            }
            return array;
        }

        //Добавление элемента к пирамиде
        static int add2pyramid(double[] array, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (array[2 * i + 1] < array[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
                countComp = countComp + 2;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (array[i] < array[imax])
            {
                buf = array[i];
                array[i] = array[imax];
                array[imax] = buf;
                if (imax < N / 2) i = imax;
                countComp = countComp + 2;
                countMove++;

            }
            return i;
        }

        //Сортировка пузырьком
        public static double[] BubbleSorting(double[] array)
        {
            double temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        countMove ++;
                    }
                    countComp++;
                }
            }
            return array;
        }
    }
}
