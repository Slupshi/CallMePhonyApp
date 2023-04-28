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
            // Make the query and user fields into lower cases
            LoadedUsers = Users.Where(u => u.UserName.ToLower()
                                                     .Contains(query.Trim().ToLower()) ||
                                                     (u.Site != null && u.Site.Name.ToLower().Contains(query.Trim().ToLower())) ||
                                                     u.Service != null && u.Service.Name.ToLower().Contains(query.Trim().ToLower()))
                               .ToList();
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

        public async Task AddUser(User model)
        {
            if (model.FirstName == null || model.LastName == null || model.Email == null || model.Phone == null || model.MobilePhone == null)
            {
                return;
            }
            var res = await _userService.CreateNewUser(model);
            var newUser = new User(res);
            var users = Users.ToList();
            users.Add(newUser);
            Users = users;
            ResetSearch();
            TemporaryPassword = res.TemporaryPassword;
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

        private string? _temporaryPassword;
        public string? TemporaryPassword
        {
            get => _temporaryPassword;
            set
            {
                _temporaryPassword = value;
                OnPropertyChanged();
            }
        }
    }
}
