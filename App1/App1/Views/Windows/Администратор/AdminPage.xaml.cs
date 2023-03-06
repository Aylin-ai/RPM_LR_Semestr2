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
    public partial class AdminPage : ContentPage
    {
        bool loaded = false;

        public AdminPage()
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
        }
        protected internal void DisplayStack()
        {
            for (int i = 1; i <= App.db.GetCount(0); i++)
            {
                User dict = App.DB.GetUser(i);
                label.Text += dict.Login + "\n";
            }
        }
    }
}