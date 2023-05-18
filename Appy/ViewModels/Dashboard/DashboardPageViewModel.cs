using Appy.Controls;
using LocalizationResourceManager.Maui;

namespace Appy.ViewModels.Dashboard;

public partial class DashboardPageViewModel : BaseViewModel
{
    public DashboardPageViewModel(ILocalizationResourceManager localizationResourceManager)
        :base(localizationResourceManager)
    {
        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
    }
}
