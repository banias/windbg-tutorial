using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PasswordInMemoryExample
{
    class Program
    {
        private static Random _rand = new Random();
        static void Main(string[] args)
        {
            for (var i = 0; i < 100000; i++)
            {
                AcceptPasswordAsync();
            }
            Console.WriteLine("Press any key to kill the process.");
            Console.ReadKey();
        }

        private static async Task AcceptPasswordAsync()
        {
            await Task.Run(
                () =>
                {
                    using (var ss = new SecureString())
                    {
                        ss.AppendChar('M');
                        ss.AppendChar('y');
                        ss.AppendChar('S');
                        ss.AppendChar('e');
                        ss.AppendChar('c');
                        ss.AppendChar('r');
                        ss.AppendChar('e');
                        ss.AppendChar('t');
                        ss.AppendChar('P');
                        ss.AppendChar('a');
                        ss.AppendChar('s');
                        ss.AppendChar('s');
                        ss.AppendChar('w');
                        ss.AppendChar('o');
                        ss.AppendChar('r');
                        ss.AppendChar('d');
                        var number = _rand.Next(1, 1000).ToString();
                        foreach (var s in number.ToCharArray())
                            ss.AppendChar(s);
                        ss.MakeReadOnly();

                        //Unsafe!!!
                        Console.WriteLine(ss.ToString().EndsWith("4") ? "Access granted!" : "Access denied.");

                    }
                });
        }
    }
}
