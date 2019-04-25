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
    [Activity(Label = "GetProfile", Theme = "@style/AppTheme")]
    public class GetProfile : Activity
    {
        private Button enter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GetProfile);

            enter = FindViewById<Button>(Resource.Id.button3);
            enter.Click += (sender, e) =>
            {
                StartActivity(typeof(DisplayProfle));
            };



            // Create your application here
        }

    }
}