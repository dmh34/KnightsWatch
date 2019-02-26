using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;

namespace Presentation.Interfaces
{
    public interface IDialogAdapter
    {
        Task<MessageDialogResult> ShowMessageDialogOKCanel(string header, string message);
        Task<ProgressDialogController> ShowProgress(string header, string message);
        
    }
}
