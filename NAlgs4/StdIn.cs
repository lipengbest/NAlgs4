using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// The <c>StdIn</c> class provides static methods for reading strings
    /// and numbers from standard input.
    /// </summary>
    public static class StdIn
    {
        private static readonly Regex WhiteSpace = new Regex(@"[\s]+", RegexOptions.Compiled);
        private static readonly string WhiteSpacePattern = @"\s*\S+\s*";

        private static string buffer = string.Empty;

        /// <summary>
        /// Returns true if standard input is empty (except possibly for whitespace).
        /// Use this method to know whether the next call to <see cref="ReadString()"/>,
        /// <see cref="ReadDouble()"/>, etc will succeed
        /// </summary>
        /// <returns>
        /// <c>true</c> if standard input is empty (except possibly
        /// for whitespace); <c>false</c> otherwise
        /// </returns>
        public static bool IsEmpty
        {
            get
            {
                if (buffer.Equals(string.Empty))
                    buffer = Console.ReadLine();
                return buffer == null;
            }
        }

        /// <summary>
        /// Returns true if standard input has a next line.
        /// Use this method to know whether the
        /// next call to <see cref="ReadLine()"/> will succeed.
        /// This method is functionally equivalent to <see cref="HasNextChar()"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if standard input has more input (including whitespace);
        /// <c>false</c> otherwise
        /// </returns>
        public static bool HasNextLine() => !IsEmpty;

        /// <summary>
        /// Returns true if standard input has more input (including whitespace).
        /// Use this method to know whether the next call to <see cref="ReadChar"/> will succeed.
        /// This method is functionally equivalent to <see cref="HasNextLine"/>.
        /// </summary>
        /// <returns>
        /// <c>true</c> if standard input has more input (including whitespace);
        /// <c>false</c> otherwise
        /// </returns>
        public static bool HasNextChar() => !IsEmpty;

        /// <summary>
        /// Reads and returns the next line, excluding the line separator if present.
        /// </summary>
        /// <returns>the next line, excluding the line separator if present; <c>null</c> if no such line</returns>
        public static string ReadLine()
        {
            if (buffer.Equals(string.Empty))
                buffer = Console.ReadLine();
            string line = buffer;
            buffer = string.Empty;
            return line;
        }

        /// <summary>
        /// Reads and returns the next character.
        /// </summary>
        /// <returns>the next <c>char</c></returns>
        public static char ReadChar()
        {
            if (buffer.Equals(string.Empty))
            {
                buffer = Console.ReadLine();
                if (buffer != null)
                {
                    return '\n';
                }
                else
                {
                    throw new FormatException("end of file might have been reached");
                }
            }
            else
            {
                char val = buffer[0];
                buffer = buffer.Substring(1);
                return val;
            }
        }

        /// <summary>
        /// Reads and returns the remainder of the input, as a string.
        /// </summary>
        /// <returns>the remainder of the input, as a string</returns>
        public static string ReadAll()
        {
            if (!HasNextLine())
                return string.Empty;
            return ReadLine() + "\n" + Console.In.ReadToEnd();
        }

        /// <summary>
        /// Reads the next token  and returns the <c>string</c>.
        /// </summary>
        /// <returns>the next <c>string</c>if standard input is empty</returns>
        /// <exception cref="FormatException"></exception>
        public static string ReadString() => GetToken();

        /// <summary>
        /// Reads the next token from standard input, parses it as an integer, and returns the integer.
        /// </summary>
        /// <returns>the next integer on standard input</returns>
        public static int ReadInt()
        {
            string token = GetToken();
            return int.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a double, and returns the double.
        /// </summary>
        /// <returns>the next double on standard input</returns>
        public static double ReadDouble()
        {
            string token = GetToken();
            return double.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a float, and returns the float.
        /// </summary>
        /// <returns>the next float on standard input</returns>
        public static float ReadFloat()
        {
            string token = GetToken();
            return float.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a long integer, and returns the long integer.
        /// </summary>
        /// <returns>the next long integer on standard input</returns>
        public static long ReadLong()
        {
            string token = GetToken();
            return long.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a short integer, and returns the short integer.
        /// </summary>
        /// <returns>the next short integer on standard input</returns>
        public static short ReadShort()
        {
            string token = GetToken();
            return short.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a byte, and returns the byte.
        /// </summary>
        /// <returns>the next byte on standard input</returns>
        public static byte ReadByte()
        {
            string token = GetToken();
            return byte.Parse(token);
        }

        /// <summary>
        /// Reads the next token from standard input, parses it as a boolean,
        /// and returns the bool.
        /// </summary>
        /// <returns>the next bool on standard input</returns>
        public static bool ReadBool()
        {
            string token = GetToken();
            return bool.Parse(token);
        }

        /// <summary>
        /// Reads all remaining tokens from standard input and returns them as an array of strings.
        /// </summary>
        /// <returns>all remaining tokens on standard input, as an array of strings</returns>
        public static string[] ReadAllStrings()
        {
            string remiander = ReadAll();
            return WhiteSpace.Split(remiander.Trim());
        }

        /// <summary>
        /// Reads all remaining lines from standard input and returns them as an array of strings.
        /// </summary>
        /// <returns>all remaining lines on standard input, as an array of strings</returns>
        public static string[] ReadAllLines()
        {
            List<string> lines = new List<string>();
            while (HasNextLine())
            {
                lines.Add(ReadLine());
            }
            return lines.ToArray();
        }

        /// <summary>
        /// Reads all remaining tokens from standard input, parses them as integers, and returns
        /// them as an array of integers.
        /// </summary>
        /// <returns>all remaining integers on standard input, as an array</returns>
        /// <exception cref="FormatException">if any token cannot be parsed as an <c>int</c></exception>
        public static int[] ReadAllInts()
        {
            string[] tokens = ReadAllStrings();
            int[] vals = new int[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = int.Parse(tokens[i]);
            }
            return vals;
        }

        /// <summary>
        /// Reads all remaining tokens from standard input, parses them as longs, and returns
        /// them as an array of longs.
        /// </summary>
        /// <returns>all remaining longs on standard input, as an array</returns>
        /// <exception cref="FormatException">if any token cannot be parsed as a <c>long</c></exception>
        public static long[] ReadAllLongs()
        {
            string[] tokens = ReadAllStrings();
            long[] vals = new long[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = long.Parse(tokens[i]);
            }
            return vals;
        }

        /// <summary>
        /// Reads all remaining tokens from standard input, parses them as doubles, and returns
        /// them as an array of doubles.
        /// </summary>
        /// <returns>all remaining doubles on standard input, as an array</returns>
        /// <exception cref="FormatException">if any token cannot be parsed as a <c>double</c></exception>
        public static double[] ReadAllDoubles()
        {
            string[] tokens = ReadAllStrings();
            double[] vals = new double[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = double.Parse(tokens[i]);
            }
            return vals;
        }

        /// <summary>
        /// Reads all remaining tokens from standard input, parses them as integers, and returns
        /// them as an array of integers.
        /// </summary>
        /// <returns>all remaining integers on standard input, as an array</returns>
        /// <exception cref="FormatException">if any token cannot be parsed as an <c>int</c></exception>
        /// <remarks>Replaced by <see cref="ReadAllInts"/>.</remarks>
        [Obsolete]
        public static int[] ReadInts()
        {
            return ReadAllInts();
        }

        /// <summary>
        /// Reads all remaining tokens from standard input, parses them as doubles, and returns
        /// them as an array of doubles.
        /// </summary>
        /// <returns>all remaining doubles on standard input, as an array</returns>
        /// <exception cref="FormatException">if any token cannot be parsed as a <c>double</c></exception>
        /// <remarks>Replaced by <see cref="ReadAllDoubles"/>.</remarks>
        [Obsolete]
        public static double[] ReadDoubles()
        {
            return ReadAllDoubles();
        }

        /// <summary>
        /// Reads all remaining tokens from standard input and returns them as an array of strings.
        /// </summary>
        /// <returns>all remaining tokens on standard input, as an array of strings</returns>
        /// <remarks>Replaced by <see cref="ReadAllStrings"/>.</remarks>
        [Obsolete]
        public static string[] ReadStrings()
        {
            return ReadAllStrings();
        }

        private static string GetToken()
        {
            if (buffer.Equals(string.Empty))
            {
                buffer = Console.ReadLine();
            }
            if (buffer != null)
            {
                Match match = Regex.Match(buffer, WhiteSpacePattern, RegexOptions.Compiled);
                string token = match.Value.Trim();
                if (string.IsNullOrEmpty(token))
                    buffer = string.Empty;
                else
                    buffer = buffer.Substring(match.Value.Length);
                return token;
            }
            else
            {
                throw new InvalidOperationException("end of file might have been reached");
            }
        }

        /// <summary>
        /// Interactive test of basic functionality.
        /// </summary>
        /// <param name="args">the command-line arguments</param>
        private static void Test(string[] args)
        {
            //StdOut.Print("Type a string: ");
            //string s = ReadString();
            //StdOut.Println("Your string was: " + s);
            //StdOut.Println();

            //StdOut.Print("Type an int: ");
            //int a = ReadInt();
            //StdOut.Println("Your int was: " + a);
            //StdOut.Println();

            //StdOut.Print("Type a boolean: ");
            //bool b = ReadBool();
            //StdOut.Println("Your boolean was: " + b);
            //StdOut.Println();

            //StdOut.Print("Type a double: ");
            //double c = ReadDouble();
            //StdOut.Println("Your double was: " + c);
            //StdOut.Println();

            while (!StdIn.IsEmpty)
            {
                int key = StdIn.ReadInt();
                StdOut.Println(key);
            }           
        }
    }
}
