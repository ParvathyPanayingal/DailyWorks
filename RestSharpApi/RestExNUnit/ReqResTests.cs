using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using RestExNUnit.Utilities;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestExNUnit
{
    [TestFixture]
    public class ReqResTests : CoreCodes
    {
        [Test]
        [Order(4)]
        public void GetSingleUser()
        {
            test = extent.CreateTest("Get single user");
            Log.Information("Get single user test started");

            var request = new RestRequest("users/2", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
                Log.Information($"API Response:{response.Content}");
                var userData = JsonConvert.DeserializeObject<UserDataResponse>(response.Content);
                UserData? user = userData?.Data;

                Assert.NotNull(user);
                Log.Information("User returned");
                Assert.That(user.Id, Is.EqualTo(2));
                Log.Information("User id matches with fetch");
                Assert.IsNotEmpty(user.Email);
                Log.Information("Email is not empty");
                Log.Information("Get Single User Test Passed all Asserts");
                test.Pass("GetSingleUser test passed");
            }
            catch (AssertionException)
            {
                test.Fail("GetSingleUser test failed");
            }
        }

        [Test]
        [Order(0)]
        public void CreateUser()
        {
            test = extent.CreateTest("Create user");
            Log.Information("Create user test started");

            var request = new RestRequest("users", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "John Doe", job = "Software Developer" });

            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));//created will take both 200 and 201
                Log.Information($"API Response:{response.Content}");
                var user = JsonConvert.DeserializeObject<UserData>(response.Content);

                Assert.NotNull(user);
                Log.Information("User returned");
                Assert.IsNotEmpty(user.Job);
                Log.Information("Job is not empty");
                Log.Information("Create User Test Passed all Asserts");
                test.Pass("CreateUser test passed");
            }
            catch (AssertionException)
            {
                test.Fail("CreateUser test failed");
            }
        }

        [Test]
        [Order(1)]

        public void UpdateUser()
        {
            test = extent.CreateTest("Update user");
            Log.Information("Update user test started");
            var request = new RestRequest("users/2", Method.Put);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new { name = "Updated John Doe", job = "Senior Software Developer" });

            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));//created will take both 200 and 201
                Log.Information($"API Response:{response.Content}");
                var user = JsonConvert.DeserializeObject<UserData>(response.Content);

                Assert.NotNull(user);
                Log.Information("User returned");
                Assert.IsNotEmpty(user.Job);
                Log.Information("Job is not empty");
                Log.Information("Update User Test Passed all Asserts");
                test.Pass("UpdateUser test passed");
            }
            catch (AssertionException)
            {
                test.Fail("UpdateUser test failed");
            }
        }

        [Test]
        [Order(2)]

        public void DeleteUser()
        {
            test = extent.CreateTest("Delete user");
            Log.Information("Delete user test started");
            var request = new RestRequest("users/2", Method.Delete);

            var response = client.Execute(request);
            try
            {


                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NoContent));//created will take both 200 and 201
                Log.Information($"API Response:{response.Content}");
                Log.Information("Delete User Test Passed all Asserts");
                test.Pass("DeleteUser test passed");

            }
            catch (AssertionException)
            {
                test.Fail("DeleteUser test failed");
            }

        }

        [Test]
        [Order(3)]
        public void GetNonExistingUser()
        {
            test = extent.CreateTest("Get non existing user");
            Log.Information("Get non existing user test started");
            var request = new RestRequest("users/999", Method.Get);
            var response = client.Execute(request);
            try
            {
                Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
                Log.Information($"API Response:{response.Content}");
                Log.Information("Get non existing User Test Passed all Asserts");
                test.Pass("Get non existing User test passed");

            }
            catch (AssertionException)
            {
                test.Fail("GetNonExistingUser test failed");
            }



        }
    }
}
