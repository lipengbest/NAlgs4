using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NAlgs4
{
    public sealed class In : IDisposable
    {
        private static readonly Regex WhiteSpace = new Regex(@"[\s]+", RegexOptions.Compiled);
        private static readonly string WhiteSpacePattern = @"\s*\S+\s*";

        private static HttpClient httpClient = new HttpClient();

        private TextReader reader;
        private string buffer = string.Empty;

        public In() => reader = Console.In;

        public In(Socket socket)
        {
            throw new NotImplementedException();
        }

        public In(Uri uri)
        {
            throw new NotImplementedException();
        }

        public In(FileInfo file)
        {
            throw new NotImplementedException();
        }

        public In(string name)
        {
            if (File.Exists(name))
            {
                FileStream fs = new FileStream(name, FileMode.Open);
                reader = new StreamReader(fs);
                return;
            }

            if (name.StartsWith("http://") || name.StartsWith("https://"))
            {
                var httpStreamTask = httpClient.GetStreamAsync(name);
                httpStreamTask.Wait();
                reader = new StreamReader(httpStreamTask.Result);
            }
        }

        public In(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public bool Exists => reader != null;

        public bool IsEmpty
        {
            get
            {
                if (buffer.Equals(string.Empty))
                    buffer = reader.ReadLine();
                return buffer == null;
            }
        }

        public bool HasNextLine() => !IsEmpty;

        public bool HasNextChar() => !IsEmpty;

        public string ReadLine()
        {
            if (buffer.Equals(string.Empty))
                buffer = reader.ReadLine();
            string line = buffer;
            buffer = string.Empty;
            return line;
        }

        public char ReadChar()
        {
            if (buffer.Equals(string.Empty))
            {
                buffer = reader.ReadLine();
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

        public string ReadAll()
        {
            if (!HasNextLine())
                return string.Empty;
            return ReadLine() + "\n" + reader.ReadToEnd();
        }

        public string ReadString() => GetToken();

        public int ReadInt()
        {
            string token = GetToken();
            return int.Parse(token);
        }

        public double ReadDouble()
        {
            string token = GetToken();
            return double.Parse(token);
        }

        public float ReadFloat()
        {
            string token = GetToken();
            return float.Parse(token);
        }

        public long ReadLong()
        {
            string token = GetToken();
            return long.Parse(token);
        }

        public short ReadShort()
        {
            string token = GetToken();
            return short.Parse(token);
        }

        public byte ReadByte()
        {
            string token = GetToken();
            return byte.Parse(token);
        }

        public bool ReadBool()
        {
            string token = GetToken();
            return bool.Parse(token);
        }

        public string[] ReadAllStrings()
        {
            string remiander = ReadAll();
            return WhiteSpace.Split(remiander.Trim());
        }

        public string[] ReadAllLines()
        {
            List<string> lines = new List<string>();
            while (HasNextLine())
            {
                lines.Add(ReadLine());
            }
            return lines.ToArray();
        }

        public int[] ReadAllInts()
        {
            string[] tokens = ReadAllStrings();
            int[] vals = new int[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = int.Parse(tokens[i]);
            }
            return vals;
        }

        public long[] ReadAllLongs()
        {
            string[] tokens = ReadAllStrings();
            long[] vals = new long[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = long.Parse(tokens[i]);
            }
            return vals;
        }

        public double[] ReadAllDoubles()
        {
            string[] tokens = ReadAllStrings();
            double[] vals = new double[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                vals[i] = double.Parse(tokens[i]);
            }
            return vals;
        }

        public void Close()
        {
            reader.Close();
        }

        public void Dispose()
        {
            reader.Dispose();
        }

        [Obsolete]
        public static int[] ReadInts(string filename)
        {
            return new In(filename).ReadAllInts();
        }

        [Obsolete]
        public static double[] ReadDoubles(string filename)
        {
            return new In(filename).ReadAllDoubles();
        }

        [Obsolete]
        public static string[] ReadStrings(string filename)
        {
            return new In(filename).ReadAllStrings();
        }

        [Obsolete]
        public static int[] ReadInts()
        {
            return new In().ReadAllInts();
        }

        [Obsolete]
        public static double[] ReadDoubles()
        {
            return new In().ReadAllDoubles();
        }

        [Obsolete]
        public static String[] ReadStrings()
        {
            return new In().ReadAllStrings();
        }

        private string GetToken()
        {
            if (buffer.Equals(string.Empty))
            {
                buffer = reader.ReadLine();
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

        private static void Test(string[] args)
        {
            In input;
            string urlName = "https://introcs.cs.princeton.edu/stdlib/InTest.txt";

            // read from a URL
            Console.WriteLine("readAll() from URL " + urlName);
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In(urlName);
                Console.WriteLine(input.ReadAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();

            // read one line at a time from URL
            Console.WriteLine("readLine() from URL " + urlName);
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In(urlName);
                while (!input.IsEmpty)
                {
                    string s = input.ReadLine();
                    Console.WriteLine(s);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();

            // read one string at a time from URL
            Console.WriteLine("readString() from URL " + urlName);
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In(urlName);
                while (!input.IsEmpty)
                {
                    string s = input.ReadString();
                    Console.WriteLine(s);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();

            // read one line at a time from file in current directory
            Console.WriteLine("readLine() from current directory");
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In("./InTest.txt");
                while (!input.IsEmpty)
                {
                    string s = input.ReadLine();
                    Console.WriteLine(s);
                }
                input.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();

            // read one line at a time from file using relative path
            //Console.WriteLine("readLine() from relative path");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //try
            //{
            //    input = new In("../bin/InTest.txt");
            //    while (!input.IsEmpty)
            //    {
            //        string s = input.ReadLine();
            //        Console.WriteLine(s);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //Console.WriteLine();

            // read one char at a time
            Console.WriteLine("readChar() from file");
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In("InTest.txt");
                while (!input.IsEmpty)
                {
                    char c = input.ReadChar();
                    Console.Write(c);
                }
                input.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();
            Console.WriteLine();

            // read one line at a time from absolute Windows path
            Console.WriteLine("readLine() from absolute Windows path");
            Console.WriteLine("---------------------------------------------------------------------------");
            try
            {
                input = new In(@"D:\Source\NorthWind\NAlgs4\AlgsCmd\bin\Debug\InTest.txt");
                while (!input.IsEmpty)
                {
                    string s = input.ReadLine();
                    Console.WriteLine(s);
                }
                input.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine();
        }
    }
}
