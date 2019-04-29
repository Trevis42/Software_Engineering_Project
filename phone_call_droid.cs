using System;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;

using Xamarin.Forms;
using MakeCall.Droid;

[assembly: Dependency(typeof(phone_call_droid))]

namespace MakeCall.Droid
{
    public class phone_call_droid : phone_call_interface
    {
        public void MakeQuickCall(string PhoneNumber)
        {
            try
            {
                var uri = Android.Net.Uri.Parse(string.Format("tel:[0]", PhoneNumber));
                var intent = new Intent(intent.ActionCall, uri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
            }
            catch (Exception ex)
            {
                new AlertDialog.Builder(Android.App.Application.Context).SetPositiveButton("OK", (sender, args) =>
                {
                    //call error message
                })
                .SetMessage(ex.ToSting())
                .SetTitle("Android Exception")
                .Show();
            }

            call_btn.Clicked += (sender, args) =>
            {
                try
                {
                    if (numEntry.Text == "")
                    {
                        DisplayAlert("Alert", "Specify the number to start the call.", "OK");
                    }
                    else
                    {
                        DependencyService.Get<phone_call_interface>().MakeQuickCall(numEntry.Text.ToString())
                    }
                }
                catch (Excpetion ex)
                {
                    throw ex;
                }
            }
        }
    }
}
