﻿using Appy.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalizationResourceManager.Maui;
using System.Web;

namespace Appy.ViewModels;
public partial class WebViewViewModel : BaseViewModel, IQueryAttributable
{
    [ObservableProperty]
    public string source;

    [ObservableProperty]
    public bool isLoading;
    private readonly IRestServiceCall _service = new RestServiceCall();
    public WebViewViewModel(ILocalizationResourceManager localizationResourceManager)
        :base(localizationResourceManager)
    {
        // TODO: Update the default URL
        IsLoading = true;
    }

    private async Task<string> putDatain_webView(string search)
    {
        //  if (result is not null && result != "")
        if (String.IsNullOrEmpty(search))
            return null;
        var res = await _service.Search(search, "zzzzzzzz");
        if (res is null)
            return null;
        return res.webview.ToString();
    }

    [RelayCommand]
    private async void WebViewNavigated(WebNavigatedEventArgs e)
    {
        IsLoading = false;

        if (e.Result != WebNavigationResult.Success)
        {
            // TODO: handle failed navigation in an appropriate way
            await Shell.Current.DisplayAlert("Navigation failed", e.Result.ToString(), "OK");
        }
    }
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var search = query["source"].ToString();
        if (string.IsNullOrEmpty(search))
            await Shell.Current.DisplayAlert("Error!", "Code Detection Result Equals Null!", "Cancle");
        var result = await putDatain_webView(search);
        if (string.IsNullOrEmpty(result))
            await Shell.Current.DisplayAlert("Error!", "Search Result Equals Null!", "Cancle");
        Source = HttpUtility.UrlDecode(result);
    }
}