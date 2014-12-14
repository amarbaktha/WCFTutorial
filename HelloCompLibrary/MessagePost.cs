using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace HelloCompLibrary
{
    [DataContract]
    public class MessagePost
    {
        [DataMember]
        public string MessageDetails { get; set; }
    }
}
