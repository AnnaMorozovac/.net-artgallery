using ArtGallery.Mobile.ViewModels;

namespace ArtGallery.Mobile.Views;

public partial class CategoryListPage : ContentPage
{
	public CategoryListPage(CategoryListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}