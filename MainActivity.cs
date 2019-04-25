using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace work
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button forgpswrt,createAccount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            StartActivity(typeof(GetProfile));

            
            forgpswrt = FindViewById<Button>(Resource.Id.button1);
            createAccount = FindViewById<Button>(Resource.Id.button2);
            forgpswrt.Click += (sender, e) =>
            {
                StartActivity(typeof(forgetPassword));
            };
            createAccount.Click += (sender, e) =>
            {
                StartActivity(typeof(createAccount));
            };
            
            //            login = FindViewById<Button>(Resource.Id.button1);


        }
    }
}