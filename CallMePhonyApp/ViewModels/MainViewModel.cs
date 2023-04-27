using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool? _isAdmin = false;
        public bool? IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        private User? _currentUser;
        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
                IsAdmin = CurrentUser?.UserType == CallMePhonyEntities.Enums.UserType.Admin;
            }
        }
        private string? _bearerToken;
        public string? BearerToken
        {
            get => _bearerToken;
            set
            {
                _bearerToken = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {

        }

        public void DisconnectUser()
        {
            CurrentUser = null;
            BearerToken = null;
        }

    }
}
