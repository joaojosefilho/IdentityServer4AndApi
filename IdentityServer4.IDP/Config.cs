using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

//IDP
//My: https://localhost:44321/
//Curse: https://localhost:44379/

//API
//My: https://localhost:44390/
//Curse: https://localhost:44351/

namespace IdentityServer4.IDP
{
    public static class Config
    {

        public static List<TestUser> GetUsers() {
            return new List<TestUser> {
                new TestUser
                {
                    SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                    Username = "Frank",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name","Frank"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Main Road 1"),
                        new Claim("role","FreeUser"),
                        new Claim("subscriptionlevel","FreeUser"),
                        new Claim("country","Netherlands")
                    }
                },
                new TestUser
                {
                    SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                    Username = "Claire",
                    Password = "1234",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name","Claire"),
                        new Claim("family_name", "Underwood"),
                        new Claim("address", "Big Street 2"),
                        new Claim("role","PayingUser"),
                        new Claim("subscriptionlevel","PayingUser"),
                        new Claim("country","Belgium")
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources() {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResource("roles","Your role(s)", new List<string>(){"role"}),
                new IdentityResource("country","Your country you're living in", new List<string>(){"country"}),
                new IdentityResource("subscriptionlevel","Your subscription level", new List<string>(){"subscriptionlevel"}),

            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("identityserver4api","IndentityServer4 API", new List<string>(){"role"})
                {
                    ApiSecrets = { new Secret("apisecret".Sha256())}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "vuejs",
                    ClientId = "vuejsclient",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser=true,
                    AccessTokenType = AccessTokenType.Reference, 
                    UpdateAccessTokenClaimsOnRefresh = true, 
                    AllowOfflineAccess = true,                    
                    RequireConsent = false, 
                    //AccessTokenLifetime = 50,                    
                    RedirectUris = new List<string>()
                    {
                        "http://localhost:8080/static/callback.html",
                        "http://localhost:8080/static/silent-renew.html"
                    },                    
                    PostLogoutRedirectUris = {
                        "http://localhost:8080/index.html"
                    },
                    AllowedCorsOrigins = {
                        "http://localhost:8080"
                    },
                    //EnableLocalLogin=true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        "roles",
                        "identityserver4api",
                        "country",
                        "subscriptionlevel"
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    //AlwaysIncludeUserClaimsInIdToken=true
                }                
            };
        }

    }
}
