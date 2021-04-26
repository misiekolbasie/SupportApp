using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace SupportApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isOpenLogin = true;
        private string _loginName;
        public LoginViewModel Login { get; } = new LoginViewModel();

        public bool IsOpenLogin
        {
            get { return _isOpenLogin; }
            set { SetProperty(ref _isOpenLogin, value); }
        }

        public string LoginName
        {
            get { return _loginName; }
            set { SetProperty(ref _loginName, value); }
        }
        public ICommand LogOutCommand { get; }
        public MainWindowViewModel()
        {
          Login.LoginSuccessfuly += LoginOnLoginSuccessfuly;  
          LogOutCommand = new DelegateCommand(LogOut, () => !IsOpenLogin).ObservesProperty(() => IsOpenLogin);
        }

        private void LogOut()
        {
            LoginName = string.Empty;
            IsOpenLogin = true;
        }

        private void LoginOnLoginSuccessfuly(object sender, string loginName)
        {
            IsOpenLogin = false;
            LoginName = loginName;
        }
    }
}
