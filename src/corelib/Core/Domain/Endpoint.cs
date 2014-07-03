using System.Runtime.Serialization;

namespace net.openstack.Core.Domain
{
    [DataContract]
    public class Endpoint
    {
        [DataMember(Name="publicURL")]
        public string PublicURL { get; set; }

        [DataMember(Name = "region")]
        public string Region { get; set; }

        [DataMember(Name = "tenantId")]
        public string TenantId { get; set; }

        [DataMember(Name = "versionId")]
        public string VersionId { get; set; }

        [DataMember(Name = "versionInfo")]
        public string VersionInfo { get; set; }

        [DataMember(Name = "versionList")]
        public string VersionList { get; set; }
    }
}