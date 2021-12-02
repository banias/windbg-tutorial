using System;
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
                    var input = "MySecretPassword" + _rand.Next(0, 1000);
                    Console.WriteLine(input.EndsWith("4") ? "Access granted!" : "Access denied.");
                });
        }
    }
}