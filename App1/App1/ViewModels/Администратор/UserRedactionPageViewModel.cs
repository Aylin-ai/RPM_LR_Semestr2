using App1.Models;
using App1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels.Администратор
{
    internal class UserRedactionPageViewModel : ViewModel
    {
        #region Пользователи

        private List<User> _Users;

        public List<User> Users
        {
            get => _Users;
            set => Set(ref _Users, value);
        }

        #endregion

        #region Команды

        #region Команда для прогрузки пользователей

        private Command loadUsersCommand;

        public ICommand LoadUsersCommand
        {
            get
            {
                if (loadUsersCommand == null)
                    loadUsersCommand = new Command(OnLoadUsersCommandExecuted);
                return loadUsersCommand;
            }
        }

        public void OnLoadUsersCommandExecuted()
        {
            IsBusy = true;

            try
            {
                Users.Clear();
                for (int i = 0; i < Application.Current.Properties.Count; i++)
                {
                    User dict = (User)Application.Current.Properties["user №" + i];
                    Users.Add(dict);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #endregion

    }
}
