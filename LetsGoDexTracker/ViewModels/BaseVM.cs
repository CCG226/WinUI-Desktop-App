using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoDexTracker.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;//event type to handle property changed
        private void OnPropertyChanged(string propertyName)//fires event
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));//make sure event exists and invoke a event if property changes in view or model
        }

        public void SwitchVmContext(object newContext)
        {
            VmContext = newContext;
        }
    }
}
