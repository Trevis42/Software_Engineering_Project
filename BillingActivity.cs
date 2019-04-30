/*
    This file connects to the billing page UI. It will retrieve the client's first name, last name, phone number, total calls made with the client and calls that count as billable.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;

namespace LoginPage.Droid
{ 
    [Activity(Theme = "@style/MainTheme")]
    public class BillingActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            string phone = Intent.GetStringExtra("file");       //this was sent from client list page and is used to link the billing page to its respective client

            SetContentView(Resource.Layout.BillingPage);

            
            //various buttons and text fields
            var homeButtonBilling = FindViewById<Button>(Resource.Id.homeButtonBilling);    
            var calculateButton = FindViewById<Button>(Resource.Id.calculateAmount);
            var clientNameLabel = FindViewById<TextView>(Resource.Id.customerName);
            var totalCallsText = FindViewById<TextView>(Resource.Id.totalCalls);
            var billedCallsText = FindViewById<TextView>(Resource.Id.billedCalls);
            var billedAmount = FindViewById<TextView>(Resource.Id.amountToBill);

            DataTable db = new DataTable(); //table to hold information

            MySqlConnection conn = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;"); //database connection
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand("SELECT First_Name, Last_Name, Billing_Rate, Calls, Billed_Calls FROM Contacts WHERE Phone_Number = @Phone_Number", conn); //get the first name, last name, billing rate, total calls and billable calls from contacts table in database
            adapter.SelectCommand.Parameters.AddWithValue("@Phone_Number", phone);      //this phone number is used to link the client and all the calls they made.
            adapter.Fill(db);

            string clientName;          //first + last name
            string calls;               
            string billedCalls;
            string billingRateString;   //this will be converted to a double
            double billingRate;         
            double callsToBill;
            double totalAmount;
            string totalAmountString;

            foreach (DataRow row in db.Rows)        //fill out the UI with the client details
            {
                clientName = row[0].ToString() + " " + row[1].ToString();
                clientNameLabel.Text = clientName;
                calls = row[3].ToString();
                totalCallsText.Text = calls;
                billedCalls = row[4].ToString();
                billedCallsText.Text = billedCalls;
            }


            calculateButton.Click += (c, ev) =>     //on button click, calculate the total amount
            {
                foreach (DataRow row in db.Rows)
                {
                    billingRateString = row[2].ToString();
                    billingRate = Convert.ToDouble(billingRateString);
                    billedCalls = row[4].ToString();
                    callsToBill = Convert.ToDouble(billedCalls);
                    totalAmount = billingRate * callsToBill;                //billing rate * billable calls
                    totalAmountString = Convert.ToString(totalAmount);
                    billedAmount.Text = totalAmountString;
                }
            };


            homeButtonBilling.Click += (sender, e) =>           //go home button
            {
                StartActivity(typeof(HomePageActivity));
            };
        }
    }
}