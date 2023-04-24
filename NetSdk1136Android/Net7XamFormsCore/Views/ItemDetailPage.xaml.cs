using Net7XamFormsCore.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Net7XamFormsCore.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}