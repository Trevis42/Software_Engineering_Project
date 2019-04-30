﻿using System;
using System.Collections.Generic;
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
    public class CreateClientAccount : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateClientAccount);

            var sendInfo = FindViewById<Button>(Resource.Id.addClientButton);

            sendInfo.Click += (sender, e) =>
            {
                EditText clientFirst = FindViewById<EditText>(Resource.Id.firstNameClient);
                EditText clientLast = FindViewById<EditText>(Resource.Id.lastNameClient);
                EditText clientPhone = FindViewById<EditText>(Resource.Id.phoneNumberClient);
                EditText clientEmail = FindViewById<EditText>(Resource.Id.emailClient);
                EditText clientBillingRate = FindViewById<EditText>(Resource.Id.clientBilling);
                double billing_rate = double.Parse(clientBillingRate.Text);

                MySqlConnection conn = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;");

                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO Contacts(First_Name, Last_Name, Phone_Number, Email, Billing_Rate) VALUES(@First_Name, @Last_Name, @Phone_Number, @Email, @Billing_Rate)");
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.Parameters.AddWithValue("@First_Name", clientFirst.Text);
                    cmd.Parameters.AddWithValue("@Last_Name", clientLast.Text);
                    cmd.Parameters.AddWithValue("@Phone_Number", clientPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", clientEmail.Text);
                    cmd.Parameters.AddWithValue("@Billing_Rate", billing_rate);
                    cmd.ExecuteNonQuery();

                }
                catch (MySqlException ex)
                {
                    AlertDialog.Builder connError = new AlertDialog.Builder(this);
                    connError.SetTitle("Connection Error!");
                    connError.SetMessage(ex.Message);
                    connError.SetPositiveButton("OK", (c, ev) =>
                    {
                        conn.Close();
                    });
                    Dialog dialog1 = connError.Create();
                    connError.Show();
                }

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Client Creation");
                alert.SetMessage("Your client's account has been created!");
                alert.SetPositiveButton("OK", (senderAlert, args) =>
                {
                    conn.Close();
                    StartActivity(new Intent(this, typeof(HomePageActivity)));
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            };
        }
    }
}