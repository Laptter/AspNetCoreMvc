using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Webgentle.BookStore.Models;

namespace Webgentle.BookStore.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
                                                     RoleManager<IdentityRole> roleManager,
                                                     IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)

        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim(nameof(ApplicationUser.FirstName), user.FirstName ?? ""));
            identity.AddClaim(new Claim(nameof(ApplicationUser.LastName), user.LastName ?? ""));
            return identity;
        }
    }
}
