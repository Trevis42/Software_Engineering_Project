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
    [Activity(Label = "confirmPage", Theme = "@style/AppTheme")]
    public class confirm : Activity
    {
        private Button hom;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.confirmPage);
            hom = FindViewById<Button>(Resource.Id.home);
            hom.Click += (sender, e) =>
            {
                StartActivity(typeof(MainActivity));
            };

            // Create your application here
        }
    }
}