using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GameAccess.Pages.Auth
{
    public class MyStateProvider(IJSRuntime JS) : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await JS.InvokeAsync<string>("localStorage.getItem", "token");

            if (!string.IsNullOrEmpty(token))
            {
                JwtSecurityToken jwt = new JwtSecurityToken(token);
                ClaimsIdentity currentUser = new ClaimsIdentity(jwt.Claims, "JwtAuth");
                

                return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(currentUser)));
            }

            ClaimsIdentity anonymous = new ClaimsIdentity();
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }

        public void NotifyUserChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
