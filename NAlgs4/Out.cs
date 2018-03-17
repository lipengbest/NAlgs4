using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NAlgs4
{
    /// <summary>
    /// This class provides methods for writing strings and numbers to
    /// various output streams, including standard output, file, and sockets.
    /// </summary>
    public sealed class Out : IDisposable
    {
        private static readonly Encoding CharSet = Encoding.UTF8;

        private TextWriter writer;

        /// <summary>
        /// Initializes an output stream from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="stream">the <c>Stream</c></param>
        public Out(Stream stream)
        {
            writer = new StreamWriter(stream, CharSet);
        }

        /// <summary>
        /// Initializes an output stream from standard output.
        /// </summary>
        public Out()
        {
            writer = Console.Out;
        }

        /// <summary>
        /// Initializes an output stream from a socket.
        /// </summary>
        /// <param name="socket">the socket</param>
        public Out(Socket socket)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes an output stream from a file.
        /// </summary>
        /// <param name="filename">the name of the file</param>
        public Out(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Create);
            writer = new StreamWriter(stream, CharSet);
        }

        /// <summary>
        /// Closes the output stream.
        /// </summary>
        public void Close() => writer.Close();

        /// <summary>
        /// Dispose the output stream.
        /// </summary>
        public void Dispose() => writer.Dispose();

        public void Println() => writer.WriteLine();

        public void Println(object x) => writer.WriteLine(x);

        public void Println(bool x) => writer.WriteLine(x);

        public void Println(char x) => writer.WriteLine(x);

        public void Println(double x) => writer.WriteLine(x);

        public void Println(float x) => writer.WriteLine(x);

        public void Println(int x) => writer.WriteLine(x);

        public void Println(long x) => writer.WriteLine(x);

        public void Println(byte x) => writer.WriteLine(x);

        public void Print()
        {
            writer.Flush();
        }

        public void Print(object x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(bool x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(char x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(double x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(float x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(int x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(long x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Print(byte x)
        {
            writer.Write(x);
            writer.Flush();
        }

        public void Printf(string format, params object[] args) => writer.Write(format, args);

        public void Printf(CultureInfo locale, string format, params object[] args)
        {
            string output = string.Format(locale, format, args);
            writer.Write(output);
        }

        private static void Test(string[] args)
        {
            Out output;

            using (output = new Out())
            {
                output.Println("Test 1");
            }

            using (output = new Out("test.txt"))
            {
                output.Println("Test 2");
            }
        }
    }
}
