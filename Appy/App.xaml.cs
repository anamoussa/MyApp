using Appy.Handlers;
using Appy.Models;
using Appy.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Platform;

namespace Appy;

public partial class App : Application
{
    public static UserBasicInfo UserDetails;
    public App(AppShellViewModel viewModel)
    {
        InitializeComponent();
        //Border less entry
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });
        MainPage = new AppShell(viewModel);
    }


    protected override void OnResume()
    {
       // base.OnResume();
        WeakReferenceMessenger.Default.Send(
            new OpenWindowMessage(true));
   
    }
    protected override void OnSleep()
    {
        WeakReferenceMessenger.Default.Send(
            new OpenWindowMessage(false));
      //  base.OnSleep();
    }

}

