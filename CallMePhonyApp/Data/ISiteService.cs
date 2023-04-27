using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public interface ISiteService
    {
        /// <summary>
        /// Get Site's details
        /// </summary>
        /// <param name="id">The Site id</param>
        /// <returns>A Site model</returns>
        public Task<Site?> GetSiteDetailsAsync(int id);

        /// <summary>
        /// Get a Site model collection
        /// </summary>
        /// <returns>A Site model collection</returns>
        public Task<IEnumerable<Site>?> GetAllSitesAsync();

        /// <summary>
        /// Create a new Site in the database
        /// </summary>
        /// <param name="model">The Site model</param>
        /// <returns></returns>
        public Task<Site?> CreateNewSite(Site model);

        /// <summary>
        /// Update a Site from the database with the new model provided
        /// </summary>
        /// <param name="model">A Site model</param>
        /// <returns>The new Site model</returns>
        public Task<Site?> UpdateSite(Site model);

        /// <summary>
        /// Delete a Site from the databse
        /// </summary>
        /// <param name="id">The Site's id</param>
        /// <returns>A boolean whether the Site is deleted or not</returns>
        public Task<bool> DeleteSite(int id);
    }
}
