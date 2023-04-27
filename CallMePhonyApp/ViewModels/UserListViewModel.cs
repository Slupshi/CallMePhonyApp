using CallMePhonyApp.Data;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class UserListViewModel : ViewModelBase
    {
        private readonly IUserService _userService;

        public UserListViewModel(IUserService userService)
        {
            _userService = userService;

            GetUsers();
        }

        public void Search(string query)
        {
            // Make the query and username into lower cases
            LoadedUsers = Users.Where(u => u.UserName.ToLower().Contains(query.Trim().ToLower()));
        }

        public void ResetSearch()
        {
            LoadedUsers = Users;
        }

        public async Task GetUsers()
        {
            Users = await _userService.GetAllUsersAsync();
            LoadedUsers = Users;
        }

        private IEnumerable<User> _loadedUsers { get; set; }
        public IEnumerable<User> LoadedUsers
        {
            get => _loadedUsers;
            set
            {
                _loadedUsers = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<User> _users { get; set; }
        public IEnumerable<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private string _searchRequest { get; set; }
        public string SearchRequest
        {
            get => _searchRequest;
            set
            {
                _searchRequest = value;
                OnPropertyChanged();
            }
        }
    }
}
