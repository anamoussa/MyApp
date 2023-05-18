using Appy.ViewModels;
using LocalizationResourceManager.Maui;

namespace Appy;

public partial class AppShell : Shell
{
    private ILocalizationResourceManager _localizationResourceManager;
    public ILocalizationResourceManager _localization
    {
        set
        {
            this._localizationResourceManager = value;
        }
        get
        {
            return _localizationResourceManager;
        }
    }
    public AppShell(AppShellViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}
