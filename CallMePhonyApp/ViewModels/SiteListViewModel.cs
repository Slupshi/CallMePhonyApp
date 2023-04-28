using CallMePhonyApp.Data;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.ViewModels
{
    public class SiteListViewModel : ViewModelBase
    {
        private readonly ISiteService _siteService;

        public SiteListViewModel(ISiteService siteService)
        {
            _siteService = siteService;

            GetSites();
        }

        public async Task GetSites()
        {
            Sites = await _siteService.GetAllSitesAsync();
            LoadedSites = Sites.ToList();
        }

        public async Task UpdateSite(Site model)
        {
            if (SelectedSite != null && model.Name != null || model.Name != string.Empty)
            {
                var sites = Sites.ToList();
                sites.Remove(SelectedSite);
                SelectedSite.Name = model.Name;
                SelectedSite.SiteType = model.SiteType;
                SelectedSite = await _siteService.UpdateSite(SelectedSite);
                sites.Add(SelectedSite);
                Sites = sites;
                ResetSearch();
            }
        }

        public async Task DeleteSite()
        {
            if (SelectedSite != null && !SelectedSite.Users.Any())
            {
                await _siteService.DeleteSite(SelectedSite.Id);
                if (LoadedSites.Contains(SelectedSite))
                {
                    var sites = Sites.ToList();
                    sites.Remove(SelectedSite);
                    LoadedSites = sites;
                    Sites = sites;
                }
            }
        }

        public async Task AddService(Site model)
        {
            if (model.Name == null || model.SiteType == null)
            {
                return;
            }
            var newsite = await _siteService.CreateNewSite(model);
            var sites = Sites.ToList();
            sites.Add(newsite);
            Sites = sites;
            ResetSearch();
        }

        public void Search(string query)
        {
            LoadedSites = Sites.Where(s => s.Name.ToLower().Contains(query.ToLower()) || s.SiteType.ToString().ToLower().Contains(query.ToLower())).ToList();
        }

        public void ResetSearch()
        {
            LoadedSites = Sites.ToList();
        }

        private List<Site> _loadedSites;
        public List<Site> LoadedSites
        {
            get => _loadedSites;
            set
            {
                _loadedSites = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Site> _sites;
        public IEnumerable<Site> Sites
        {
            get => _sites;
            set
            {
                _sites = value;
                OnPropertyChanged();
            }
        }

        private Site _selectedSite;
        public Site SelectedSite
        {
            get => _selectedSite;
            set
            {
                _selectedSite = value;
                OnPropertyChanged();
            }
        }
    }
}
