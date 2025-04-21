using static System.Console;

namespace ConsoleApp1
{
    class LSearch<T>
    {
        private T[] A;

        public LSearch()
        {
            A = null;
        }

        public LSearch(T[] _A)
        {
            // Использовать метод Clone()
            A = (T[])_A.Clone();
        }

        public T[] Get()
        {
            return A;
        }

        // Установить новый массив
        public void Set(T[] _A)
        {
            A = (T[])_A.Clone();
        }
        // Методы, которые реализуют линейный поиск
        // Определение наличия заданного элемента в массиве
        public bool IsItem(T[] A, T key)
        {
            for (int i = 0; i < A.Length; i++)
                if (A[i].Equals(key)) // проверка, равны ли значения объектов
                    return true;
            return false;
        }

        // Перегруженный вариант метода IsItem, в котором обрабатывается внутренний массив.
        public bool IsItem(T key)
        {
            return IsItem(this.A, key);
        }

        // Реализация метода для любого внешнего массива
        public int GetNOccurences(T[] A, T key)
        {
            int k = 0;
            for (int i = 0; i < A.Length; i++)
                if (A[i].Equals(key))
                    k++;
            return k;
        }

        // Реализация метода для внутреннего массива
        public int GetNOccurences(T key)
        {
            return GetNOccurences(this.A, key);
        }

        // Получить массив позиций вхождения элемента в массиве
        public int[] GetPositions(T[] A, T key)
        {
            int[] AP = new int[0]; // вначале в массиве 0 элементов
            int[] AP2; // вспомогательный массив

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i].Equals(key))
                {
                    // Выделить память для нового массива на 1 элемент больше
                    try
                    {
                        AP2 = new int[AP.Length + 1];

                        // Скопировать AP => AP2 - использовать метод CopyTo()
                        AP.CopyTo(AP2, 0);

                        // Добавить последний элемент
                        AP2[AP.Length] = i;

                        // Перенаправить ссылку
                        AP = AP2;
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                    }
                }
            }

            return AP;
        }

        // Перегруженная версия метода GetPositions()
        public int[] GetPositions(T key)
        {
            return GetPositions(this.A, key);
        }

        // Метод вывода массива на экран
        public void Print(string comment)
        {
            WriteLine(comment);
            for (int i = 0; i < A.Length; i++)
                Write("{0}   ", A[i]);
            WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Тестирование класса LSearch<T>
            int[] AI = { 5, 8, 9, -1, 4 };

            // Создать экземпляр класса LSearch<int> с указанным массивом AI
            LSearch<int> L1 = new LSearch<int>(AI);

            // Определить, есть ли элемент 8. Метод IsItem()
            if (L1.IsItem(8))
                WriteLine("Item 8 is in array AI");
            else
                WriteLine("Item 8 is not in array AI");

            // Тестирование метода GetNOccurences()
            char[] AC = { 'a', 'b', 'f', 'a', 'a', 'c', 'd', 'i', 'f' };
            LSearch<char> L2 = new LSearch<char>(AC);
            int n = L2.GetNOccurences('a');
            WriteLine("n = {0}", n); // n = 3

            // Тестирование метода GetPositions()
            bool[] AB = { true, true, false, false, true, false, true, true }; // массив
            LSearch<bool> L3 = new LSearch<bool>(); // вызывается конструктор без параметров
            L3.Set(AB); // Метод Set() - установить новый массив
            int[] Positions = L3.GetPositions(true);

            // Вывести позиции значения true в массиве AB
            for (int i = 0; i < Positions.Length; i++)
            {
                Write("{0}   ", Positions[i]);
            }
            WriteLine();
            ReadLine();
        }

    }
}