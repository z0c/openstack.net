using System.Runtime.Serialization;

namespace net.openstack.Core.Domain
{
    [DataContract]
    public class ExtendedEndpoint : Endpoint
    {
        [DataMember(Name = "id")]
        public string Id { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "type")]
        public string Type { get; private set; }
    }
}