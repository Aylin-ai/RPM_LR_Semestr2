using App1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using App1.Views.Windows;
using Xamarin.Essentials;
using System.IO;

namespace App1.ViewModels
{
    internal class UserPageViewModel : ViewModel
    {

        #region Путь к фото

        private ImageSource _PhotoPath;

        public ImageSource PhotoPath
        {
            get { return _PhotoPath; }
            set => Set(ref _PhotoPath, value);
        }

        #endregion

        #region Сообщение об ошибке

        private string _Error;

        public string Error
        {
            get => _Error;
            set => Set(ref _Error, value);
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

        #region Команда для создания фото

        private Command takePhotoCommand;

        public ICommand TakePhotoCommand
        {
            get
            {
                if (takePhotoCommand == null)
                    takePhotoCommand = new Command(OnTakePhotoCommandExecute);
                return takePhotoCommand;
            }
        }

        private async void OnTakePhotoCommandExecute(object obj)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                // загружаем в ImageView
                PhotoPath = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        #endregion

        #region Команда для выбора фото

        private Command getPhotoCommand;

        public ICommand GetPhotoCommand
        {
            get
            {
                if (getPhotoCommand == null)
                    getPhotoCommand = new Command(OnGetPhotoCommandExecute);
                return getPhotoCommand;
            }
        }

        private async void OnGetPhotoCommandExecute(object obj)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                PhotoPath = ImageSource.FromFile(photo.FullPath);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
        }

        #endregion

        #endregion
    }
}
