﻿using Microsoft.UI.Xaml;
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
        private MainViewModel _mainViewModel;

        public Base Switch => _mainViewModel.pageChange;
        public MainWindow()
        {
            _mainViewModel = new MainViewModel();
            this.InitializeComponent();
        }

        private double NavViewCompactModeThresholdWidth { get { return Nav.CompactModeThresholdWidth; } }//binds with XAML Mainwindow
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        { };
        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            // You can also add items in code.
            ((NavigationView)sender).IsPaneOpen = false;
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "Town Map",
                Icon = new SymbolIcon((Symbol)0xE10F),
                Tag = "home"
            });
            _pages.Add(("home", typeof(MainWindow)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "MyDex",
                Icon = new SymbolIcon((Symbol)0xE113),
                Tag = "dex"
            });
            _pages.Add(("dex", typeof(MainWindow)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());
            Nav.MenuItems.Add(new muxc.NavigationViewItem
            {
                Content = "About",
                Icon = new SymbolIcon((Symbol)0xE11B),
                Tag = "about"
            });
            _pages.Add(("About", typeof(MainWindow)));
            Nav.MenuItems.Add(new muxc.NavigationViewItemSeparator());

        }
        private void NavigationView_ItemInvoked(muxc.NavigationView sender,
                              muxc.NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavigationView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavigationView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }
        private void NavigationView_Navigate(string navItemTag, Microsoft.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "settings")
            {
                _page = typeof(SettingsPage);
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private void NavigationView_BackRequested(muxc.NavigationView sender, muxc.NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }
        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (Nav.IsPaneOpen && (Nav.DisplayMode == muxc.NavigationViewDisplayMode.Compact || Nav.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }
        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }




    internal class SettingsPage { }

    internal class DexPage { }
    internal class AboutPage { }

}
