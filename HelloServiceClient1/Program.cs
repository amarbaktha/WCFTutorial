using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HelloCompLibrary;

namespace HelloServiceClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IHello> client = new ChannelFactory<IHello>("httpEndpoint");
            IHello proxy = client.CreateChannel();
            Console.WriteLine(proxy.Greet("Amar"));
            MessagePost message = new MessagePost();
            message.MessageDetails = "Hello from Client!";
            proxy.PostMessages(message);

            //from metadata
            //HelloClient proxy = new HelloClient("BasciHttpBinding_IHello");
            //Console.WriteLine(proxy.Greet("Amar"));
        }
    }
}
