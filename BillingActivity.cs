using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LoginPage.Droid
{ 
    [Activity(Theme = "@style/MainTheme")]
    public class BillingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BillingPage);

            var homeButtonBilling = FindViewById<Button>(Resource.Id.homeButtonBilling);

            homeButtonBilling.Click += (sender, e) =>
            {
                Finish();
            };
        }
    }
}