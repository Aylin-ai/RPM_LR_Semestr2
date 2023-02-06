using App1.ViewModels.Base;
using App1.Views.Windows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    internal class BookListPageViewModel : ViewModel
    {
        #region Команды


        #region Команда перехода к информации о книге

        private Command bookInformationCommand;

        public ICommand BookInformationCommand
        {
            get
            {
                if (bookInformationCommand == null)
                    bookInformationCommand = new Command(OnBookInformationCommandExecuted);

                return bookInformationCommand;
            }

        }

        private void OnBookInformationCommandExecuted()
        {
            BookInformationPage bookInformationPage = new BookInformationPage();
            Application.Current.MainPage.Navigation.PushAsync(bookInformationPage);
            bookInformationPage.DisplayStack();
        }

        private bool CanBookInformationCommandExecute() => true;

        #endregion

        #endregion
    }
}
