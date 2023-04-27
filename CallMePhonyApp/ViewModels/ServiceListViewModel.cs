using CallMePhonyApp.Data;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class ServiceListViewModel : ViewModelBase
    {
        private readonly IServiceService _serviceService;

        public ServiceListViewModel(IServiceService serviceService)
        {
            _serviceService = serviceService;

            GetServices();
        }

        public async Task GetServices()
        {
            Services = await _serviceService.GetAllServicesAsync();
            LoadedServices = Services.ToList();
        }

        public void Search(string query)
        {
            LoadedServices = Services.Where(s => s.Name.ToLower().Contains(query.ToLower())).ToList();
        }

        public void ResetSearch()
        {
            LoadedServices = Services.ToList();
        }

        private List<Service> _loadedServices;
        public List<Service> LoadedServices
        {
            get => _loadedServices;
            set
            {
                _loadedServices = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Service> _services;
        public IEnumerable<Service> Services
        {
            get => _services;
            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }
    }
}
