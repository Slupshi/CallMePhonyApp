using CallMePhonyEntities.DTO.Responses;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public interface IUserService
    {
        /// <summary>
        /// Get User's details
        /// </summary>
        /// <param name="id">The user id</param>
        /// <returns>A User model</returns>
        public Task<User?> GetUserDetailsAsync(int id);

        /// <summary>
        /// Get a User model collection
        /// </summary>
        /// <returns>A User model collection</returns>
        public Task<IEnumerable<User>?> GetAllUsersAsync();

        /// <summary>
        /// Create a new User in the database
        /// </summary>
        /// <param name="model">The User model</param>
        /// <returns></returns>
        public Task<UserResponse?> CreateNewUser(User model);

        /// <summary>
        /// Update a user from the database with the new model provided
        /// </summary>
        /// <param name="model">A User model</param>
        /// <returns>The new User model</returns>
        public Task<User?> UpdateUser(User model);

        /// <summary>
        /// Delete a user from the databse
        /// </summary>
        /// <param name="id">The User's id</param>
        /// <returns>A boolean whether the user is deleted or not</returns>
        public Task<bool> DeleteUser(int id);
    }
}
