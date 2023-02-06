using App1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views.Windows;

namespace App1.ViewModels
{
    internal class UserPageViewModel : ViewModel
    {
        #region Данные стека страниц

        private string _PageStack;

        public string PageStack
        {
            get => _PageStack;
            set => Set(ref _PageStack, value);
        }

        #endregion

        public UserPageViewModel()
        {
        }

        #region Команды


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
