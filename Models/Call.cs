using Newtonsoft.Json;
using System;

namespace LoginPage.Models
{

    public class Call
    {

        [JsonProperty(PropertyName = "User_ID")]
        public string User_ID { get; set; }

        [JsonProperty(PropertyName = "Contact_ID")]
        public string Contact_ID { get; set; }

        [JsonProperty(PropertyName = "Start_Time")]
        public byte[] Start_Time { get; set; }

        [JsonProperty(PropertyName = "Amt_Billed")]
        public decimal Amt_Billed { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "Duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "Note")]
        public string Note { get; set; }
    }
}
