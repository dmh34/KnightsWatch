using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    public interface IWindowAdapter
    {
        IDialogCoordinator DialogCoordinator { get; set; }
        Task<MessageDialogResult> ShowMessageDialog(string msg);
        void Close();
        IWindowAdapter CreateChildWindow();
    }
}