using App1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views.Windows.Библиотекарь
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibrarianPage : ContentPage
    {
        bool loaded = false;

        public LibrarianPage()
        {
            InitializeComponent();
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