using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;

namespace LoginPage.Droid
{
    [Activity(Theme = "@style/MainTheme")]
    public class HomePageActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);

            var clientListButton = FindViewById<Button>(Resource.Id.clientList);
            var addClientButton = FindViewById<Button>(Resource.Id.addClient);

            clientListButton.Click += (sender, e) =>
            {
                StartActivity(typeof(BillingActivity));
            };

            addClientButton.Click += (sender, e) =>
            {
                StartActivity(new Android.Content.Intent(this, typeof(CreateClientAccount)));
            };


        }
    }
}