using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.DTO.Responses;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public class UserService : IUserService
    {
        private readonly IApiService _apiService;
        private readonly MainViewModel _mainViewModel;
        private readonly string _baseUrl;
        private readonly string _url;

        public UserService(IApiService apiService, MainViewModel mainViewModel)
        {
            _apiService = apiService;
            _mainViewModel = mainViewModel;
            _baseUrl = "https://localhost:7215/api";
            _url = "Users";
        }

        public async Task<User?> GetUserDetailsAsync(int id)
        {
            UserResponse userResponse = await _apiService.HttpGetAsync<UserResponse>($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);
            if (userResponse != null && userResponse.ErrorMessage == null)
            {
                return new User(userResponse);
            }
            return null;
        }

        public async Task<IEnumerable<User>?> GetAllUsersAsync()
        {
            UsersResponse usersResponse = await _apiService.HttpGetAsync<UsersResponse>($"{_baseUrl}/{_url}", _mainViewModel.BearerToken);
            if (usersResponse != null && usersResponse.ErrorMessage == null)
            {
                var users = new List<User>();
                foreach (var user in usersResponse.Users)
                {
                    users.Add(new User(user));
                }
                return users;
            }
            return null;
        }

        public async Task<string?> CreateNewUser(User model)
        {
            UserResponse response = await _apiService.HttpPostAsync<UserResponse>($"{_baseUrl}/{_url}", model, _mainViewModel.BearerToken);
            if (response != null && response.ErrorMessage == null)
            {
                return response.TemporaryPassword;
            }
            return null;
        }

        public async Task<User?> UpdateUser(User model)
        {
            UserResponse userResponse = await _apiService.HttpPutAsync<UserResponse>($"{_baseUrl}/{_url}/{model.Id}", model, _mainViewModel.BearerToken);
            if (userResponse != null && userResponse.ErrorMessage == null)
            {
                return new User(userResponse);
            }
            return null;
        }

        public async Task<bool> DeleteUser(int id) => await _apiService.HttpDeleteAsync($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);

    }
}
