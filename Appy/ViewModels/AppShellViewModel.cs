using Appy.Views.Startup;
using LocalizationResourceManager.Maui;

namespace Appy.ViewModels;

public partial class AppShellViewModel : BaseViewModel
{
    public AppShellViewModel(ILocalizationResourceManager localizationResourceManager) 
        : base(localizationResourceManager)
    {
    }

    [CommunityToolkit.Mvvm.Input.RelayCommand]
    async void SignOut()
    {
        if (Preferences.ContainsKey(nameof(App.UserDetails)))
        {
            Preferences.Remove(nameof(App.UserDetails));
        }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    
    }
}
