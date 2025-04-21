using static System.Console;

namespace ConsoleApp1
{
    class LSearch<T>
    {
        private T[] A;

        public LSearch() => A = null;
        public LSearch(T[] _A) => A = (T[])_A.Clone();

        public T[] Get() => A;
        public void Set(T[] _A) => A = (T[])_A.Clone();

        public bool IsItem(T[] A, T key)
        {
            foreach (var item in A)
                if (item.Equals(key))
                    return true;
            return false;
        }

        public bool IsItem(T key) => IsItem(A, key);

        public int GetNOccurences(T[] A, T key)
        {
            int count = 0;
            foreach (var item in A)
                if (item.Equals(key))
                    count++;
            return count;
        }

        public int GetNOccurences(T key) => GetNOccurences(A, key);

        public int[] GetPositions(T[] A, T key)
        {
            var positions = new System.Collections.Generic.List<int>();
            for (int i = 0; i < A.Length; i++)
                if (A[i].Equals(key))
                    positions.Add(i);
            return positions.ToArray();
        }

        public int[] GetPositions(T key) => GetPositions(A, key);

        public void Print(string comment)
        {
            WriteLine(comment);
            WriteLine(string.Join("   ", A));
        }
    }

    class Program
    {
        static void Main()
        {
            int[] AI = { 5, 8, 9, -1, 4 };
            var L1 = new LSearch<int>(AI);
            WriteLine(L1.IsItem(8) ? "Item 8 is in array AI" : "Item 8 is not in array AI");

            char[] AC = { 'a', 'b', 'f', 'a', 'a', 'c', 'd', 'i', 'f' };
            var L2 = new LSearch<char>(AC);
            WriteLine($"n = {L2.GetNOccurences('a')}");

            bool[] AB = { true, true, false, false, true, false, true, true };
            var L3 = new LSearch<bool>();
            L3.Set(AB);
            WriteLine(string.Join("   ", L3.GetPositions(true)));

            ReadLine();
        }
    }
}