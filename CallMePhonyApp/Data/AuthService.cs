using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.DTO.Requests;
using CallMePhonyEntities.DTO.Responses;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public class AuthService : IAuthService
    {
        private readonly IApiService _apiApiService;
        private readonly MainViewModel _mainViewModel;
        private readonly string _baseUrl;
        private readonly string _url;


        public AuthService(IApiService apiApiService, MainViewModel mainViewModel)
        {
            _apiApiService = apiApiService;
            _baseUrl = "https://localhost:7215/api";
            _url = "Auth";
            _mainViewModel = mainViewModel;
        }

        public async Task<User> Login(LoginRequest request)
        {
            LoginResponse res = await _apiApiService.HttpPostAsync<LoginResponse>($"{_baseUrl}/{_url}/login", request);
            if (res.User != null)
            {
                _mainViewModel.CurrentUser = new User(res.User);
                _mainViewModel.BearerToken = res.Token;
            }
            return _mainViewModel.CurrentUser;
        }
    }
}
