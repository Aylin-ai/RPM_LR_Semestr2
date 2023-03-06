using App1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views.Windows;
using App1.Views.Windows.Администратор;
using App1.Views.Windows.Библиотекарь;
using App1.Models;

namespace App1.ViewModels
{
    internal class MainPageViewModel : ViewModel
    {
        #region Данные для регистрации

        private string _Login;
        private string _Password1;
        private string _Password2;
        private DateTime _DateOfBirth;
        private string _TelephonNumber;
        private string _Email;

        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }
        public string Password1
        {
            get => _Password1;
            set => Set(ref _Password1, value);
        }
        public string Password2
        {
            get => _Password2;
            set => Set(ref _Password2, value);
        }
        public DateTime DateOfBirth
        {
            get => _DateOfBirth;
            set => Set(ref _DateOfBirth, value);
        }
        public string TelephoneNumber
        {
            get => _TelephonNumber;
            set => Set(ref _TelephonNumber, value);
        }
        public string Email
        {
            get => _Email;
            set => Set(ref _Email, value);
        }

        #endregion

        #region Данные стека страниц

        private string _PageStack;

        public string PageStack
        {
            get => _PageStack;
            set => Set(ref _PageStack, value);
        }

        #endregion

        #region Данные о выбранной роли

        private int _Index = 1;

        public int Index
        {
            get => _Index;
            set => Set(ref _Index, value);
        }

        #endregion

        #region Данные о ролях в системе

        private string[] _Roles = { "Пользователь", "Администратор", "Библиотекарь"};
        
        public string[] Roles
        {
            get => _Roles;
            set => Set(ref _Roles, value);
        } 

        #endregion

        #region Команды


        #region Команда для смены темы страницы
        public Command ThemeChangeCommand { get; }

        private void OnThemeChangeCommandExecuted(object obj)
        {

        }

        private bool CanThemeChangeCommandExecute(object obj)
        {
            return true;
        }
        #endregion

        #region Команда для перехода на страницу с личным кабинетом пользователя

        private Command nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (Index == 0)
                {
                    nextPageCommand = new Command(OnUserPageComandExecuted);
                }
                else if (Index == 1)
                {
                    nextPageCommand = new Command(OnAdminPageExecuted);
                }
                else if (Index == 2)
                {
                    nextPageCommand = new Command(OnLibrarianPageExecuted);
                }
                return nextPageCommand;
            }
        }

        private void OnUserPageComandExecuted()
        {
            if (App.DB.GetCount(0) != 0)
            {
                for (int i = 1; i <= App.DB.GetCount(0); i++)
                {
                    if (Login == App.DB.GetUser(i).Login)
                    {
                        Application.Current.MainPage.DisplayAlert("Ошибка", "Логин занят", "Ок");
                        Login = "";
                        break;
                    }
                }
            }
            if (Login != "" && Password1 != "" && Password2 != "")
            {
                if (Password1 == Password2)
                {

                    User user = new User(Login, Password1, DateOfBirth.ToString(),
                        TelephoneNumber, Email, Roles[Index]);

                    App.DB.SaveUser(user);

                    UserPage userPage = new UserPage();
                    Application.Current.MainPage.Navigation.PushAsync(userPage);
                    userPage.DisplayStack();

                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Ошибка", "Пароли не совпадают", "Ок");
                    Password1 = "";
                    Password2 = "";
                }
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Ошибка", "Не введены ключевые данные", "Ок");

            }
        }

        private void OnAdminPageExecuted()
        {
            if (App.DB.GetCount(0) != 0)
            {
                for (int i = 1; i <= App.DB.GetCount(0); i++)
                {
                    if (Login == App.DB.GetUser(i).Login)
                    {
                        Application.Current.MainPage.DisplayAlert("Ошибка", "Логин занят", "Ок");
                        Login = "";
                        break;
                    }
                }
            }
                if (Login != "" && Password1 != "" && Password2 != "")
                {
                    if (Password1 == Password2)
                    {

                        User user = new User(Login, Password1, DateOfBirth.ToString(),
                            TelephoneNumber, Email, Roles[Index]);

                        App.DB.SaveUser(user);

                        AdminPage adminPage = new AdminPage();
                        Application.Current.MainPage.Navigation.PushAsync(adminPage);
                        adminPage.DisplayStack();

                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Ошибка", "Пароли не совпадают", "Ок");
                        Password1 = "";
                        Password2 = "";
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Ошибка", "Не введены ключевые данные", "Ок");

                }
        }

        private void OnLibrarianPageExecuted()
        {
            if (App.DB.GetCount(0) != 0)
            {
                for (int i = 1; i <= App.DB.GetCount(0); i++)
                {
                    if (Login == App.DB.GetUser(i).Login)
                    {
                        Application.Current.MainPage.DisplayAlert("Ошибка", "Логин занят", "Ок");
                        Login = "";
                        break;
                    }
                }
            }
                if (Login != "" && Password1 != "" && Password2 != "")
                {
                    if (Password1 == Password2)
                    {

                        User user = new User(Login, Password1, DateOfBirth.ToString(),
                            TelephoneNumber, Email, Roles[Index]);

                        App.DB.SaveUser(user);

                        LibrarianPage librarianPage = new LibrarianPage();
                        Application.Current.MainPage.Navigation.PushAsync(librarianPage);
                        librarianPage.DisplayStack();

                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert("Ошибка", "Пароли не совпадают", "Ок");
                        Password1 = "";
                        Password2 = "";
                    }
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Ошибка", "Не введены ключевые данные", "Ок");

                }
        }

        #endregion


        #endregion

    }
}
