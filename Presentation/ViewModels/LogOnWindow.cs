using MahApps.Metro.Controls.Dialogs;
using Presentation.Commands;
using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KnightsWatch.Presentation.ViewModels
{
    public class LogOnWindowViewModel
    {

        //TODO unit test
        
        private IAuthenticationService authenticationService;
        private IWindowAdapter windowAdapter;

        public UserViewModel ViewModel { get; set; }
        public ICommand LogOnCommand { get; private set; }
        public ICommand CloseWindowCommand { get; private set; }


        public LogOnWindowViewModel(UserViewModel viewModel, IWindowAdapter windowAdapater, IAuthenticationService authenticationService)
        {
            ViewModel = viewModel;
            windowAdapter = windowAdapater ?? throw new ArgumentException("Adapter");
            this.authenticationService = authenticationService ?? throw new ArgumentException("Service");
            

            LogOnCommand = new DelegateCommand(LogOn, null);
            CloseWindowCommand = new DelegateCommand(CloseWindow, null);

        }

        private async void LogOn()
        {
            var result = await authenticationService.GetUser();
            ViewModel.AppIdentity = result;
        }

        private void CloseWindow()
        {
            windowAdapter.Close();
        }

    }
}
