using System.Diagnostics;
using Microsoft.Maui.Authentication;
using Activity = Android.App.Activity;

namespace DroidWebAuthRepo;

[Activity(Label = "@string/app_name")]
public class SecondActivity : Activity
{
    private Button _goBackButton;
    private Button _openWebAuthenticatorButton;
    
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        
        SetContentView(Resource.Layout.activity_second);
        _goBackButton = FindViewById<Button>(Resource.Id.goBackButton);
        _openWebAuthenticatorButton = FindViewById<Button>(Resource.Id.openWebAuthButton);
        
        _goBackButton.Click += GoBackButtonOnClick;
        _openWebAuthenticatorButton.Click += OpenWebAuthenticatorButtonOnClick;
    }

    private async void OpenWebAuthenticatorButtonOnClick(object? sender, EventArgs e)
    {
        try
        {
            await WebAuthenticator.Default.AuthenticateAsync(
                new WebAuthenticatorOptions
                {
                    Url = new Uri("https://google.com"),
                    CallbackUrl = new Uri("callback://"),
                    PrefersEphemeralWebBrowserSession = true,
                });

            Debug.WriteLine("All good");
        }
        catch (TaskCanceledException)
        {
            Debug.WriteLine("Task was canceled");
        }
    }

    private void GoBackButtonOnClick(object? sender, EventArgs e)
    {
        Finish();
    }
}