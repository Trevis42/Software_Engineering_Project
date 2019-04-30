
using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Content;
using MySql.Data.MySqlClient;
using System.Data;

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
            ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
            ISharedPreferencesEditor editor = pref.Edit();
            DataSet db = new DataSet();

            createAccount.Click += (sender, e) =>
            {
                StartActivity(new Intent(this, typeof(createAccount)));  //go to create account page
            };

            var loginButton = FindViewById<Button>(Resource.Id.loginButton);
            MySqlConnection conn1 = new MySqlConnection("Server=sql9.freesqldatabase.com;Port=3306;database=sql9289950;Uid=sql9289950;Pwd=XpDGLinQFp;CharSet=utf8;default command timeout=30;");
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            loginButton.Click += (sender, e) =>
            {
                db.Clear();
                adapter.SelectCommand = new MySqlCommand("SELECT * FROM Users WHERE Username = '@Username' AND Password = '@Password'");
                adapter.SelectCommand.Connection = conn1;
                adapter.SelectCommand.Parameters.AddWithValue("@Username", userName.Text);
                adapter.SelectCommand.Parameters.AddWithValue("@Password", passWord.Text);
                conn1.Open();
                adapter.Fill(db);
                conn1.Close();

                bool loginSuccess = db.Tables.Count > 0;

                if (loginSuccess == true)
                {
                    loginStatus = true;
                    editor.PutBoolean("key_name1", loginStatus);
                    editor.PutString("key_name2", userName.Text.Trim());
                    editor.Apply();
                    db.Clear();
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
                else
                {
                    db.Clear();
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Account Login");
                    alert.SetMessage("Incorrect Username/Password");
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