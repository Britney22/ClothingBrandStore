using NETOrderApp.Data;
using OrderItems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETOrderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderList : ContentPage
    {
        private object listView;

        public OrderList()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            OrderItemDatabase database = await OrderItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnOrderAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderItemPage
            {
                BindingContext = new OrderItem()
            });
        }

        async void OnListOrderSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedOrder != null)
            {
                await Navigation.PushAsync(new OrderItemPage
                {
                    BindingContext = e.SelectedOrder as OrderItem
                });
            }
        }
    }
}

    