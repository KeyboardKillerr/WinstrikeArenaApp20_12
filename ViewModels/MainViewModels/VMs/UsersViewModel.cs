using DataModels;
using DataModels.DataProviders.Ef.Core.Repositories;
using DataModels.Entities;
using System;
using System.Collections;
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
    public class UsersViewModel : ViewModelBase.ViewModelBase
    {
        private readonly DataManager data = Helper.DataModel;
        private ObservableCollection<Users> _usersList;
        public ObservableCollection<Users> UsersList
        {
            get { return _usersList; }
            set { Set(ref _usersList, value); }
        }
        public AsyncCommand DeleteUser { get; }
        public AsyncCommand UpdateUser { get; }
        public AsyncCommand AddUser { get; }
        public Command CancelSelect { get; }
        public UsersViewModel()
        {
            DeleteUser = new(deleteUser, deleteUserCanExecute, Helper.ErrorHandler);
            UpdateUser = new(updateUser, updateUserCanExecute, Helper.ErrorHandler);
            AddUser = new(addUser, addUserCanExecute, Helper.ErrorHandler);
            CancelSelect = new(cancelSelect, cancelSelectCanExecute, Helper.ErrorHandler);
            UsersList = new(data.User.Items);
        }

        public void Refresh()
        {
            UsersList = new(data.User.Items);
            SelectedUser = null;
            Login = null;
            Password = null;
            Name = null;
            Email = null;
            PhoneNumber = null;
            Role = 1;
        }

        private async Task addUser(CancellationToken _)
        {
            if (_role < 1 || 3 < _role) Role = 1;
            var user = new Users()
            {
                NickName = _login,
                Password = Users.ToHashString(_password),
                FullName = _name,
                Email = _email,
                PhoneNumber = _phoneNumber,
                Role = _role
            };
            await data.User.UpdateAsync(user);
            Refresh();
        }
        private async Task deleteUser(CancellationToken _)
        {
            var tmp = _selectedUser;
            await data.User.DeleteAsync(_selectedUser.Id);
            Refresh();
            if (tmp.Id == Helper.CurrentUser.Id)
            {
                Helper.CurrentUser = null;
                Helper.UnlogUser?.Invoke(null);
            }
        }
        private async Task updateUser(CancellationToken _)
        {
            string login;
            string password;
            string name;
            string email;
            string phoneNumber;

            if (!string.IsNullOrEmpty(_login)) login = _login;
            else login = _selectedUser.NickName;
            if (!string.IsNullOrEmpty(_password)) password = Users.ToHashString(_password);
            else password = _selectedUser.Password;
            if (!string.IsNullOrEmpty(_name)) name = _name;
            else name = _selectedUser.FullName;
            if (!string.IsNullOrEmpty(_email)) email = _email;
            else email = _selectedUser.Email;
            if (!string.IsNullOrEmpty(_phoneNumber)) phoneNumber = _phoneNumber;
            else phoneNumber = _selectedUser.PhoneNumber;
            if (_role < 1 || 3 < _role) Role = 1;

            var user = new Users()
            {
                Id = _selectedUser.Id,
                NickName = login,
                Password = password,
                FullName = name,
                Email = email,
                PhoneNumber = phoneNumber,
                Role = _role
            };
            await data.User.UpdateAsync(user);
            Refresh();
        }
        private void cancelSelect() => Refresh();

        private bool addUserCanExecute()
        {
            if (_selectedUser != null) return false;
            var user = data.User.Items.FirstOrDefault(g => g.NickName == _login);
            if (user != null) return false;
            return true;
        }
        private bool deleteUserCanExecute()
        {
            if (_selectedUser == null) return false;
            return true;
        }
        private bool cancelSelectCanExecute()
        {
            if (_selectedUser == null) return false;
            return true;
        }
        private bool updateUserCanExecute()
        {
            if (_selectedUser == null) return false;
            var user = data.User.Items.FirstOrDefault(u => u.NickName == _login);
            if (user == null) return false;
            return true;
        }
        private bool canExecute() { return true; }

        private Users? _selectedUser = null;
        public Users? SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (Set(ref _selectedUser, value))
                {
                    if (value != null)
                    {
                        Login = value.NickName;
                        //Password = value.Password;
                        Name = value.FullName;
                        Email = value.Email;
                        PhoneNumber = value.PhoneNumber;
                        Role = value.Role;
                    }
                    DeleteUser.RaiseCanExecuteChanged();
                    CancelSelect.RaiseCanExecuteChanged();
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private string? _login;
        public string? Login
        {
            get { return _login; }
            set
            {
                if (Set(ref _login, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private string? _password;
        public string? Password
        {
            get { return _password; }
            set
            {
                if (Set(ref _password, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private string? _name;
        public string? Name
        {
            get { return _name; }
            set
            {
                if (Set(ref _name, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private string? _email;
        public string? Email
        {
            get { return _email; }
            set
            {
                if (Set(ref _email, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private string? _phoneNumber;
        public string? PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (Set(ref _phoneNumber, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }

        private int _role = 1;
        public int Role
        {
            get { return _role; }
            set
            {
                if (Set(ref _role, value))
                {
                    UpdateUser.RaiseCanExecuteChanged();
                    AddUser.RaiseCanExecuteChanged();
                }
            }
        }
    }
}
