using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwagOrderingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderingDetails : ContentPage
    {
        public OrderingDetails()
        {
            InitializeComponent();

            var swagItem = new SwagItem();
            BindingContext = swagItem;

        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var swagItem = (SwagItem)BindingContext;
            SwagItemDatabase database = await SwagItemDatabase.Instance;
            await database.SaveItemAsync(swagItem);
            await Navigation.PopAsync();

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var swagItem = (SwagItem)BindingContext;
            SwagItemDatabase database = await SwagItemDatabase.Instance;
            await database.DeleteItemAsync(swagItem);
            await Navigation.PopAsync();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
         await Navigation.PopAsync();
        }
    }
}