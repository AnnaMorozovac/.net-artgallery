using ArtGallery.Mobile.ViewModels;

namespace ArtGallery.Mobile.Views;

public partial class UserListPage : ContentPage
{
	public UserListPage(ExhibitionListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}