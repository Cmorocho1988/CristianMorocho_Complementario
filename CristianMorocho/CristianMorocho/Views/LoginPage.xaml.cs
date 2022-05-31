using CristianMorocho.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianMorocho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            CreateAdminAccount();
            InitializeComponent();
        }

        async void CreateAdminAccount()
        {
            var result = await App.Database.GetStudentsLoginAsync(1);

            if (result.Count == 0)
            {
                var studentLogin = new StudentsLogin
                {
                    User = 1,
                    Password = "uisrael2020",
                };

                await App.Database.SaveStudentsLoginAsync(studentLogin);
            }
        }
        
        async void LoginClick(object obj, EventArgs args)
        {
            if (string.IsNullOrEmpty(user.Text) || string.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Error", "Por favor ingrese nombre de usuario y contraseña", "OK");
            }
            else
            {
                var studentLogin = new StudentsLogin
                {
                    User = int.Parse(user.Text),
                    Password = password.Text,
                };

                int result = await App.Database.GetLoginStudent(studentLogin);

                if (result == 1)
                {
                    var homePage = new CRUDStudents();
                    homePage.BindingContext = new CRUDStudents();
                    Application.Current.MainPage = homePage;
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
                }
            }
        }
    }
}