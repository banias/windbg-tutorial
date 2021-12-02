using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace XmlSerializerLeak
{

    [XmlRoot("Foo")]
    public class Foo
    {
        [XmlElement("Bar")]
        public string Bar { get; set; }
    }

    class Program
    {
        private static Timer _timer;
        static void Main(string[] args)
        {
            _timer = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
            _timer.Elapsed += PrintMemoryUsage;
            _timer.Start();

            while (true)
            {
                using (var sr = new StreamReader(".\\file.xml"))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Foo), new Type[] { });
                    var foo = (Foo)xmlSerializer.Deserialize(sr);
                }
            }
        }

        private static void PrintMemoryUsage(Object source, ElapsedEventArgs e)
        {
            var proc = Process.GetCurrentProcess();
            Console.WriteLine($"Private bytes: {proc.PrivateMemorySize64 / 1024 / 1024}MB");
        }
    }
}
