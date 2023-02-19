using App1.ViewModels.Base;
using App1.Views.Windows;
using App1.Views.Windows.Администратор;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels.Администратор
{
    internal class AdminPageViewModel : ViewModel
    {

        #region Команды

        #region Команда перехода на страницу редактирования пользователей

        private Command userRedactionPageCommand;

        public ICommand UserRedactionPageCommand
        {
            get
            {
                if (userRedactionPageCommand == null)
                    userRedactionPageCommand = new Command(OnUserRedactionPageCommandExecuted);
                return userRedactionPageCommand;
            }
        }

        private void OnUserRedactionPageCommandExecuted(object obj)
        {
            UserRedactionPage userRedactionPage = new UserRedactionPage();
            Application.Current.MainPage.Navigation.PushAsync(userRedactionPage);
            userRedactionPage.DisplayStack();
        }

        #endregion

        #region Команда перехода на страницу статистики 

        private Command statisticPageCommand;

        public ICommand StatisticPageCommand
        {
            get
            {
                if (statisticPageCommand == null)
                    statisticPageCommand = new Command(OnStatisticPageCommandExecuted);
                return statisticPageCommand;
            }
        }

        private void OnStatisticPageCommandExecuted(object obj)
        {
            StatisticPage statisticPage = new StatisticPage();
            Application.Current.MainPage.Navigation.PushAsync(statisticPage);
            statisticPage.DisplayStack();
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
