using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Data
{
    public class ServiceService : IServiceService
    {
        private readonly IApiService _apiService;
        private readonly MainViewModel _mainViewModel;
        private readonly string _baseUrl;
        private readonly string _url;

        public ServiceService(IApiService apiService, MainViewModel mainViewModel)
        {
            _apiService = apiService;
            _mainViewModel = mainViewModel;
            _baseUrl = "https://localhost:7215/api";
            _url = "Services";
        }

        public async Task<Service?> GetServiceDetailsAsync(int id)
        {
            Service service = await _apiService.HttpGetAsync<Service>($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);
            if (service != null)
            {
                return service;
            }
            return null;
        }

        public async Task<IEnumerable<Service>?> GetAllServicesAsync()
        {
            IEnumerable<Service> services = await _apiService.HttpGetAsync<IEnumerable<Service>>($"{_baseUrl}/{_url}", _mainViewModel.BearerToken);
            if (services != null)
            {
                return services;
            }
            return null;
        }

        public async Task<Service?> CreateNewService(Service model)
        {
            Service service = await _apiService.HttpPostAsync<Service>($"{_baseUrl}/{_url}", model, _mainViewModel.BearerToken);
            if (service != null)
            {
                return service;
            }
            return null;
        }

        public async Task<Service?> UpdateService(Service model)
        {
            Service service = await _apiService.HttpPutAsync<Service>($"{_baseUrl}/{_url}/{model.Id}", model, _mainViewModel.BearerToken);
            if (service != null)
            {
                return service;
            }
            return null;
        }

        public async Task<bool> DeleteService(int id) => await _apiService.HttpDeleteAsync($"{_baseUrl}/{_url}/{id}", _mainViewModel.BearerToken);

    }
}
