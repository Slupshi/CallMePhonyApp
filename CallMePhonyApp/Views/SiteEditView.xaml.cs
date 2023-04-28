using CallMePhonyApp.ViewModels;
using CallMePhonyEntities.Enums;
using CallMePhonyEntities.Models;

namespace CallMePhonyApp.Views;

public partial class SiteEditView : ContentPage
{
    private readonly SiteListViewModel _viewModel;

    public SiteEditView(SiteListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;

        SiteNameEntry.Text = _viewModel.SelectedSite.Name;
        SiteTypePicker.SelectedItem = _viewModel.SelectedSite.SiteType.ToString();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var editedSite = new Site()
        {
            Name = SiteNameEntry.Text,
            SiteType = SiteTypePicker.SelectedItem.ToString() == "Administration" ? SiteType.Administration : SiteType.Production,
        };

        await _viewModel.UpdateSite(editedSite);
    }
}