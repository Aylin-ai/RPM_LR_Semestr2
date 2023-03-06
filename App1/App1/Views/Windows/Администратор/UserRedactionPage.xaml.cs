using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views.Windows.Администратор
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRedactionPage : ContentPage
    {
        bool loaded = false;

        public UserRedactionPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (loaded == false)
            {
                DisplayStack();
                loaded = true;
            }

            for (int i = 1; i <= App.DB.GetCount(0); i++)
            {
                User user = App.DB.GetUser(i);
                stack.Children.Add(new Button() { Text = user.Login, Margin = 10 });
            }
        }
        protected internal void DisplayStack()
        {
            NavigationPage navPage = (NavigationPage)App.Current.MainPage;
            label.Text = "";
            foreach (Page p in navPage.Navigation.NavigationStack)
            {
                label.Text += p.Title + "\n";
            }
        }
    }
}