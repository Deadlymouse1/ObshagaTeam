using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace HelloMvx4.Droid
{
    [Activity(
        Label = "HelloMvx4.Droid"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
