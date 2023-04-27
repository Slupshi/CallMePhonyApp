using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public interface IServiceService
    {
        /// <summary>
        /// Get Service's details
        /// </summary>
        /// <param name="id">The Service id</param>
        /// <returns>A Service model</returns>
        public Task<Service?> GetServiceDetailsAsync(int id);

        /// <summary>
        /// Get a Service model collection
        /// </summary>
        /// <returns>A Service model collection</returns>
        public Task<IEnumerable<Service>?> GetAllServicesAsync();

        /// <summary>
        /// Create a new Service in the database
        /// </summary>
        /// <param name="model">The Service model</param>
        /// <returns></returns>
        public Task<Service?> CreateNewService(Service model);

        /// <summary>
        /// Update a Service from the database with the new model provided
        /// </summary>
        /// <param name="model">A Service model</param>
        /// <returns>The new Service model</returns>
        public Task<Service?> UpdateService(Service model);

        /// <summary>
        /// Delete a Service from the databse
        /// </summary>
        /// <param name="id">The Service's id</param>
        /// <returns>A boolean whether the Service is deleted or not</returns>
        public Task<bool> DeleteService(int id);
    }
}
