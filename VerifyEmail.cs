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

namespace work
{
    [Activity(Label = "VerifyEmail", Theme = "@style/AppTheme")]
    public class VerifyEmail : Activity
    {
        private Button entr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.verifyEmail);
            entr = FindViewById<Button>(Resource.Id.button3);
            entr.Click += (sender, e) =>
            {
                StartActivity(typeof(confirm));
            };



            // Create your application here
        }
    }
}