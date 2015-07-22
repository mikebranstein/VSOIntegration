using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Filters
{

    namespace BasicAuthentication.Filters
    {
        public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
        {
            protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
            {
                if (Security.Authentication.Username != userName || Security.Authentication.Password != password)
                {
                    // userName/password is not valid
                    return null;
                }

                // Create a ClaimsIdentity with all the claims for this user.
                cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, IClaimsIdenityFactory doesn't support CancellationTokens.

                ClaimsIdentity identity = new ClaimsIdentity();
                identity.AddClaim(new Claim("Basic", userName));
                return new ClaimsPrincipal(identity);
            }
        }
    }
}