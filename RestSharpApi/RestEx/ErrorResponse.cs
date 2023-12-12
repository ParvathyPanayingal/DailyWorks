using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEx
{
    public class ErrorResponse
    {//mapping the deserialization of the element
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
