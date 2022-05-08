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
using Microsoft.UI.Xaml.Media.Animation;
using muxc = Microsoft.UI.Xaml.Controls;
using LetsGoDexTracker.ViewModels;
using LetsGoDexTracker.Views;
using Windows.UI.ViewManagement;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LetsGoDexTracker
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///  Page DexPage = new Page();
    public sealed partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            
            this.InitializeComponent();
           
        }

        private double NavViewCompactModeThresholdWidth { get { return Nav.CompactModeThresholdWidth; } }//binds to the Main Window
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>();//list of navigation pages 
      
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
           //create Navigate tables with symbols and names and tags to identify them upon main window load in 
            ((NavigationView)sender).IsPaneOpen = false;
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "Town Map",
                Icon = new SymbolIcon((Symbol)0xE10F),
                Tag = "home"
            });
            _pages.Add(("home", typeof(Home)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "MyDex",
                Icon = new SymbolIcon((Symbol)0xE113),
                Tag = "dex"
            });
            _pages.Add(("dex", typeof(MyDex)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "About",
                Icon = new SymbolIcon((Symbol)0xE11B),
                Tag = "about"
            });
            _pages.Add(("about", typeof(About)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            ContentFrame.Navigated += On_Navigated;

            //default page loaded into will be home page!!!
            Nav.SelectedItem = Nav.MenuItems[0];
            NavigationView_Navigate("home", new Microsoft.UI.Xaml.Media.Animation.EntranceNavigationTransitionInfo());
            
        }
        private void NavigationView_ItemInvoked(muxc.NavigationView sender,
                              muxc.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)//if settings clicked 
            {
                NavigationView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)//if other tab clicked transition their via tag
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigationView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }
        private void NavigationView_Navigate(string navItemTag, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")//navigate to settings page 
            {
                _page = typeof(Settings);
            }
            else//navigate to tab page selected
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            
            var preNavPageType = ContentFrame.CurrentSourcePageType;//store previous page to prevent duplicatation

            // handles exception 
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void NavigationView_BackRequested(muxc.NavigationView sender, muxc.NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();//go back if back arrow clicked to previous page 
        }
        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)//can we go Back?
                return false;

            if (Nav.IsPaneOpen && (Nav.DisplayMode == muxc.NavigationViewDisplayMode.Compact || Nav.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();//g back if a page has already been visited 
            return true;
        }
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);//failed to load a page
        }
        private void On_Navigated(object sender, NavigationEventArgs e)//trggered when navigation event occurs aka when user clicks settings/page
        {
            Nav.IsBackEnabled = ContentFrame.CanGoBack;//we've navigated so we can go back to prev page 

            if (ContentFrame.SourcePageType == typeof(Settings))
            {
                //if setting
                Nav.SelectedItem = (muxc.NavigationViewItem)Nav.SettingsItem;
              
            }
            else if (ContentFrame.SourcePageType != null)//if other tab 
            {
                var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

                Nav.SelectedItem = Nav.MenuItems
                    .OfType<muxc.NavigationViewItem>()
                    .First(n => n.Tag.Equals(item.Tag));

           
            }
        }
     
    }




   

}

