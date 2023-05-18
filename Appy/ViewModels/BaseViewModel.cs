using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;

namespace Appy.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _title;

    private ILocalizationResourceManager localizationResourceManager;

    public BaseViewModel(ILocalizationResourceManager localizationResourceManager)
    {
        this.localizationResourceManager = localizationResourceManager;
    }
    [RelayCommand]
    public void LocalizeToEN()
    {
        if (localizationResourceManager.CurrentCulture.TwoLetterISOLanguageName == "it")
        {
            localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("en");
        }
    }
    [RelayCommand]
    public void LocalizeToIT()
    {
        if (localizationResourceManager.CurrentCulture.TwoLetterISOLanguageName == "en")
        {
            localizationResourceManager.CurrentCulture = new System.Globalization.CultureInfo("it");
        }
    }
}
