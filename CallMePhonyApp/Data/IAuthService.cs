using CallMePhonyEntities.DTO.Requests;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public interface IAuthService
    {
        public Task<User> Login(LoginRequest request);
    }
}
