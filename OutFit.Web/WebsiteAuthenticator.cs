using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using OutFit.CoreBusiness;
using System.Data.Entity;
using System.Security.Policy;

namespace OutFit.Web
{
    public class WebsiteAuthenticator : AuthenticationStateProvider
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private UserManager<ApplicationUser> _user;

        private readonly ProtectedLocalStorage _protectedLocalStorage;
        
        public WebsiteAuthenticator(ProtectedLocalStorage protectedLocalStorage, UserManager<ApplicationUser> user)
        {
            _protectedLocalStorage = protectedLocalStorage;
            _user = user;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var principal = new ClaimsPrincipal();

            try
            {
                var storedPrincipal = await _protectedLocalStorage.GetAsync<string>("identity");

                if (storedPrincipal.Success)
                {
                    var user = JsonConvert.DeserializeObject<ApplicationUser>(storedPrincipal.Value);
                    var (_, isLookUpSuccess) = await LookUpUser(user.UserName, user.PasswordHash);

                    if (isLookUpSuccess)
                    {
                        var identity = CreateIdentityFromUser(user);
                        principal = new(identity);
                    }
                    
                }
            }
            catch
            {

            }
            var r = new AuthenticationState(principal);
                return r;
        }

        public async Task LoginAsync(LoginDto loginFormModel)
        {
            var (userInDatabase, isSuccess) =await LookUpUser(loginFormModel.UserName, loginFormModel.Password);
            var principal = new ClaimsPrincipal();

            if (isSuccess)
            {
                var identity = CreateIdentityFromUser(userInDatabase);
                principal = new ClaimsPrincipal(identity);
                await _protectedLocalStorage.SetAsync("identity", JsonConvert.SerializeObject(userInDatabase));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public async Task LogoutAsync()
        {
            await _protectedLocalStorage.DeleteAsync("identity");
            var principal = new ClaimsPrincipal();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        private static ClaimsIdentity CreateIdentityFromUser(ApplicationUser user)
        {
            
            return new ClaimsIdentity(new Claim[]
            {
            new (ClaimTypes.Name, user.UserName),
            new (ClaimTypes.Hash, user.PasswordHash),
            }, "outfit");
            
        }

        private async Task<(ApplicationUser,bool)> LookUpUser(string username,string password)
        {
            var result =await _user.FindByEmailAsync(username);
            if (result is not null)
            {
                var r = _user.PasswordHasher.VerifyHashedPassword(result, result.PasswordHash, password);
                if (r == PasswordVerificationResult.Failed && (password != result.PasswordHash))
                {
                    return (result, result is null);
                }
            }
            return (result, result is not null);
        }
    }
}
