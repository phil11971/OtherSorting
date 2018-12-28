using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = CycleSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        static int[] CycleSort(int[] a)
        {
            for (int cycleStart = 0; cycleStart < a.Length - 1; cycleStart++)
            {
                int val = a[cycleStart];

                // count the number of values that are smaller than val
                // since cycleStart
                int pos = cycleStart;
                for (int i = cycleStart + 1; i < a.Length; i++)
                    if (a[i] < val)
                        pos++;

                // there aren't any
                if (pos == cycleStart)
                    continue;

                // skip duplicates
                while (val == a[pos])
                    pos++;

                // put val into final position
                int tmp = a[pos];
                a[pos] = val;
                val = tmp;

                // repeat as long as we can find values to swap
                // otherwise start new cycle
                while (pos != cycleStart)
                {
                    pos = cycleStart;
                    for (int i = cycleStart + 1; i < a.Length; i++)
                        if (a[i] < val)
                            pos++;

                    while (val == a[pos])
                        pos++;

                    tmp = a[pos];
                    a[pos] = val;
                    val = tmp;
                }
            }
            return a;
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
