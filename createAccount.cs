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
    [Activity(Label = "createAccount", Theme = "@style/AppTheme")]
    class createAccount:Activity
    {
        private Button cont;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.createAccount);
            cont = FindViewById<Button>(Resource.Id.button3);
            cont.Click += (sender, e) =>
            {
                StartActivity(typeof(VerifyEmail));
            };

            // Create your application here
        }
    }
}