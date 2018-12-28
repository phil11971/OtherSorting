using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermutationSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = new int[] { 9, 6, 10, 8, 43, 2, 6, 24, 6 };

            Console.WriteLine("Src mas");
            PrintMas(mas);

            mas = PermutationSort(mas);

            Console.WriteLine("Res mas");
            PrintMas(mas);

            Console.ReadKey();
        }

        static int[] PermutationSort(int[] a)
        {
            List<int[]> list = new List<int[]>();
            Permute(a, a.Length, list);
            foreach (int[] x in list)
                if (IsSorted(x))
                    return x;
            return a;
        }
        private static void Permute(int[] a, int n, List<int[]> list)
        {
            if (n == 1)
            {
                int[] b = new int[a.Length];
                Array.Copy(a, 0, b, 0, a.Length);
                list.Add(b);
                return;
            }
            for (int i = 0; i < n; i++)
            {
                Swap(a, i, n - 1);
                Permute(a, n - 1, list);
                Swap(a, i, n - 1);
            }
        }
        private static bool IsSorted(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i - 1] > a[i])
                    return false;
            return true;
        }
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void PrintMas(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
