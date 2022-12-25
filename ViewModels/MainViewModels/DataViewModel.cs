using DataModels;
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.QuickCommands;

namespace MainViewModels
{
    public class DataViewModel : ViewModelBase.ViewModelBase
    {
        private readonly DataManager data = Helper.DataModel;
        public Command LoginCommandAsync { get; }
        public AsyncCommand ReginCommandAsync { get; }
        public ObservableCollection<Games> Games { get; set; }
        public Users CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (Set(ref _currentUser, value))
                {
                    IsAdmin = _currentUser.Administartor;
                }
            }
        }

        private bool _isAdmin = false;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (Set(ref _isAdmin, value))
                {
                }
            }
        }
        private Users _currentUser = null;

        public DataViewModel()
        {
            LoginCommandAsync = new Command(() => 
            {
                Helper.LoginGames?.Invoke(null);
                CurrentUser = data.User.Items.FirstOrDefault(u => u.NickName == _login);
                }, LoginCanExecute, Helper.ErrorHandler);
            ReginCommandAsync = new AsyncCommand(reginCommandAsync, ReginCanExecute, Helper.ErrorHandler);
            Games = new ObservableCollection<Games>(data.Game.Items.Include(u => u.GamesGenres));
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

        private bool LoginCanExecute()
        {
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            if (user == null) return false;
            //var rate = data.Rate.Items.FirstOrDefault(r => r.Users == )
            return Users.ToHashString(_password)==user.Password;
        }

        private bool ReginCanExecute()
        {
            if (_login.Length < 1 && _password.Length < 1) return false;
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            return user == null;
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
