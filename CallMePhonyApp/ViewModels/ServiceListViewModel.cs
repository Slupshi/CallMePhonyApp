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

        public async Task AddService(Service model)
        {
            if (model.Name == null)
            {
                return;
            }
            var newService = await _serviceService.CreateNewService(model);
            var services = Services.ToList();
            services.Add(newService);
            Services = services;
            ResetSearch();
        }

        public async Task UpdateService()
        {
            if (SelectedService == null)
            {
                await _serviceService.UpdateService(SelectedService);
            }
        }

        public async Task DeleteService()
        {
            if (SelectedService != null && !SelectedService.Users.Any())
            {
                await _serviceService.DeleteService(SelectedService.Id);
                if (LoadedServices.Contains(SelectedService))
                {
                    var services = Services.ToList();
                    services.Remove(SelectedService);
                    LoadedServices = services;
                    Services = services;
                }
            }
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

        private Service? _selectedService;
        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                OnPropertyChanged();
            }
        }
    }
}
