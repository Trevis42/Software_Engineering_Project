using System;
using System.Collections.Generic;
using System.Text;

namespace LoginPage.Models
{
    public class Token
    {
        public int ID { get; set; }
        public string access_token { get; set; }
        public string error_description { get; set; }
        public DateTime date_expire { get; set; }

        public Token() { }
    }
}
