using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NewsAndWeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INewsService1" in both code and config file together.
    [ServiceContract]
    public interface INewsService1
    {
        [OperationContract]
        string GetHeadlines();
    }
}
