using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExNUnit
{
    public class UserData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("avatar")]
        public string? Avatar { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }
    }

    //we give second class because our response is object inside object
    public class UserDataResponse
    {
        [JsonProperty("data")]
        public UserData? Data { get; set; }
    }
}
