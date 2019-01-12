using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            HeapSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            string[] str = { "-", "D", "a", "33" };

            Console.WriteLine("Src mas");
            foreach (var item in str)
                Console.Write(item + " ");
            Console.WriteLine();

            HeapSort(str, 0, str.Length, StringComparer.CurrentCultureIgnoreCase);

            Console.WriteLine("Res mas");
            foreach (var item in str)
                Console.Write(item + " ");
            Console.WriteLine();

            Console.ReadKey();
        }

        public static void HeapSort<T>(T[] array)
        {
            HeapSort<T>(array, 0, array.Length, Comparer<T>.Default);
        }

        public static void HeapSort<T>(T[] array, int offset, int length, IComparer<T> comparer)
        {
            HeapSort<T>(array, offset, length, comparer.Compare);
        }

        private static void HeapSort<T>(T[] array, int offset, int length, Comparison<T> comparison)
        {
            // build binary heap from all items
            for (int i = 0; i < length; i++)
            {
                int index = i;
                T item = array[offset + i]; // use next item

                // and move it on top, if greater than parent
                while (index > 0 &&
                    comparison(array[offset + (index - 1) / 2], item) < 0)
                {
                    int top = (index - 1) / 2;
                    array[offset + index] = array[offset + top];
                    index = top;
                }
                array[offset + index] = item;
            }

            for (int i = length - 1; i > 0; i--)
            {
                // delete max and place it as last
                T last = array[offset + i];
                array[offset + i] = array[offset];

                int index = 0;
                // the last one positioned in the heap
                while (index * 2 + 1 < i)
                {
                    int left = index * 2 + 1, right = left + 1;

                    if (right < i && comparison(array[offset + left], array[offset + right]) < 0)
                    {
                        if (comparison(last, array[offset + right]) > 0) break;

                        array[offset + index] = array[offset + right];
                        index = right;
                    }
                    else
                    {
                        if (comparison(last, array[offset + left]) > 0) break;

                        array[offset + index] = array[offset + left];
                        index = left;
                    }
                }
                array[offset + index] = last;
            }
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
