using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Project.Database;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
       
    {
       
        public LoginPage()
        {
            InitializeComponent();
        }
        async void LoginEvent(object sender, EventArgs e)
        {
            var loginUser = new User
            {

                Email = Email.Text,
                Password = Password.Text
            };

            var templateUser = Preferences.Get("email", "");
            
            var templatePass = Preferences.Get("password", "");
          

            var isValid = AreCredentialsCorrect(loginUser);
            if (isValid)
            {
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else if (Email.Text=="admin@gmail.com" && Password.Text == "123456") 
            {
                await Navigation.PushAsync(new CheckoutPage());
                
                
            }
            else
            {
                await DisplayAlert("Alert", "Email or Password invalid ", "OK");
            }
        }

        async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Email == Preferences.Get("email", "default") && user.Password == Preferences.Get("password", "default");
        }


    }
}