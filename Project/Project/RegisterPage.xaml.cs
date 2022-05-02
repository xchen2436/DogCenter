using Project.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var user = new User()
            {
                Password = Password.Text,
                Email = Email.Text
            };

            Preferences.Clear();
            Preferences.Set("password", Password.Text);
            Preferences.Set("email", Email.Text);
            // Sign up logic goes here

            var signUpSucceeded = AreDetailsValid(user);
            if (signUpSucceeded)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if (rootPage != null)
                {

                    Navigation.InsertPageBefore(new LoginPage(), Navigation.NavigationStack.First());
                    await DisplayAlert("Success", "SignUp Successful", "OK");
                    await Navigation.PopToRootAsync();

                }
            }
            else
            {
                await DisplayAlert("Error", "SignUp Fail", "OK");
            }
        }

        bool AreDetailsValid(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }

        async void Buttonsignin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}