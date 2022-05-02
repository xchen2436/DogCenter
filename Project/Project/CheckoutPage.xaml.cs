using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Project.Database;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckoutPage : ContentPage
    {
        
        public CheckoutPage()
        {
            InitializeComponent();
            

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Checkout>();
                var checkouts = conn.Table<Checkout>().ToList();
                checkoutListView.ItemsSource = checkouts;
            }
        }
      
       
    }
}