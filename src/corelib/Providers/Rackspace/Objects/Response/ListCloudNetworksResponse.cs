using System.Runtime.Serialization;
using net.openstack.Core.Domain;

namespace net.openstack.Providers.Rackspace.Objects.Response
{
    /// <summary>
    /// This models the JSON response used for the List Networks request.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-network/2.0/content/List_Networks.html">List Networks (OpenStack Networking API v2.0 Reference)</seealso>
    /// <threadsafety static="true" instance="false"/>
    [DataContract]
    internal class ListCloudNetworksResponse
    {
        /// <summary>
        /// Gets a collection of networks.
        /// </summary>
        [DataMember(Name = "networks")]
        public CloudNetwork[] Networks { get; private set; }
    }
}