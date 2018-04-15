using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// The <see cref="RandomSeq"/> class is a client that prints out a pseudorandom
    /// sequence of real numbers in a given range.
    /// </summary>
    public class RandomSeq
    {
        /// <summary>
        /// Reads in two command-line arguments lo and hi and prints n uniformly
        /// random real numbers in [lo, hi) to standard output.
        /// </summary>
        /// <param name="args">the command-line arguments</param>
        private static void Test(string[] args)
        {
            // command-line arguments
            int n = int.Parse(args[0]);

            // for backward compatibility with Intro to Programming in Java version of RandomSeq
            if (args.Length == 1)
            {
                // generate and print n numbers between 0.0 and 1.0
                for (int i = 0; i < n; i++)
                {
                    double x = StdRandom.Uniform();
                    StdOut.Println(x);
                }
            }
            else if (args.Length == 3)
            {
                double lo = double.Parse(args[1]);
                double hi = double.Parse(args[2]);

                // generate and print n numbers between lo and hi
                for (int i = 0; i < n; i++)
                {
                    double x = StdRandom.Uniform(lo, hi);
                    StdOut.Printf("{0:f2}\n", x);
                }
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
    }
}
