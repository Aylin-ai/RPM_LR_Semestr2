using App1.ViewModels.Base;
using App1.Views.Windows;
using App1.Views.Windows.Библиотекарь;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels.Библиотекарь
{
    internal class LibrarianPageViewModel : ViewModel
    {

        #region Команды

        #region Команда для перехода на страницу с редактированием книг

        private Command bookRedactionPageCommand;

        public ICommand BookRedactionPageCommand
        {
            get
            {
                if (bookRedactionPageCommand == null)
                    bookRedactionPageCommand = new Command(OnBookRedactionPageCommandExecuted);
                return bookRedactionPageCommand;
            }
        }

        private void OnBookRedactionPageCommandExecuted(object obj)
        {
            BookRedactionPage bookRedactionPage = new BookRedactionPage();
            Application.Current.MainPage.Navigation.PushAsync(bookRedactionPage);
            bookRedactionPage.DisplayStack();
        }

        #endregion

        #region Команда для перехода на страницу с перечнем книг

        private Command bookListCommand;

        public ICommand BookListCommand
        {
            get
            {
                if (bookListCommand == null)
                {
                    bookListCommand = new Command(OnBookListCommandExecuted);
                }

                return bookListCommand;
            }
        }

        private void OnBookListCommandExecuted()
        {
            BookListPage bookListPage = new BookListPage();
            Application.Current.MainPage.Navigation.PushAsync(bookListPage);
            bookListPage.DisplayStack();
        }

        private bool CanOnBookListCommandExecute() => true;

        #endregion

        #endregion

    }
}
