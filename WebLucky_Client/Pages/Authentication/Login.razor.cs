﻿using Microsoft.AspNetCore.Components;
using WebLucky_Client.Service.IService;

namespace WebLucky_Client.Pages.Authentication
{
    public partial class Login
    {
        private SignInRequestDTO SignInRequest = new();
        public bool IsProcessing { get; set; } = false;
        public bool ShowSignInErrors { get; set; }
        public string Errors { get; set; }

        [Inject]
        public IAuthenticationService _authService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        private async Task LoginUser()
        {
            ShowSignInErrors = false;
            IsProcessing = true;
            var result = await _authService.Login(SignInRequest);
            if (result.IsAuthSuccessful)
            {
                //await _authService.Logout();
                //_navigationManager.NavigateTo("/");
                _navigationManager.NavigateTo("/", forceLoad: true);
            }
            else
            {
                Errors = result.ErrorMessage;
                ShowSignInErrors = true;
            }
            IsProcessing = false;
        }
    }
}
