using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading;

namespace WCFWebClient.ViewModel
{
    public class NewsWeatherViewModel
    {
        //time taken to calculate the service call
        private Stopwatch _watch;
        //queue to store messages from service
        private ConcurrentQueue<string> _messages;

        public NewsWeatherViewModel()
        {
            _watch = Stopwatch.StartNew();
            _messages = new ConcurrentQueue<string>();
        }

        public string Headline { get; set; }
        public double Temperature { get; set; }

        public void AddMessage(string message)
        {
            //adding messages from service to queue with threadId
            _messages.Enqueue(String.Format("{0} on thread {1}", message, Thread.CurrentThread.ManagedThreadId));
        }

        public IEnumerable<string> Messages
        {
            get { return _messages; }
        }

        public long ElapsedTime
        {
            get { return _watch.ElapsedMilliseconds; }
        }

    }
}