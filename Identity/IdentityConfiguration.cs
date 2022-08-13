using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Identity
{
    public static class IdentityConfiguration
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id_eventapi",
                    ClientSecrets = { new Secret("client_secret_eventapi".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedCorsOrigins = { "https://localhost:7265" },
                    AllowedScopes =
                    {
                        "EventAPI",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };

        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("EventAPI");
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("EventAPI", "Event API")
            };
    }
}
