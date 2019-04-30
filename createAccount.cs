/*
        This file connects to the create user account UI. New users will create their account with this class.
*/
using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace LoginPage.Droid
{
    [Activity(Theme = "@style/MainTheme")]
    class createAccount : Activity
    {
        private Button cont;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CreateAccount);

            var label = FindViewById<TextView>(Resource.Id.createAccountLabel);

                 cont = FindViewById<Button>(Resource.Id.button3);

                 cont.Click += (sender, e) =>
                 {
                     EditText pword = (EditText)FindViewById(Resource.Id.password);                          // Password string

                     EditText pwordagain = (EditText)FindViewById(Resource.Id.passwordAgain);                // Retype password string

                     if (pwordagain.Text != pword.Text)                                                     // If password and retype password do not match
                     {
                         AlertDialog.Builder errorBuilder = new AlertDialog.Builder(this);
                         errorBuilder.SetTitle("Error!");
                         errorBuilder.SetMessage("Passwords do not match.");
                         errorBuilder.SetPositiveButton("OK", (c, ev) =>
                         {
                             StartActivity(new Intent(this, typeof(createAccount)));
                         });
                         Dialog dialogError = errorBuilder.Create();
                         dialogError.Show();
                     }

                     EditText username = (EditText)FindViewById(Resource.Id.userName); // Username string

                     EditText firstname = (EditText)FindViewById(Resource.Id.firstName); // First Name string

                     EditText lastname = (EditText)FindViewById(Resource.Id.lastName);  // Last Name string

                     EditText phone = (EditText)FindViewById(Resource.Id.phoneNumber);  // Phone number string

                     EditText emailaccount = (EditText)FindViewById(Resource.Id.email);   // email string

                     MySqlConnection con = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;"); //database connection

                     try
                     { 
                         MySqlCommand cmd = new MySqlCommand("INSERT INTO Users(Username, First_Name, Last_Name, Phone_Number, Email, Password) VALUES(@Username, @First_Name, @Last_Name, @Phone_Number, @Email, @Password)");     //Insert username, first name, last name, phone number, email, and password into database
                         cmd.Connection = con;
                         con.Open();
                         cmd.Parameters.AddWithValue("@Username", username.Text);
                         cmd.Parameters.AddWithValue("@First_Name", firstname.Text);
                         cmd.Parameters.AddWithValue("@Last_Name", lastname.Text);
                         cmd.Parameters.AddWithValue("@Phone_Number", phone.Text);
                         cmd.Parameters.AddWithValue("@Email", emailaccount.Text);
                         cmd.Parameters.AddWithValue("@Password", pwordagain.Text);
                         cmd.ExecuteNonQuery();

                         AlertDialog.Builder alert = new AlertDialog.Builder(this);         //Notify user that account has been created
                         alert.SetTitle("Account Creation");
                         alert.SetMessage("Your account has been created!");
                         alert.SetPositiveButton("OK", (senderAlert, args) =>
                         {
                             con.Close();
                             StartActivity(new Intent(this, typeof(HomePageActivity)));
                         });
                         Dialog dialog = alert.Create();
                         dialog.Show();
                     }
                     catch (MySqlException ex)                  //catch any MySql errors and notify user
                     {
                         AlertDialog.Builder connError = new AlertDialog.Builder(this);
                         connError.SetTitle("Connection Error!");
                         connError.SetMessage(ex.Message);
                         connError.SetPositiveButton("OK", (c, ev) =>
                         {
                             con.Close();
                         });
                         Dialog dialog1 = connError.Create();
                         connError.Show();
                     }

                 };

            }
        }
    }