using System;
using System.Collections.Generic;
using System.Net;
using JSIStudios.SimpleRESTServices.Client;
using JSIStudios.SimpleRESTServices.Client.Json;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Core.Exceptions;
using net.openstack.Core.Exceptions.Response;
using net.openstack.Core.Providers;
using net.openstack.Providers.Rackspace.Objects.Response;

namespace net.openstack.Providers.Rackspace
{
    /// <summary>
    /// <para>The Cloud Networks Provider enable simple access to the Rackspace Cloud Network Services.
    /// Cloud Networks lets you create a virtual Layer 2 network, known as an isolated network, 
    /// which gives you greater control and security when you deploy web applications.</para>
    /// <para />
    /// <para>Documentation URL: http://docs.rackspace.com/servers/api/v2/cn-gettingstarted/content/ch_overview.html</para>
    /// </summary>
    /// <see cref="INetworksProvider"/>
    /// <inheritdoc />
    /// <threadsafety static="true" instance="false"/>
    public class CloudNetworksProvider : ProviderBase, INetworksProvider
    {
        private readonly HttpStatusCode[] _validResponseCode = new[] { HttpStatusCode.OK, HttpStatusCode.Created, HttpStatusCode.Accepted };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFilesProvider"/> class with
        /// no default identity or region, and the default identity provider and REST
        /// service implementation.
        /// </summary>
        public CloudNetworksProvider()
            : this(new IdentityProvider(), new JsonRestServices()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudNetworksProvider"/> class with
        /// the specified default identity, default region, identity provider, and REST
        /// service implementation.
        /// </summary>
        /// <param name="identity">An instance of a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object. <remarks>If not provided, the user will be required to pass a <see cref="net.openstack.Core.Domain.CloudIdentity"/> object to each method individually.</remarks></param>
        /// <param name="defaultRegion">The default region to use for calls that do not explicitly specify a region. If this value is <see langword="null"/>, the default region for the user will be used; otherwise if the service uses region-specific endpoints all calls must specify an explicit region.</param>
        /// <param name="identityProvider">An instance of an <see cref="IIdentityProvider"/> to override the default <see cref="CloudIdentity"/></param>
        /// <param name="restService">An instance of an <see cref="IRestService"/> to override the default <see cref="JsonRestServices"/></param>
        public CloudNetworksProvider(IIdentityProvider identityProvider, IRestService restService)
            : base(identityProvider, restService) { }

        #endregion


        #region Networks

        /// <inheritdoc />
        public IEnumerable<CloudNetwork> ListNetworks(string region = null, CloudIdentity identity = null)
        {
            var urlPath = new Uri(string.Format("{0}/os-networksv2", GetServiceEndpoint(identity, region)));
            var response = ExecuteRESTRequest<ListCloudNetworksResponse>(identity, urlPath, HttpMethod.GET);

            if (response == null || response.Data == null)
                return null;

            return response.Data.Networks;
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Gets the public service endpoint to use for Cloud Networks requests for the specified identity and region.
        /// </summary>
        /// <remarks>
        /// This method uses <c>compute</c> for the service type, and <c>cloudServersOpenStack</c> for the preferred service name.
        /// </remarks>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <param name="region">The preferred region for the service. If this value is <see langword="null"/>, the user's default region will be used.</param>
        /// <returns>The public URL for the requested Cloud Networks endpoint.</returns>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// </exception>
        /// <exception cref="NoDefaultRegionSetException">If <paramref name="region"/> is <see langword="null"/> and no default region is available for the identity or provider.</exception>
        /// <exception cref="UserAuthenticationException">If no service catalog is available for the user.</exception>
        /// <exception cref="UserAuthorizationException">If no endpoint is available for the requested service.</exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        protected string GetServiceEndpoint(CloudIdentity identity, string region)
        {
            return base.GetServiceEndpoint(identity, "cloudServersOpenStack", region);
        }

        #endregion
    }
}