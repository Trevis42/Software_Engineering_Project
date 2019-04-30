/*
    This file is a StateListener file that checks if phone calls are idle, ringing or in progress.
*/
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
using Android.Telephony;

namespace LoginPage.Droid
{
    class StateListener : PhoneStateListener
    {
        private readonly ClientListViewer clientListViewer;     //this is needed to be used in the ClientListViewer activity

        public StateListener(ClientListViewer listViewer)       //this is needed to be used in the ClientListViewer activity
        {
            clientListViewer = listViewer;
        }

        public override void OnCallStateChanged(CallState state, string phoneNumber)        //state can have three cases: idle, offhook(call-in-progress), or ringing
        {
            base.OnCallStateChanged(state, phoneNumber);
            clientListViewer.UpdateCallState(state, phoneNumber);
        }
    }
}