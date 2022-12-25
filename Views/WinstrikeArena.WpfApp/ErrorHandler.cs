using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MainViewModels;
using ViewModelBase.Commands.ErrorHandlers;

namespace WinstrikeArena.WpfApp
{
    internal class ErrorHandler : IErrorHandler
    {
        public void ErrorHandle(Exception e)
        {
            //if (e is OverflowException)
            //{
            //    MessageBox.Show("Слишком большое число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}
            if (e is LoginExistsException)
            {
                MessageBox.Show("Логин существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
