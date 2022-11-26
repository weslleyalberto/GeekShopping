

using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Security.Cryptography;

namespace Project1.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),

        };
        public static IEnumerable<ApiScope> APiScopes => new List<ApiScope>
        {
            new ApiScope("geek_shopping","GeekShopping Server"),
            new ApiScope("read ","Read data."),
            new ApiScope("write","Write data."),
            new ApiScope("delete","Delete data.")

        };
        public static IEnumerable<Client> Cliets => new List<Client>
        {
            new Client
            {
                ClientId= "client",
                ClientSecrets = {new Secret("9244151d-25d1-4ef6-9de7-438e34e2701e".Sha256())},
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = {"read","write","profile"}
            },
            new Client
            {
                ClientId= "geek_shopping",
                ClientSecrets = {new Secret("9244151d-25d1-4ef6-9de7-438e34e2701e".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris = {"https://localhost:4430/signin-oidc"},
                PostLogoutRedirectUris = {"https://localhost:4430/signout-callback-oidc"},
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    "geek_shopping"
                }
            }
        };
    }
}
