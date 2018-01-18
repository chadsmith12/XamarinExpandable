using ExpandableTest.Models;
using Xamarin.Forms;

namespace ExpandableTest
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel();
		}
	}
}
