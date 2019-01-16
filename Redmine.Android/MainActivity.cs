
using Android.App;
using Android.Content.PM;
using Android.OS;
using DryIoc;
using Redmine.Services.Interfaces;

namespace Redmine.Droid
{
    [Activity(Label = "Redmine", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            var resolver = new AndroidResolver();
            resolver.PlatformContainerInit();
            var app = ViewModelResolver.Container.Resolve<IMainView>() as App;
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(app);
        }
    }
}