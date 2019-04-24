using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakExample
{
    class Container
    {
        private byte[] _data;
        private List<Container> _children;
        public IEnumerable<Container> Children => _children.AsReadOnly();
        public Container()
        {
            _children = new List<Container>();
            _data = new byte[Program.Random.Next(1024, 80000)];
            Program.Random.NextBytes(_data);
        }

        public void AddChildren()
        {
            for (int i = 0; i < Program.Random.Next(10000, 1000000); i++)
            {
                _children.Add(new Container());
            }
        }
    }
    class Program
    {
        public static Random Random = new Random();
        static void Main(string[] args)
        {
            var root = new Container();
            root.AddChildren();

            foreach (var c in root.Children)
            {
                c.AddChildren();
            }

            Console.WriteLine("Press any key to kill the process.");
            Console.ReadLine();
        }

    }
}
