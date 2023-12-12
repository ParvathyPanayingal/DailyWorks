using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEx
{
    public class APIwithExcp
    {
        string baseUrl = "https://reqres.in/api/";

        //checkng for error message only
        //    public void GetSingleUser()
        //    {
        //        var client = new RestClient(baseUrl);
        //        var req = new RestRequest("use/23", Method.Get);
        //        var response = client.Execute(req);

        //        //with ERR
        //        if (!response.IsSuccessful)
        //        {
        //            try
        //            {
        //                var errorDetails = JsonConvert.DeserializeObject
        //                    <ErrorResponse>(response.Content);
        //                if (errorDetails != null)
        //                {
        //                    Console.WriteLine($"API Error:{errorDetails.Error}");
        //                }
        //            }
        //            catch (JsonException)
        //            {
        //                Console.WriteLine("Failed to deserialize error response.");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Successful Response");
        //            Console.WriteLine(response.Content);
        //        }
        //    }


        //json content check for null data
        public void GetSingleUser()
        {
            var client = new RestClient(baseUrl);
            var req = new RestRequest("users/2", Method.Get);
            var response = client.Execute(req);

            //with ERR
            if (!response.IsSuccessful)
            {
                if (IsJson(response.Content))
                    {
                    try
                    {
                        var errorDetails = JsonConvert.DeserializeObject
                            <ErrorResponse>(response.Content);
                        if (errorDetails != null)
                        {
                            Console.WriteLine($"API Error:{errorDetails.Error}");
                        }
                    }
                    catch (JsonException)
                    {
                        Console.WriteLine("Failed to deserialize error response.");
                    }
                }

                else
                {
                    Console.WriteLine($"Non JSON error response:{response.Content} ");
                    
                }
            }
            else
            {
                Console.WriteLine("Successful");
                Console.WriteLine(response.Content);
            }
            static bool IsJson(string content)
            {
                try
                {
                    JToken.Parse(content); //if able to parse then response is json
                    return true;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
        }
    }
}
