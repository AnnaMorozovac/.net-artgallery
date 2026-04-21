using ArtGallery.Mobile.ViewModels;

namespace ArtGallery.Mobile.Views;

public partial class ExhibitionListPage : ContentPage
{
	public ExhibitionListPage(ExhibitionListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}