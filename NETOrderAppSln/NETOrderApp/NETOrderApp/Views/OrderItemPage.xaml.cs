using NETOrderApp;
using OrderItems.Data;
using OrderItems.Models;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NETOrderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderItemPage : ContentPage
    {
        public override IDispatcher Dispatcher => base.Dispatcher;

        public OrderItemPage()
        {
            InitializeComponent();


        }


       
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OrderItemPage
            {
                BindingContext = new OrderItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new OrderItemPage
                {
                    BindingContext = e.SelectedItem as OrderItem
                });
            }
        }
    }
}

