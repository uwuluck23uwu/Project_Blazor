using Microsoft.AspNetCore.Components;
using WebLucky_Client.Service.IService;

namespace WebLucky_Client.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authService.Logout();
            _navigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}
