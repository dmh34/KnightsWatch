/*
 * Author: D.Hall
 * Created: 8/7/18
*/

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Presentation.Interfaces;
using System;
using System.Security.Principal;
using System.Windows.Input;
using Presentation.Commands;
using System.Collections;
using System.Collections.Generic;

namespace KnightsWatch.Presentation.ViewModels
{
    public class UserViewModel : ObservableObject
    {

        
        public IIdentity AppIdentity { get; set; }
        
       


    }
}
