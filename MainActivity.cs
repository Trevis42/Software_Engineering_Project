
using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;

namespace LoginPage.Droid
{
    [Activity(Label = "BAFD", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //var forgpswrt = FindViewById<Button>(Resource.Id.button1);
            var createAccount = FindViewById<Button>(Resource.Id.button2);
            //forgpswrt.Click += (sender, e) =>
            //{
            //    StartActivity(typeof(forgetPassword));
            //};
            createAccount.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(createAccount)));  //go to create account page
            };

            var loginButton = FindViewById<Button>(Resource.Id.button3);

            loginButton.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(HomePageActivity))); //go to home page when logged in
            };
        }
    }
}