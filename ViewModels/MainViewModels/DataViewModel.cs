using DataModels;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.QuickCommands;
using static System.Net.Mime.MediaTypeNames;

namespace MainViewModels
{
    public class DataViewModel : ViewModelBase.ViewModelBase
    {
        private readonly DataManager data = Helper.DataModel;
        public Command LoginCommandAsync { get; }
        public AsyncCommand ReginCommandAsync { get; }
        public ObservableCollection<Apps> ApplicationsList { get; }
        public AsyncCommand AddAppAsync { get; }
        public AsyncCommand DeleteAppAsync { get; }
        public AsyncCommand InstallAppAsync { get; }
        public AsyncCommand UnintsallAppAsync { get; }
        public Computers Computer { get; }

        public DataViewModel()
        {
            LoginCommandAsync = new Command(() => 
            {
                Helper.LoginGames?.Invoke(null);
                CurrentUser = data.User.Items.FirstOrDefault(u => u.NickName == _login);
                }, LoginCanExecute, Helper.ErrorHandler);
            ReginCommandAsync = new AsyncCommand(reginCommandAsync, ReginCanExecute, Helper.ErrorHandler);
            AddAppAsync = new AsyncCommand(addNewApp, AddAppCanExecute, Helper.ErrorHandler);
            DeleteAppAsync = new AsyncCommand( deleteApp, DeleteAppCanExecute, Helper.ErrorHandler);
            //Computer = data.Computer.Items.First();
            ApplicationsList = new ObservableCollection<Apps>(data.App.Items);
        }
        private async Task reginCommandAsync(CancellationToken _)
        {
            var user = new Users()
            {
                NickName = _login,
                Password = Users.ToHashString(_password),
                FullName = _name,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Birhtday = _birthday,
                Administartor = false
            };
            Helper.ReginLogin?.Invoke(null);
            await data.User.UpdateAsync(user);
        }

        private async Task addNewApp(CancellationToken _)
        {
            var app = new Apps()
            {
                Name = _appName,
                Description = _appDescription,
                SizeMb = AppSize
            };
            await data.App.UpdateAsync(app);
            ApplicationsList.Add(app);
        }
        private async Task deleteApp(CancellationToken _)
        {
            await data.App.DeleteAsync(_selectedApp.Id);
            ApplicationsList.Remove(_selectedApp);
        }

        private bool LoginCanExecute()
        {
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            if (user == null) return false;
            return Users.ToHashString(_password)==user.Password;
        }
        private bool ReginCanExecute()
        {
            if (_login.Length < 1 && _password.Length < 1) return false;
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            return user == null;
        }
        private bool AddAppCanExecute()
        {
            var app = data.App.Items.FirstOrDefault(a => a.Name == _appName);
            if (app != null) return false;
            return true;
        }
        private bool DeleteAppCanExecute()
        {
            return true;
        }

        private Apps? _selectedApp = null;
        public Apps? SelectedApp
        {
            get { return _selectedApp; }
            set
            {
                if (Set(ref _selectedApp, value))
                {
                    DeleteAppAsync.RaiseCanExecuteChanged();
                }
            }
        }

        private Users? _currentUser = null;
        public Users? CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (Set(ref _currentUser, value))
                {
                }
            }
        }

        private string _appName = "";
        public string AppName
        {
            get { return _appName; }
            set
            {
                if (Set(ref _appName, value))
                {
                    AddAppAsync.RaiseCanExecuteChanged();
                }
            }
        }

        private string _appDescription = "";
        public string AppDescription
        {
            get { return _appDescription; }
            set
            {
                if (Set(ref _appDescription, value))
                {
                }
            }
        }

        private int _appSize = 0;
        public int AppSize
        {
            get { return _appSize; }
            set
            {
                if (Set(ref _appSize, value))
                {
                }
            }
        }

        private string _login = "";
        public string Login
        {
            get { return _login; }
            set
            {
                value = value.Trim();
                if (Set(ref _login, value))
                {
                    LoginCommandAsync.RaiseCanExecuteChanged();
                    ReginCommandAsync.RaiseCanExecuteChanged();
                }
            }
        }
        
        private string _password = "";
        public string Password
        {
            get { return _password; }
            set
            {
                if (Set(ref _password, value))
                {
                    LoginCommandAsync.RaiseCanExecuteChanged();
                    ReginCommandAsync.RaiseCanExecuteChanged();
                }
            }
        }
        private string _email = "";
        public string Email
        {
            get { return _email; }
            set
            {
                if (Set(ref _email, value))
                {
                }
            }
        }
        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (Set(ref _phoneNumber, value))
                {
                }
            }
        }
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                if (Set(ref _name, value))
                {
                }
            }
        }
        private string _birthday = "";
        public string Birthday
        {
            get { return _birthday; }
            set
            {
                if (Set(ref _birthday, value))
                {
                }
            }
        }
        private string _time = "";
        public string Time
        {
            get { return _time; }
            set
            {
                if (Set(ref _time, value))
                {
                }
            }
        }
    }
}
