using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WSChatService : IWSChatService
    {
        public async Task SendMessageToServer(string msg)
        {
            var callback = OperationContext.Current.GetCallbackChannel<IWSChatCallBack>();
            if (((IChannel)callback).State == CommunicationState.Opened)
            {
                await callback.SendMessageToClient(string.Format("THanks!! Got message(0) at (1)", msg, DateTime.Now.ToLongTimeString()));
            }
        }
    }
}
