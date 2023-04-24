using Android.App;
using Android.OS;
using Net7XamFormsCore;
using System.Runtime.Versioning;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Net7AndroidTestApp
{
    [Activity(Label = "@string/app_name",
        Theme = "@style/MainTheme",
        MainLauncher = true
)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            Forms.Init(this, savedInstanceState);

            this.LoadApplication(new App());
        }

        [SupportedOSPlatform("android23.0")]
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
