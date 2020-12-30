using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletBasicNavigation.ViewModels
{
    public class PurpleViewModel : Screen
    {
        public void Close()
        {
            this.RequestClose(null);
        }
    }
}
