using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace LetsGoDexTracker.ViewModels
{
    public class Notify_Change_In_Property : INotifyPropertyChanged// for when a property value change occurs 
    {
        public event PropertyChangedEventHandler PropertyChanged;//event declaration
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)//raise event with calling members name as parameter
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
