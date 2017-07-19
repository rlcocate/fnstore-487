using System;
using System.Runtime.Serialization;

namespace FN.Store.WCFData.Model
{
    [DataContract]
    public class ClienteVM
    {
        public ClienteVM()
        {
            DataLog = DateTime.Now;
        }

        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public string Nome { get; set; }
        
        [DataMember]
        public DateTime DataLog { get; set; }
    }
}