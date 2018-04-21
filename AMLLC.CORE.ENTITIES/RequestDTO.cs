using System.Runtime.Serialization;

namespace AMLLC.CORE.ENTITIES
{
    [DataContract]
    public class RequestDTO<T>
    {
        [DataMember]
        public int IdWebSite { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public T Signature { get; set; }
    }
}
