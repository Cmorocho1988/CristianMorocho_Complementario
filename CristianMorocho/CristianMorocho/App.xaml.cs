using CristianMorocho.Views;
using CristianMorocho.Data;
using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace CristianMorocho
{
    public partial class App : Application
    {
        static SQLiteHelper db;
        
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }
        public static SQLiteHelper Database
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Login.db3"));
                }
                return db;
            }
        }
        
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
