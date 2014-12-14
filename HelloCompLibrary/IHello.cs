using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace HelloCompLibrary
{
    [ServiceContract]
    public interface IHello
    {
        [OperationContract(IsOneWay = true)]
        void PostMessages(MessagePost message);
        [OperationContract]
        string Greet(string name);
    }

}
