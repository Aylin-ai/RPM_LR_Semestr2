using App1.ViewModels.Base;
using App1.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    internal class BookInformationPAgeViewModel : ViewModel
    {
        #region Команды


        #region Команда для перехода на страницу чтения книги

        private Command readBookCommand;

        public ICommand ReadBookCommand
        {
            get
            {
                if (readBookCommand == null)
                {
                    readBookCommand = new Command(OnReadBookCommandExecuted);
                }

                return readBookCommand;
            }
        }

        private void OnReadBookCommandExecuted(object obj)
        {
            BookReadPage bookReadPage = new BookReadPage();
            Application.Current.MainPage.Navigation.PushAsync(bookReadPage);
            bookReadPage.DisplayStack();
        }

        #endregion


        #endregion
    }
}
