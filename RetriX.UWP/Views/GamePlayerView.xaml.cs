﻿using MvvmCross;
using MvvmCross.Platforms.Uap.Views;
using RetriX.Shared.Services;
using RetriX.Shared.ViewModels;

namespace RetriX.UWP.Pages
{
    public sealed partial class GamePlayerView : MvxWindowsPage
    {
        public GamePlayerViewModel VM => ViewModel as GamePlayerViewModel;
        private VideoService Renderer { get; } = Mvx.IoCProvider.Resolve<IVideoService>() as VideoService;

        public GamePlayerView()
        {
            InitializeComponent();
            Unloaded += OnUnloading;

            Renderer.RenderPanel = PlayerPanel;
        }

        private void OnUnloading(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Renderer.RenderPanel = null;
            PlayerPanel.RemoveFromVisualTree();
        }
    }
}
