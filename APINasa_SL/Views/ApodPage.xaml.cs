using APINasa_SL.ViewModels;

namespace APINasa_SL.Views;

public partial class ApodPage : ContentPage
{
	public ApodPage()
	{
        InitializeComponent();
        BindingContext = new ApodViewModel();
    }
}