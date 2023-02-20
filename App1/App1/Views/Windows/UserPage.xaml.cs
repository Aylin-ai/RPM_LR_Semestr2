using App1.Models;
using App1.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views.Windows
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }
        protected internal void DisplayStack()
        {
            //NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            //label.Text = "";
            //foreach (Page p in navPage.Navigation.NavigationStack)
            //{
            //    label.Text += p.Title + "\n";
            //}
            for (int i = 0; i < Application.Current.Properties.Count; i++)
            {
                User dict = (User)Application.Current.Properties["user №" + i];
                label.Text += dict.Login + "\n";
            }
        }
    }
}