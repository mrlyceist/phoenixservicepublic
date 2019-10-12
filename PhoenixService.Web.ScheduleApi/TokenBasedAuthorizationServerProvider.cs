using Microsoft.Owin.Security.OAuth;
using PhoenixService.Domain;
using PhoenixService.ScheduleApp.Specifications.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoenixService.Web.ScheduleApi
{
    public class TokenBasedAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService authenticationService;

        public TokenBasedAuthorizationServerProvider(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (!context.TryGetBasicCredentials(out var clientId, out var clientSecret))
            {
                context.SetError("invalid_client", "Invalid Authorization header");
                context.Rejected();
                return;
            }

            var client = await authenticationService.ValidateClient(clientId, clientSecret);
            if (client != null)
            {
                context.OwinContext.Set<Client>("oauth:client", client);
                context.Validated(clientId);
            }
            else
            {
                context.SetError("invalid_client", "Invalid client credentisls");
                context.Rejected();
            }
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await authenticationService.ValidateUser(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Incorrect login or password");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));

            context.Validated(identity);
        }
    }
}