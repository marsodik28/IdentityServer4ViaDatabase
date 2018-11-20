using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdpServer.Configuration
{
    public class Scopes
    {
        public static List<ApiResource> GetScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource("myApi", "My API")
            };
        }
    }
}
