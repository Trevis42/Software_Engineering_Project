/*
    This file is linked to the client list UI. This is where the list of clients is shown, calls to the clients are made, and how they are updated to the database.
*/
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Telephony;
using MySql.Data.MySqlClient;
using Android;
using System;

namespace LoginPage.Droid
{
    [Activity(Label = "Client List")]
    public class ClientListViewer : Activity
    {
        private List<Client> clients;
        private Android.Widget.ListView myListView;
        public static Stopwatch stopwatch = new Stopwatch();                                    //stopwatch to time calls
        public long time;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ClientListView);

            StateListener phoneStateListener = new StateListener(this);                                          //will be used to check if phone is making a call
            TelephonyManager telephonyManager = (TelephonyManager)GetSystemService(Context.TelephonyService);
            telephonyManager.Listen(phoneStateListener, PhoneStateListenerFlags.CallState);

            myListView = FindViewById<Android.Widget.ListView>(Resource.Id.listSearchView);

            MySqlConnection conn1 = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;"); //connection to database
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            clients = new List<Client>();   //list of clients with name and phone number
            DataTable db = new DataTable();

            db.Clear();
            clients.Clear();
            adapter.SelectCommand = new MySqlCommand("SELECT First_Name, Last_Name, Phone_Number FROM Contacts");  //will populate listview with first and last name of client and their phone number
            adapter.SelectCommand.Connection = conn1;
            adapter.Fill(db);


            foreach (DataRow row in db.Rows)
            {
                clients.Add(new Client() { First_Name = row[0].ToString(), Last_Name = row[1].ToString(), Phone_Number = row[2].ToString() });  //add clients to list
            }

            ClientListAdapter listAdapter = new ClientListAdapter(this, clients);       //handles the formatting of client items into the listview
            myListView.Adapter = listAdapter;

            myListView.ItemClick += MyListView_ItemClick;
        }


        public void UpdateCallState(CallState state, string phoneNumber)    //checks for call in progress and times it.
        {
            string cpn = phoneNumber;                                       //client phone number
            MySqlConnection conn2 = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;");

            while (state == CallState.Offhook)                                 //call is in progress and being timed
            {
                stopwatch.Start();
                time = stopwatch.ElapsedTicks;
            }
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                if(time > 360)
                {
                    
                    MySqlCommand cmd = new MySqlCommand("UPDATE Contacts SET Billed_Calls = Billed_Calls + 1, Calls = Calls + 1 WHERE Phone_Number = @Phone_Number", conn2);           //update calls in database
                    cmd.Parameters.AddWithValue("@Phone_Number", cpn);
                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE Contacts SET Calls = Calls + 1 WHERE Phone_Number = @Phone_Number", conn2); //update total calls in database
                    cmd.Parameters.AddWithValue("@Phone_Number", cpn);
                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();
                }
            }
        }


        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)         //this method waits for user to tap a client on the list and gives options to call or bill the client
        {
            string phone = clients[e.Position].Phone_Number;
            Intent intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse(("tel: +1" + phone)));
            AlertDialog.Builder callAlert = new AlertDialog.Builder(this);
            callAlert.SetTitle(clients[e.Position].First_Name + " " + clients[e.Position].Last_Name);
            callAlert.SetMessage("Call or Bill?");
            callAlert.SetPositiveButton("Call", (c, ev) =>                                           //call client
            {
                string[] PermissionLocation =
                {
                    Manifest.Permission.CallPhone
                };
                RequestPermissions(PermissionLocation, 0);                                           //call permissions
                StartActivity(intent);
                UpdateCallState(CallState.Offhook, clients[e.Position].Phone_Number);               //call state
            });
            callAlert.SetNeutralButton("Cancel", (c, ev) =>
            {
                
            });
            callAlert.SetNegativeButton("Bill", (c, ev) =>                                          //go to bill client
            {
                Intent billingIntent = new Intent(this, typeof(BillingActivity));
                billingIntent.PutExtra("file", phone);                                     //sends the phone number to the billing activity so it knows what client to look at
                StartActivity(billingIntent);
            });
            Dialog dialog = callAlert.Create();
            callAlert.Show();
        }
    }
}