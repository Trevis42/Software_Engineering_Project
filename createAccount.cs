using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

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

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=127.0.0.1; port=3306; uid=group; password=PedalBikePedal1; database=billing; default command timeout=30";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                AlertDialog.Builder connError = new AlertDialog.Builder(this);
                connError.SetTitle("Connection Error!");
                connError.SetMessage(ex.Message);
                connError.SetPositiveButton("OK", (c, ev) =>
                {
                    
                });
            }
            

            cont = FindViewById<Button>(Resource.Id.button3);

            cont.Click += (sender, e) =>
            {
                EditText pword = (EditText)FindViewById(Resource.Id.password);
                String pwordString = pword.ToString();                          // Password string

                EditText pwordagain = (EditText)FindViewById(Resource.Id.passwordAgain);
                String pwordagainString = pwordagain.ToString();                // Retype password string

                if (pwordagainString == pwordString)                            // If password and retype password do not match
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

                EditText username = (EditText)FindViewById(Resource.Id.userName);
                String usernameString = username.ToString();                        // Username string

                EditText firstname = (EditText)FindViewById(Resource.Id.firstName);
                String fnameString = firstname.ToString();                          // First Name string

                EditText lastname = (EditText)FindViewById(Resource.Id.lastName);
                String lnameString = lastname.ToString();                           // Last Name string

                EditText phone = (EditText)FindViewById(Resource.Id.phoneNumber);
                String phoneString = username.ToString();
                int.TryParse(phoneString, out int phoneInt);                        // Phone number string

                EditText emailaccount = (EditText)FindViewById(Resource.Id.email);
                String emailString = emailaccount.ToString();                       // email string





                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("Account Creation");
                alert.SetMessage("Your account has been created!");
                alert.SetPositiveButton("OK", (senderAlert, args) =>
                {
                    StartActivity(new Intent(this, typeof(HomePageActivity)));
                });
                Dialog dialog = alert.Create();
                dialog.Show();

            };

        }
    }
}