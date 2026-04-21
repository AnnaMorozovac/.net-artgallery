using ArtGallery.Mobile.ViewModels;

namespace ArtGallery.Mobile.Views;

public partial class ArtworkListPage : ContentPage
{
	public ArtworkListPage(ArtworkListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}