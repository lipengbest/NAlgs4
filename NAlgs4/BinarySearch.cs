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
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else return mid;
            }
            return -1;
        }

        private static void Test(string[] args)
        {
            int[] whitelist = In.ReadInts(args[0]);

            Array.Sort(whitelist);

            while (!StdIn.IsEmpty)
            {
                int key = StdIn.ReadInt();
                if (Rank(key, whitelist) == -1)
                {
                    StdOut.Println(key);
                }
            }
        }
    }
}
