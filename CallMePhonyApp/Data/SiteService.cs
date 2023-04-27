using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public class SiteService : ISiteService
    {
        private readonly IApiService _apiService;
        private readonly MainViewModel _mainViewModel;
        private readonly string _baseUrl;
        private readonly string _url;

        public SiteService(IApiService apiService, MainViewModel mainViewModel)
        {
            _apiService = apiService;
            _mainViewModel = mainViewModel;
            _baseUrl = "https://localhost:7215/api";
            _url = "Sites";
        }

        public async Task<Site?> GetSiteDetailsAsync(int id)
        {
            Site site = await _apiService.HttpGetAsync<Site>($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);
            if (site != null)
            {
                return site;
            }
            return null;
        }

        public async Task<IEnumerable<Site>?> GetAllSitesAsync()
        {
            IEnumerable<Site> sites = await _apiService.HttpGetAsync<IEnumerable<Site>>($"{_baseUrl}/{_url}", _mainViewModel.BearerToken);
            if (sites != null)
            {
                return sites;
            }
            return null;
        }

        public async Task<Site?> CreateNewSite(Site model)
        {
            Site site = await _apiService.HttpPostAsync<Site>($"{_baseUrl}/{_url}", model, _mainViewModel.BearerToken);
            if (site != null)
            {
                return site;
            }
            return null;
        }

        public async Task<Site?> UpdateSite(Site model)
        {
            Site site = await _apiService.HttpPutAsync<Site>($"{_baseUrl}/{_url}/{model.Id}", model, _mainViewModel.BearerToken);
            if (site != null)
            {
                return site;
            }
            return null;
        }

        public async Task<bool> DeleteSite(int id) => await _apiService.HttpDeleteAsync($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);

    }
}
