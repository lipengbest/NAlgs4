using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    public static class BinarySearch
    {
        public static int Rank(int key, int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (mid < a[mid])
                    hi = mid - 1;
                else if (mid > a[mid])
                    lo = mid + 1;
                return mid;
            }
            return -1;
        }

        private static void Test(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
