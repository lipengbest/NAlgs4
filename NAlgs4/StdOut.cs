using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// This class provides methods for printing strings and numbers to standard output.
    /// </summary>
    public static class StdOut
    {
        /// <summary>
        /// Closes standard output.
        /// </summary>
        public static void Close() => Console.Out.Close();

        /// <summary>
        /// Terminates the current line by printing the line-separator string.
        /// </summary>
        public static void Println() => Console.WriteLine();

        /// <summary>
        /// Prints a boolean to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the boolean to print</param>
        public static void Println(object x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a boolean to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the boolean to print</param>
        public static void Println(bool x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a character to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the character to print</param>
        public static void Println(char x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a double to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the double to print</param>
        public static void Println(double x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a float to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the float to print</param>
        public static void Println(float x) => Console.WriteLine(x);

        /// <summary>
        /// Prints an integer to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the integer to print</param>
        public static void Println(int x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a long to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the long to print</param>
        public static void Println(long x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a short integer to standard output and then terminates the line.
        /// </summary>
        /// <param name="x">the short to print</param>
        public static void Println(short x) => Console.WriteLine(x);

        /// <summary>
        /// Prints a byte to standard output and then terminates the line.
        /// <para>
        /// To write binary data, see {@link BinaryStdOut}.
        /// </para>
        /// </summary>
        /// <param name="x">the byte to print</param>
        public static void Println(byte x) => Console.WriteLine(x);

        /// <summary>
        /// Flushes standard output.
        /// </summary>
        public static void Print()
        {

        }

        /// <summary>
        /// Prints an object to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the object to print</param>
        public static void Print(object x) => Console.Write(x);

        /// <summary>
        /// Prints a boolean to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the boolean to print</param>
        public static void Print(bool x) => Console.Write(x);

        /// <summary>
        /// Prints a character to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the character to print</param>
        public static void Print(char x) => Console.Write(x);

        /// <summary>
        /// Prints a double to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the double to print</param>
        public static void Print(double x) => Console.Write(x);

        /// <summary>
        /// Prints a float to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the float to print</param>
        public static void Print(float x) => Console.Write(x);

        /// <summary>
        /// Prints an integer to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the integer to print</param>
        public static void Print(int x) => Console.Write(x);

        /// <summary>
        /// Prints a long integer to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the long integer to print</param>
        public static void Print(long x) => Console.Write(x);

        /// <summary>
        /// Prints a short integer to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the short integer to print</param>
        public static void Print(short x) => Console.Write(x);

        /// <summary>
        /// Prints a byte to standard output and flushes standard output.
        /// </summary>
        /// <param name="x">the byte to print</param>
        public static void Print(byte x) => Console.Write(x);

        /// <summary>
        /// Prints a formatted string to standard output, using the specified format
        /// string and arguments, and then flushes standard output.
        /// </summary>
        /// <param name="format">the <a href = "http://docs.oracle.com/javase/7/docs/api/java/util/Formatter.html#syntax">format string</a></param>
        /// <param name="args">the arguments accompanying the format string</param>
        public static void Printf(string format, params object[] args) => Console.Write(format, args);

        /// <summary>
        /// Prints a formatted string to standard output, using the locale and
        /// the specified format string and arguments; then flushes standard output.
        /// </summary>
        /// <param name="locale">the locale</param>
        /// <param name="format">the <a href = "http://docs.oracle.com/javase/7/docs/api/java/util/Formatter.html#syntax">format string</a></param>
        /// <param name="args">the arguments accompanying the format string</param>
        public static void Printf(CultureInfo locale, string format, params object[] args)
        {
            string output = string.Format(locale, format, args);
            Console.Write(output);
        }

        /// <summary>
        /// Unit tests some of the methods in <c>StdOut</c>.
        /// </summary>
        /// <param name="args">the command-line arguments</param>
        private static void Test(string[] args)
        {
            Println("test");
            Println(17);
            Println((object)true);
            Printf("{0:f6}\n", 1.0 / 7.0);
        }
    }
}
