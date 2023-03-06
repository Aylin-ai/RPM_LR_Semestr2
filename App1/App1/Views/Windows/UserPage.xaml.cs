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
            for (int i = 1; i <= App.DB.GetCount(0); i++)
            {
                User dict = App.DB.GetUser(i);
                label.Text += dict.Login + "\n";
            }
        }
    }
}