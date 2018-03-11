using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NAlgs4;

namespace AlgsCmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(StdIn));
            string nameSpace = "NAlgs4";

            if (args.Length > 0)
            {
                string className = args[0];
                if (!className.Contains(nameSpace))
                    className = $"{nameSpace}.{className}";
                Type type = assembly.GetType(className);
                if (type != null)
                {
                    var TestMethod = type.GetMethod("Test", BindingFlags.NonPublic | BindingFlags.Static);
                    if (TestMethod != null)
                    {
                        string[] parameters = new string[args.Length - 1];
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            parameters[i] = args[i + 1];
                        }

                        TestMethod.Invoke(null, new object[] { parameters });
                    }
                }
                else
                {
                    Console.WriteLine("Not found Class!");
                }
            }
        }
    }
}
