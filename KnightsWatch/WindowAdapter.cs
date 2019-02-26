using Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using KnightsWatch.Windows;

namespace KnightsWatch
{
    class WindowAdapter : IWindowAdapter
    {
        public IDialogCoordinator DialogCoordinator { get ; set ; }
        protected Window _window;
        protected IFactory<Window> _factory;
        public WindowAdapter(Window window, IDialogCoordinator dialogCoordinator, IFactory<Window> factory)
        {
            _window = window;
            //_factory = factory;
            DialogCoordinator = dialogCoordinator;
        }

        public void Close()
        {
            _window.Close();
        }

        public virtual IWindowAdapter CreateChildWindow()
        {
            Window childWindow = _factory.Create("");

            _window.Owner = _window;
            //childWindow.DataContext = vm;
            childWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            
            return new WindowAdapter(childWindow, DialogCoordinator, _factory);
        }

        public Task<MessageDialogResult> ShowMessageDialog(string msg)
        {
            return DialogCoordinator.ShowMessageAsync(this, "Are You Sure", msg, MessageDialogStyle.AffirmativeAndNegative);
        }
    }

    internal interface IFactory<T>
    {
        T Create(string obj);
    }

    class MainWindowAdapter : WindowAdapter
    {

       
        public MainWindowAdapter(MainWindow window, IDialogCoordinator dialogCoordinator, IFactory<Window> factory) : base(window, dialogCoordinator, factory)
        {

        }

        public override IWindowAdapter CreateChildWindow()
        {
            return base.CreateChildWindow();
        }

        private void CheckIfInit()
        {
            if(_window.DataContext == null)
            {
                _window.DataContext = _factory.Create("Main");

            }
        }
    }


}
