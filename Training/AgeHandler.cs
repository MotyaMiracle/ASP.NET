using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Training
{
    public class AgeHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            // get claim with type ClaimTypes.DateOfBirth - year of birth
            var yearClaim = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
            if (yearClaim is not null)
            {
                // if the year of birth claim stores a number
                if (int.TryParse(yearClaim.Value, out var year))
                {
                    // and the difference between the current year and the year of birth
                    // is greater than the required age
                    if ((DateTime.Now.Year - year) >= requirement.Age)
                    {
                        context.Succeed(requirement); // signal that the claim matches the constraint
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
