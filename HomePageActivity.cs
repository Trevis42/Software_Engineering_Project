/*
       This file works with the home page UI and is where the User can add a client to the client list, view the client list or log out.
*/
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;

namespace LoginPage.Droid
{
    [Activity(Theme = "@style/MainTheme")]
    public class HomePageActivity : AppCompatActivity
    {
        private List<Client> clients;
        private ListView myListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);

            var clientListButton = FindViewById<Button>(Resource.Id.clientList);        //button for the client list
            var addClientButton = FindViewById<Button>(Resource.Id.addClient);          //button for adding client
            var logOutButton = FindViewById<Button>(Resource.Id.logOut);                //button for logging out
            myListView = FindViewById<ListView>(Resource.Id.listSearchView);


            clientListButton.Click += (c, ev) =>
            {
                StartActivity(new Android.Content.Intent(this, typeof(ClientListViewer)));              //list of clients

            };

            addClientButton.Click += (sender, e) =>
            {
                StartActivity(new Android.Content.Intent(this, typeof(CreateClientAccount)));           //add client page
            };

            logOutButton.Click += (sender, e) =>
            {
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetTitle("Logged out");
                builder.SetMessage("Returning to login screen.");
                builder.SetPositiveButton("OK", (c, ev) =>
                {
                    StartActivity(new Android.Content.Intent(this, typeof(MainActivity)));              //back to login screen
                });
                Dialog dialog = builder.Create();
                builder.Show();
            };

        }
    }
}