using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwagOrderingApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwagListPage : ContentPage
    {
        public SwagListPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            SwagItemDatabase database = await SwagItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderingDetails
            {
                BindingContext = new SwagItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new OrderingDetails
                {
                    BindingContext = e.SelectedItem as SwagItem
                });
            }
        }
    }
}