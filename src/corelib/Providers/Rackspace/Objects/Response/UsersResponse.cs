using System.Runtime.Serialization;
using net.openstack.Core.Domain;

namespace net.openstack.Providers.Rackspace.Objects.Response
{
    [DataContract]
    internal class UsersResponse
    {
        [DataMember(Name = "users")]
        public User[] Users { get; set; }
    }
}