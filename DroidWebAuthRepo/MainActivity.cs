using Android.Content;
using Microsoft.Maui.ApplicationModel;

namespace DroidWebAuthRepo;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    private Button _navigateToSecondActivityButton;
    
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        Platform.Init(this, savedInstanceState);
        _navigateToSecondActivityButton = FindViewById<Button>(Resource.Id.navigateToSecondActivityButton);
        _navigateToSecondActivityButton.Click += NavigateToSecondActivityButtonOnClick;
    }

    private void NavigateToSecondActivityButtonOnClick(object? sender, EventArgs e)
    {
        StartActivity(new Intent(this, typeof(SecondActivity)));
    }
}