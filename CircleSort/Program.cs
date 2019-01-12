using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            CircleSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        public static void CircleSort(int[] arr)
        {
            if (arr.Length > 0) 
                while (CircleSortR(arr, 0, arr.Length - 1, 0) != 0);
        }

        private static int CircleSortR(int[] arr, int lo, int hi, int numSwaps)
        {
            if (lo == hi)
                return numSwaps;

            int high = hi;
            int low = lo;
            int mid = (hi - lo) / 2;

            while (lo < hi)
            {
                if (arr[lo] > arr[hi])
                {
                    Swap(arr, lo, hi);
                    numSwaps++;
                }
                lo++;
                hi--;
            }

            if (lo == hi && arr[lo] > arr[hi + 1])
            {
                Swap(arr, lo, hi + 1);
                numSwaps++;
            }

            numSwaps = CircleSortR(arr, low, low + mid, numSwaps);
            numSwaps = CircleSortR(arr, low + mid + 1, high, numSwaps);

            return numSwaps;
        }

        private static void Swap(int[] arr, int idx1, int idx2)
        {
            int tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
