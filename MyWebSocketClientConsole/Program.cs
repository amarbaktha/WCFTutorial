using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSocketClientConsole.WebSocketService;

namespace MyWebSocketClientConsole
{
    class CallBackClient : IWSChatService
    {
        public void SendMessageToClient(string msg)
        {
            Console.WriteLine(msg);
        }


        public void SendMessageToServer(string value)
        {
            throw new NotImplementedException();
        }

        public Task SendMessageToServerAsync(string value)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
