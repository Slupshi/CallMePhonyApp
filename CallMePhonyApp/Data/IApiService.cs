namespace CallMePhonyApp.Data
{
    public interface IApiService
    {
        /// <summary>
        /// HttpClient GET method with json deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">string Url without the base Url</param>
        /// <param name="bearerToken">Bearer Authentication Token (JWT)</param>
        /// <returns>A json with any model inside</returns>
        public Task<T> HttpGetAsync<T>(string url, string bearerToken = null);
        /// <summary>
        /// HttpClient POST method with json deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">string Url without the base Url</param>
        /// <param name="model">The model will be pass in the request body</param>
        /// <param name="bearerToken">Bearer Authentication Token (JWT)</param>
        /// <returns>A json with any model inside</returns>
        public Task<T> HttpPostAsync<T>(string url, object model, string bearerToken = null);
        /// <summary>
        /// HttpClient PUT method with json deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">string Url without the base Url</param>
        /// <param name="model">The model will be pass in the request body</param>
        /// <param name="bearerToken">Bearer Authentication Token (JWT)</param>
        /// <returns>A json with any model inside</returns>
        public Task<T> HttpPutAsync<T>(string url, object model, string bearerToken = null);
        /// <summary>
        /// HttpClient DELETE method with json deserialization
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">string Url without the base Url</param>
        /// <param name="bearerToken">Bearer Authentication Token (JWT)</param>
        /// <returns>A json with any model inside</returns>
        public Task<bool> HttpDeleteAsync(string url, string bearerToken = null);
    }
}
