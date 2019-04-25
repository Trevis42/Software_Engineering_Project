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
    [Activity(Label = "forgetPassword", Theme = "@style/AppTheme")]
    public class forgetPassword : Activity
    {
        private Button enter;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.forgetPassword);

            enter = FindViewById<Button>(Resource.Id.button3);
            enter.Click += (sender, e) =>
            {
                StartActivity(typeof(NewPassword));
            };

            // Create your application here
        }
    }
}