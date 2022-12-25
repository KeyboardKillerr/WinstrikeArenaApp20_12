using System;

namespace ViewModelBase.Commands.ErrorHandlers
{

    public interface IErrorHandler
    {
        void ErrorHandle(Exception ex);
    }
    public class LoginExistsException : Exception { };
}