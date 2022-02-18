using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGoDexTracker.ViewModels
{
    public class MainViewModel
    {
        public Base pageChange { get; set; }

        public MainViewModel()
        {
            pageChange = new Base();
        }

    }
}
