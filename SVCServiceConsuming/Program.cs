using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVCServiceConsuming
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloClient proxy = new HelloClient("BasicHttpBinding_IHello");
            Console.WriteLine(proxy.Greet("Amar"));
        }
    }
}
