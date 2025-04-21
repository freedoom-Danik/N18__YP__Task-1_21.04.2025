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
            A = (T[])_A.Clone();
        }
        public T[] Get()
        {
            return A;
        }
        public void Set(T[] _A)
        {
            A = (T[])_A.Clone();
        }
        public bool IsItem(T[] A, T key)
        {
            for (int i = 0; i < A.Length; i++)
                if (A[i].Equals(key)) // проверка, равны ли значения объектов
                    return true;
            return false;
        }
        public bool IsItem(T key)
        {
            return IsItem(this.A, key);
        }
        public int GetNOccurences(T[] A, T key)
        {
            int k = 0;
            for (int i = 0; i < A.Length; i++)
                if (A[i].Equals(key))
                    k++;
            return k;
        }
        public int GetNOccurences(T key)
        {
            return GetNOccurences(this.A, key);
        }
        public int[] GetPositions(T[] A, T key)
        {
            int[] AP = new int[0]; // вначале в массиве 0 элементов
            int[] AP2; // вспомогательный массив
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i].Equals(key))
                {
                    try
                    {
                        AP2 = new int[AP.Length + 1];
                        AP.CopyTo(AP2, 0);
                        AP2[AP.Length] = i;
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
        public int[] GetPositions(T key)
        {
            return GetPositions(this.A, key);
        }
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
            int[] AI = { 5, 8, 9, -1, 4 };
            LSearch<int> L1 = new LSearch<int>(AI);
            if (L1.IsItem(8))
                WriteLine("Item 8 is in array AI");
            else
                WriteLine("Item 8 is not in array AI");
            char[] AC = { 'a', 'b', 'f', 'a', 'a', 'c', 'd', 'i', 'f' };
            LSearch<char> L2 = new LSearch<char>(AC);
            int n = L2.GetNOccurences('a');
            WriteLine("n = {0}", n); // n = 3
            bool[] AB = { true, true, false, false, true, false, true, true }; // массив
            LSearch<bool> L3 = new LSearch<bool>(); // вызывается конструктор без параметров
            L3.Set(AB); // Метод Set() - установить новый массив
            int[] Positions = L3.GetPositions(true);
            for (int i = 0; i < Positions.Length; i++)
            {
                Write("{0}   ", Positions[i]);
            }
            WriteLine();
            ReadLine();
        }

    }
}