using Newtonsoft.Json;

namespace LoginPage.Droid.Models
{
    class Contact
    {

        [JsonProperty(PropertyName = "Contact_ID")]
        public string Contact_ID { get; set; }

        [JsonProperty(PropertyName = "First_Name")]
        public string First_Name { get; set; }

        [JsonProperty(PropertyName = "Last_Name")]
        public string Last_Name { get; set; }

        [JsonProperty(PropertyName = "Company_Name")]
        public string Company_Name { get; set; }

        [JsonProperty(PropertyName = "Primary_Phone")]
        public int Primary_Phone { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
    }
}