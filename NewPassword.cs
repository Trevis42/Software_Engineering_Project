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
    [Activity(Label = "newPassword", Theme = "@style/AppTheme")]
    public class NewPassword : Activity
    {
        private Button home;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.newPassword);
            home = FindViewById<Button>(Resource.Id.button3);
            home.Click += (sender, e) =>
            {
                StartActivity(typeof(MainActivity));
            };


            // Create your application here
        }
    }
}