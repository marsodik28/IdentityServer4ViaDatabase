using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using static IdentityModel.OidcConstants;

namespace IdpServer.Configuration
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            using (IDbConnection db = new SqlConnection("Server=localhost;Database=dbo.EmployeeData;Trusted_connection=True;"))
            {
                var user = db.Query<Models.User>("SELECT * FROM dbo.Account WHERE Username=@Username AND Password=@Password",
                new { Username = context.UserName, Password = context.Password }).SingleOrDefault();

                if (user == null)
                {
                    context.Result = new GrantValidationResult(TokenErrors.InvalidRequest, "Username or Password Incorect");
                    return Task.FromResult(0);
                }

                context.Result = new GrantValidationResult(user.Id.ToString(), "Password");
                return Task.FromResult(0);
            }
        }
    }
}
