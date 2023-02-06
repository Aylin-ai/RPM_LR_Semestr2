using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookInformationPage : ContentPage
    {
        public BookInformationPage()
        {
            InitializeComponent();
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