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

        public void Search(string query)
        {
            List<Site> sites = Sites.Where(s => s.Name.ToLower().Contains(query.ToLower())).ToList();
            sites.AddRange(Sites.Where(s => s.SiteType.ToString().ToLower().Contains(query.ToLower())));
            LoadedSites = sites;
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
    }
}
