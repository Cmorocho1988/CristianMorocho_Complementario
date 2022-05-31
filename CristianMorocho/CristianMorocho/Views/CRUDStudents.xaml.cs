using CristianMorocho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CristianMorocho.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CRUDStudents : ContentPage
    {
        public List<Students> Students = new List<Students>();
        public CRUDStudents()
        {
            InitializeComponent();

            std.ItemsSource = App.Database.GetStudentsAsync().Result;
        }

        async void DeleteStudent(object sender, EventArgs e)
        {
            var data = (Button)sender;

            await App.Database.DeleteStudentAsync(int.Parse(data.BindingContext.ToString()));
            std.ItemsSource = App.Database.GetStudentsAsync().Result;

            await DisplayAlert("Eliminado", "Estudiante eliminado", "OK");
        }
        void OpenCameraSensor(object sender, EventArgs e)
        {
            //Request permission to use the camera
            var status = Permissions.CheckStatusAsync<Permissions.Camera>().Result;

            if (status != PermissionStatus.Granted)
            {
                Permissions.RequestAsync<Permissions.Camera>().ContinueWith(t =>
                {
                    if (t.Result != PermissionStatus.Granted)
                    {
                        //Display alert to explain why you need the permission
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await DisplayAlert("Necesita permiso de cámara", "Necesitamos tu permiso para usar la cámara, pulsa OK para aprobar el permiso.", "OK");
                        });
                    }
                });
            }
        }


        void UpdateUser(object sender, EventArgs e)
        {
            var data = (Button)sender;
            
            var homePage = new UpdateStudent(int.Parse(data.BindingContext.ToString()));
            homePage.BindingContext = new UpdateStudent(int.Parse(data.BindingContext.ToString()));
            Application.Current.MainPage = homePage;
        }
        
        public void CreateStudenPage(object sender, EventArgs e)
        {
            var homePage = new CreateStudent();
            homePage.BindingContext = new CreateStudent();
            Application.Current.MainPage = homePage;
        }
    }
}