using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// The <see cref="Average"/> class provides a client for reading in a sequence
    /// of real numbers and printing out their average.
    /// </summary>
    public class Average
    {
        /// <summary>
        /// Reads in a sequence of real numbers from standard input and prints
        /// out their average to standard output.
        /// </summary>
        /// <param name="args">the command-line arguments</param>
        private static void Test(string[] args)
        {
            int count = 0;            // number input values
            double sum = 0.0;         // sum of input values

            // read data and compute statistics
            while (!StdIn.IsEmpty)
            {
                double value = StdIn.ReadDouble();
                sum += value;
                count++;
            }

            // compute the average
            double average = sum / count;

            // print results
            StdOut.Println("Average is " + average);
        }
    }
}
