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
    public partial class UpdateStudent : ContentPage
    {
        int id;
        
        public UpdateStudent(int id)
        {
            InitializeComponent();
            this.id = id;

            var student = App.Database.GetStudent(id).Result;

            cod.Text = student.cod_estudiante.ToString();
            nombre.Text = student.nombre;
            apellido.Text = student.apellido;
            curso.Text = student.curso;
            paralelo.Text = student.paralelo;
            nota_final.Text = student.nota_final.ToString();
        }
        
        async void SaveStudent(object obj, EventArgs args)
        {
            var student = new Students
            {
                cod_estudiante = int.Parse(cod.Text),
                nombre = nombre.Text,
                apellido = apellido.Text,
                curso = curso.Text,
                paralelo = paralelo.Text,
                nota_final = float.Parse(nota_final.Text)
            };

            await App.Database.UpdateStudentAsync(student);

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