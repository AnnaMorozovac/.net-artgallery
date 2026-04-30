using ArtGallery.Mobile.ViewModels;

namespace ArtGallery.Mobile.Views;

public partial class LoginListPage : ContentPage
{
	public LoginListPage(ExhibitionListViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}