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
    [Activity(Label = "DisplayProfle")]
    public class DisplayProfle : Activity
    {
        private Button enter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.DisplayProfile);
            enter = FindViewById<Button>(Resource.Id.button3);
            enter.Click += (sender, e) =>
            {
                StartActivity(typeof(GetProfile));
            };


            // Create your application here
        }
    }
}