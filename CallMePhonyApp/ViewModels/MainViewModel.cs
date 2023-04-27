using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public User CurrentUser { get; set; }

        public MainViewModel()
        {

        }

        public void LogUser()
        {

        }

        public void DisconnectUser()
        {
            CurrentUser = null;
        }

    }
}
