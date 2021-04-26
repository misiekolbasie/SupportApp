using System;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;

namespace SupportApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string _login;
        public event EventHandler<string> LoginSuccessfuly;
        public string Login
        {
            get { return _login; }
            set { SetProperty(ref _login, value); }
        }

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        public LoginViewModel()
        {
            SignInCommand = new DelegateCommand(SignIn, () => !string.IsNullOrWhiteSpace(_login)).ObservesProperty(() => Login);
            SignUpCommand = new DelegateCommand(SignUp, () => !string.IsNullOrWhiteSpace(_login)).ObservesProperty(() => Login);

        }

        private void SignIn()
        {
            OnLoginSuccessfuly(Login);
            Login = string.Empty;
        }

        private void SignUp()
        {
            OnLoginSuccessfuly(Login);
            Login = string.Empty;
        }

        protected virtual void OnLoginSuccessfuly(string login)
        {
            LoginSuccessfuly?.Invoke(this, login);
        }
    }
}
