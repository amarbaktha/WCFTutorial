using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRESTSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class HelloWorldService
    {
        private static Dictionary<string, int> Value { get; set; }
        static HelloWorldService()
        {
            //creating empty collection
            Value = new Dictionary<string, int>();
        }
        [OperationContract]
        [WebGet(UriTemplate = "value/{name}")]
        public int GetValue(string name)
        {
            if (!Value.ContainsKey(name))
            {
                throw new WebFaultException<string>(string.Format("Key {0} does not exist", name),
                    System.Net.HttpStatusCode.NotFound);
            }
            return Value[name];
        }
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "value/{name}")]
        public void PutValue(string name, int value)
        {
            //put is used for uupdate not fo creation
            if (!Value.ContainsKey(name))
            {
                throw new WebFaultException<string>(string.Format("Key {0} does not exist. Cannot update the key", name),
                    System.Net.HttpStatusCode.NotFound);
            }
            Value[name] = value;
        }
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "value/{name}")]
        public void DeleteValue(string name)
        {
            if (Value.ContainsKey(name))
            {
                Value.Remove(name);
            }
        }
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "value/{name}")]
        public void PostValue(string name, int value)
        {
            //post is used for creation not for update
            if (Value.ContainsKey(name))
            {
                throw new WebFaultException<string>(string.Format("Key {0} already exist. Cannot create twice", name),
                    System.Net.HttpStatusCode.Conflict);
            }
            Value[name] = value;
        }
        [OperationContract]
        [WebGet(UriTemplate = "/time")]
        [AspNetCacheProfile("CacheFor10Seconds")]
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
