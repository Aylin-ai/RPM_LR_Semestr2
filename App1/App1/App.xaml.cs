using App1.Models;
using App1.Views.Windows;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public const string DB_Name = "library1.db";
        public static TableRepos db;
        public static TableRepos DB
        {
            get
            {
                if (db == null)
                {
                    db = new TableRepos(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_Name));

                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
