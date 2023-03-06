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

        private IEnumerable<User> _Users;

        public IEnumerable<User> Users
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

            Users = App.DB.GetUsers();
        }

        #endregion

        #region Команда для удаления всех пользователей

        private Command deleteAllUsersCommand;

        public ICommand DeleteAllUsersCommand
        {
            get
            {
                if (deleteAllUsersCommand == null)
                {
                    deleteAllUsersCommand = new Command(OnDeleteAllUsersCommandExecuted);
                }
                return deleteAllUsersCommand;
            }
        }

        private void OnDeleteAllUsersCommandExecuted()
        {
            App.DB.DeleteUsers();
        }

        #endregion

        #endregion

    }
}
