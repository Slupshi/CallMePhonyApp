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
            var results = Users.Where(u => u.UserName.ToLower().Contains(query.Trim().ToLower())).ToList();
            results.AddRange(Users.Where(u => u.Site != null && u.Site.Name.ToLower().Contains(query.Trim().ToLower())));
            results.AddRange(Users.Where(u => u.Service != null && u.Service.Name.ToLower().Contains(query.Trim().ToLower())));
            LoadedUsers = results;
        }

        public void ResetSearch()
        {
            LoadedUsers = Users.ToList();
        }

        public async Task ModifyUser()
        {
            if (SelectedUser == null)
            {
                await _userService.UpdateUser(SelectedUser);
            }
        }

        public async Task DeleteUser()
        {
            if (SelectedUser != null)
            {
                await _userService.DeleteUser(SelectedUser.Id);
                if (LoadedUsers.Contains(SelectedUser))
                {
                    var users = Users.ToList();
                    users.Remove(SelectedUser);
                    LoadedUsers = users;
                    Users = users;
                }
            }
        }

        public async Task GetUsers()
        {
            Users = await _userService.GetAllUsersAsync();
            LoadedUsers = Users.ToList();
        }

        private List<User> _loadedUsers;
        public List<User> LoadedUsers
        {
            get => _loadedUsers;
            set
            {
                _loadedUsers = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<User> _users;
        public IEnumerable<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private User? _selectedUser;
        public User? SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
    }
}
