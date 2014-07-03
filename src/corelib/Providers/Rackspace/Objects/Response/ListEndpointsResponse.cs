using System.Runtime.Serialization;
using net.openstack.Core.Domain;

namespace net.openstack.Providers.Rackspace.Objects.Response
{
    [DataContract]
    internal class ListEndpointsResponse
    {
        [DataMember(Name = "endpoints")]
        public ExtendedEndpoint[] Endpoints { get; private set; }
    }
}