using CallMePhonyApp.Data;
using CallMePhonyEntities.DTO.Requests;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task LogUser(string email, string password)
        {
            try
            {
                SuccessMessage = null;
                if (email == null || password == null || email == string.Empty || password == string.Empty)
                {
                    ValidationError = "L'adresse mail et le mot de passe ne doivent pas être vides";
                    return;
                }
                else if (!email.Contains('@') || !email.Contains('.'))
                {
                    ValidationError = "L'adresse mail n'est pas valide";
                    return;
                }
                LoginRequest request = new()
                {
                    Email = email,
                    Password = password,
                };
                User user = await _authService.Login(request);
                ValidationError = null;
                SuccessMessage = $"Vous êtes maintenant connecté en tant que {user.UserName}";
            }
            catch
            {
                ValidationError = "Une erreur est survenue";
            }
        }

        private string? _succesMessage { get; set; }
        public string? SuccessMessage
        {
            get => _succesMessage;
            set
            {
                _succesMessage = value;
                OnPropertyChanged();
            }
        }

        private string? _validationError { get; set; }
        public string? ValidationError
        {
            get => _validationError;
            set
            {
                _validationError = value;
                OnPropertyChanged();
            }
        }


    }
}
