using Newtonsoft.Json;
using Appy.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Appy.Services;
using LocalizationResourceManager.Maui;

namespace Appy.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        public bool isLoading;

        private readonly IRestServiceCall _service = new RestServiceCall();
        private readonly IConnectivity _connectivity;

        public LoginPageViewModel(IConnectivity connectivity,ILocalizationResourceManager localizationResource)
            :base(localizationResource)
        {
            _connectivity = connectivity;
        }
        #region Commands
        [CommunityToolkit.Mvvm.Input.RelayCommand]
        async Task Login()
        {
            IsLoading= true;
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                IsLoading= false;
                await Shell.Current.DisplayAlert("Uh Oh!", "No Internet!", "Ok");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
                {
                    var userDetails = new UserBasicInfo();
                    var result = await _service.Login(UserName, Password,"");

                    if(result.Id==0||result==null)
                    {
                        IsLoading = false;
                        await Shell.Current.DisplayAlert("Opps", "Incorrect user Name or Passord", "Retry");
                        return;
                    }
                    userDetails = result;
                    if (Preferences.ContainsKey(nameof(App.UserDetails)))
                    {
                        Preferences.Remove(nameof(App.UserDetails));
                    }
                    IsLoading = false;
                    string userDetailStr = JsonConvert.SerializeObject(userDetails);
                    Preferences.Set(nameof(App.UserDetails), userDetailStr);
                    App.UserDetails = userDetails;
                    await AppConstant.AddFlyoutMenusDetails();
                }
            }
        }
        #endregion
    }
}
