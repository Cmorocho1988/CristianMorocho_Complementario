using CristianMorocho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianMorocho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateStudent : ContentPage
    {
        public CreateStudent()
        {
            InitializeComponent();
        }

        async void SaveStudent(object obj, EventArgs args)
        {
            var student = new Students
            {
                nombre = nombre.Text,
                apellido = apellido.Text,
                curso = curso.Text,
                paralelo = paralelo.Text,
                nota_final = float.Parse(nota_final.Text)
            };

            await App.Database.SaveStudentAsync(student);

            await DisplayAlert("Guardado", "El estudiante ha sido guardado", "OK");
        }


        void BackToHome(object obj, EventArgs args)
        {
            var homePage = new CRUDStudents();
            homePage.BindingContext = new CRUDStudents();
            Application.Current.MainPage = homePage;
        }
    }
}