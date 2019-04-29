using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;

namespace LoginPage.Models
{

    public class User
    {

        [JsonProperty(PropertyName ="Username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName ="Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName ="Phone_Number")]
        public int Phone_Number { get; set; }

        [JsonProperty(PropertyName ="Billing_Rate")]
        public double Billing_Rate { get; set; }

        [JsonProperty(PropertyName ="User_ID")]
        public int User_ID { get; set; }

        [JsonProperty(PropertyName ="First_Name")]
        public string First_Name { get; set; }

        [JsonProperty(PropertyName ="Last_Name")]
        public string Last_Name { get; set; }

        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckLogin()
        {
            if (this.Username == null || this.Password == null)
                return false;
            else
                return true;
        }

    }
}
