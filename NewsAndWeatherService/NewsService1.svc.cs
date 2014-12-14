using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewsAndWeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewsService1.svc or NewsService1.svc.cs at the Solution Explorer and start debugging.
    public class NewsService1 : INewsService1
    {
        public string GetHeadlines()
        {
            return "New Headlines for today!!";
        }
    }
}
