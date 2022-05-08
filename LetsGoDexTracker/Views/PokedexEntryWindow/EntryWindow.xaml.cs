using LetsGoDexTracker.PokemonModel;
using LetsGoDexTracker.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LetsGoDexTracker.Views.PokedexEntryWindow
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EntryWindow : Window
    {
        public EntryWindow(Pokemon pokemon)
        {
            this.InitializeComponent();

            EntryVM.PokemonEntry = pokemon; //set static property for the pokemon object in the entry window view model to the pokemon object selected by the user on the grid view 
        }
    }
}
