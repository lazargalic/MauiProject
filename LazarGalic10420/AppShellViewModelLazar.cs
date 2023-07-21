using LazarGalic10420.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420
{
    public class AppShellViewModelLazar : BaseViewModel
    {
        public bool AaaButton { get; set; } = true;

        public AppShellViewModelLazar()
        {
            AaaButton = true;

            OnPropertyChanged(nameof(AaaButton));

        }

    }
}
