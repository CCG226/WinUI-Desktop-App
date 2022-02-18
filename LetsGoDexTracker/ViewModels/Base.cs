using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoDexTracker.ViewModels
{
    public class Base : Notify_Change_In_Property
    {
        private object _context;

        public object VmContext
        {
            get => _context;
            set
            {
                if (_context != value)
                {
                    _context = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SwitchVmContext(object newContext)
        {
            VmContext = newContext;
        }
    }
}
