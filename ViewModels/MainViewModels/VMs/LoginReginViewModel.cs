using DataModels;
using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModelBase.Commands.AsyncCommands;
using ViewModelBase.Commands.QuickCommands;

namespace MainViewModels.VMs
{
    public class LoginReginViewModel : ViewModelBase.ViewModelBase
    {
        private readonly DataManager data = Helper.DataModel;
        public Command LoginCommand { get; }
        public Command ReginCommand { get; }
        public Command UpdateCaptchaCommand { get; }
        public Command UnlogCommand { get; }
        public LoginReginViewModel()
        {
            LoginCommand = new Command(loginCommand, loginCanExecute, Helper.ErrorHandler);
            ReginCommand = new Command(reginCommand, reginCanExecute, Helper.ErrorHandler);
            UnlogCommand = new Command(unlogCommand, canExecute, Helper.ErrorHandler);
            UpdateCaptchaCommand = new Command(() =>
            {
                UpdateCaptcha();
            }, canExecute, Helper.ErrorHandler);
            GenerateCaptchaText();
        }

        public delegate void CaptchaHandler();
        public event CaptchaHandler? Notify;
        private void GenerateCaptchaText()
        {
            var captchaText = "";
            var random = new Random();
            for (var i = 0; i < 4; i++)
                captchaText += (char)random.Next('a', 'z' + 1);
            _captcha = captchaText;
            Notify?.Invoke();
        }
        private string _captcha;
        public string Captcha
        {
            get { return _captcha; }
        }
        private string _enteredCaptcha = "";
        public string EnteredCaptcha
        {
            get { return _enteredCaptcha; }
            set
            {
                value = value.Trim();
                if (Set(ref _enteredCaptcha, value))
                {
                    LoginCommand.RaiseCanExecuteChanged();
                    ReginCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private void UpdateCaptcha()
        {
            EnteredCaptcha = "";
            GenerateCaptchaText();
        }
        private bool VerifyCaptcha()
        {
            if (EnteredCaptcha != Captcha) return false;
            return true;
        }

        private async void reginCommand()
        {
            var user = new Users()
            {
                NickName = _login,
                Password = Users.ToHashString(_password),
                FullName = _name,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Birhtday = _birthday,
                Role = 1
            };
            Helper.ReginLogin?.Invoke(null);
            await data.User.UpdateAsync(user);
        }
        private void loginCommand()
        {
            UpdateCaptcha();
            CurrentUser = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            Helper.LoginGames?.Invoke(null);
            Helper.CurrentUser = CurrentUser;
        }
        private void unlogCommand()
        {
            _currentUser = null;
            Helper.CurrentUser = null;
            Helper.UnlogUser?.Invoke(null);
        }

        private bool loginCanExecute()
        {
            if (!VerifyCaptcha()) return false;
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            if (user == null) return false;
            return Users.ToHashString(_password) == user.Password;
        }
        private bool reginCanExecute()
        {
            if (_login.Length < 1 && _password.Length < 1) return false;
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            return user == null;
        }
        private bool canExecute() { return true; }

        private Users? _currentUser = null;
        public Users? CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (Set(ref _currentUser, value))
                {
                    Helper.CurrentUser = value;
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

        private bool _isModer = false;
        public bool IsModer
        {
            get { return _isModer; }
            set
            {
                if (Set(ref _isModer, value))
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
                    LoginCommand.RaiseCanExecuteChanged();
                    ReginCommand.RaiseCanExecuteChanged();
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
                    LoginCommand.RaiseCanExecuteChanged();
                    ReginCommand.RaiseCanExecuteChanged();
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
    }
}
