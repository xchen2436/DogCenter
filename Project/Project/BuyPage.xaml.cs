using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyPage : ContentPage
    {
        public BuyPage()
        {
            InitializeComponent();
        }

        

        async void ButtonBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void ButtonBuy_Clicked(object sender, EventArgs e)
        {
            var txt1 = idEntry.Text;
            var txt2 = firstName.Text;
            var txt3 = lastName.Text;
            var txt4 = Phone.Text;
            var txt5 = address.Text;  
            if (idEntry.Text == null)
            {
                DisplayAlert("Empty", "Please enter id.", "OK");
            }
            if (firstName.Text == null)
            {
                DisplayAlert("Empty", "Please enter firstName.", "OK");
            }
            if (lastName.Text == null)
            {
                DisplayAlert("Empty", "Please enter lastName.", "OK");
            }
            if (Phone.Text == null)
            {
                DisplayAlert("Empty", "Please enter Phone Number.", "OK");
            }
            if (address.Text == null)
            {
                DisplayAlert("Empty", "Please enter Address.", "OK");
            }
           
            else if (txt1 != null) {
                Checkout id = new Checkout()
                {                    
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Phone = Phone.Text,
                    DogId = idEntry.Text,
                    Address = address.Text
                                     
                };
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Checkout>();
                    int row = conn.Insert(id);
                    if (row > 0)
                    {
                        DisplayAlert("Success", "Congratulations!!! Our customer service will contact with you ASAP", "OK");
                    }
                    else
                    {
                        DisplayAlert("Failed", "Info is not added", "OK");
                    }
                    Navigation.PushAsync(new MainPage());
                }


            }
            
            else
            {
                DisplayAlert("Error", "Please enter your info.", "OK");
            }
            

        }
    }
}