using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] o = { 1, 2, 3, 4, 5, 6 };
            int[] oo = { 1, 2, 3, 4, 5, 6, 7 };
            DynamicArray<int> list = new DynamicArray<int>(o);
            Print(list);
            list.AddRange(oo);
            Print(list);
            list.Remove(3);
            Print(list);
            list.Insert(18, 0);
            list.Insert(18, list.Lenght / 2);
            list.Add(18);
            Print(list);
            Console.WriteLine(list.Remove(9));
        }

        static void Print(DynamicArray<int> list)
        {
            foreach (var a in list)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
    }
}
