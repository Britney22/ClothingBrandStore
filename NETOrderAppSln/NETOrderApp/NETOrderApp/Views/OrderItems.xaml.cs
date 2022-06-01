using NETOrderApp.Data;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETOrderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var orderItem = (orderItem)BindingContext;
            OrderItemDatabase database = await OrderItemDatabase.Instance;
            await database.SaveItemAsync(orderItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var orderItem = (OrderItemPage)BindingContext;
            OrderItemDatabase database = await OrderItemDatabase.Instance;
            await database.DeleteItemAsync(orderItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

