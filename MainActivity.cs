/*
    This file works with the login UI and gets the login credentials of the user from the database. User can create account from here or login normally.
    If user inputs incorrect credentials they will be notified.
*/
using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Content;
using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace LoginPage.Droid
{
    [Activity(Label = "BAFD", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            var createAccount = FindViewById<Button>(Resource.Id.createAccountButton);
            var userName = FindViewById<EditText>(Resource.Id.userNameInput);
            var passWord = FindViewById<EditText>(Resource.Id.passInput);
            bool loginStatus = false;
            DataSet db = new DataSet();

            createAccount.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(createAccount)));  //go to create account page
            };

            var loginButton = FindViewById<Button>(Resource.Id.loginButton);
            MySqlConnection conn1 = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;");        //database connection string

            loginButton.Click += (sender, e) =>
            {
                db.Clear();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password = @Password", conn1);      //get username and password
                cmd.Parameters.AddWithValue("@Username", userName.Text);
                cmd.Parameters.AddWithValue("@Password", passWord.Text);
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(db);

                if (db.Tables[0].Rows.Count != 0)                                               //if combination of username and password is found, then login is successful
                {
                    loginStatus = true;
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Account Login");
                    alert.SetMessage("Successfully logged in.");
                    alert.SetPositiveButton("OK", (c, ev) =>
                    {
                        StartActivity(new Intent(this, typeof(HomePageActivity)));
                    });
                    Dialog dialog = alert.Create();
                    alert.Show();
                }
                else                                                                              //otherwise, user needs to retry
                {
                    db.Clear();                                                                                                 
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Account Login");
                    alert.SetMessage("Invalid Username/Password");
                    alert.SetPositiveButton("OK", (c, ev) =>
                    {

                    });
                    Dialog dialog = alert.Create();
                    alert.Show();
                }

            };


        }
    }
}