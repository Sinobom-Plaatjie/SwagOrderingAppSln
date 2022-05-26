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
        public SwagItem Item { get; set; }

        public OrderingDetails()
        {
            InitializeComponent();

            this.Item = new SwagItem();
            BindingContext = this;
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            SwagItemDatabase database = await SwagItemDatabase.Instance;
            await database.SaveItemAsync(Item);
            await Navigation.PopAsync();

        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            //var swagItem = (SwagItem)BindingContext;
            SwagItemDatabase database = await SwagItemDatabase.Instance;
            await database.DeleteItemAsync(Item);
            await Navigation.PopAsync();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
         await Navigation.PopAsync();
        }
    }
}