using System;
using System.Collections.Generic;
using net.openstack.Core.Domain;
using net.openstack.Core.Exceptions;
using net.openstack.Core.Exceptions.Response;

namespace net.openstack.Core.Providers
{
    /// <summary>
    /// Represents a provider for the OpenStack Networking service.
    /// </summary>
    /// <seealso href="http://docs.openstack.org/api/openstack-network/2.0/content/">OpenStack Networking API v2.0 Reference</seealso>
    public interface INetworksProvider
    {
        /// <summary>
        /// List the networks configured for the account.
        /// </summary>
        /// <param name="region">The region in which to execute this action. If not specified, the user's default region will be used.</param>
        /// <param name="identity">The cloud identity to use for this request. If not specified, the default identity for the current provider instance will be used.</param>
        /// <returns>A list of <see cref="CloudNetwork"/> objects describing the networks for the account.</returns>
        /// <exception cref="NotSupportedException">
        /// If the provider does not support the given <paramref name="identity"/> type.
        /// <para>-or-</para>
        /// <para>The specified <paramref name="region"/> is not supported.</para>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If <paramref name="identity"/> is <see langword="null"/> and no default identity is available for the provider.
        /// <para>-or-</para>
        /// <para>If <paramref name="region"/> is <see langword="null"/> and no default region is available for the provider.</para>
        /// </exception>
        /// <exception cref="ResponseException">If the REST API request failed.</exception>
        /// <seealso href="http://docs.openstack.org/api/openstack-network/2.0/content/List_Networks.html">List Networks (OpenStack Networking API v2.0 Reference)</seealso>
        IEnumerable<CloudNetwork> ListNetworks(string region = null, CloudIdentity identity = null);
    }
}