using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                threads.Add(new Thread(() =>
                {
                    while (true)
                    {
                        var num = rand.Next(1, 1000000);
                        if(num % 6373 == 0)
                            Trap(); 
                        Thread.Sleep(80);
                    }
                }));
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.WriteLine("Press any key to kill the process.");
            Console.ReadLine();

        }

        static void Trap()
        {
            Trap();
        }
    }
}
