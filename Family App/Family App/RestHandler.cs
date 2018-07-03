using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;

namespace Family_App
{
    class RestHandler
    {
        // RestHandler with lots of events some are unused but are their for future additions to the app \\
        private string urlF = "https://familyapp1.azurewebsites.net/api/Families";

        private IRestResponse response;
        private RestRequest request;

        public bool ExecutePostRequestF(Family item)
        {
            var client = new RestClient(urlF);

            request = new RestRequest(Method.POST);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if(response != null && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                    return false;
            }
        }

        public bool ExecutePutRequestF(Family item)
        {
            var client = new RestClient(urlF + "/" + item.FamilyID);

            request = new RestRequest(Method.PUT);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }

        public bool ExecuteDeleteRequestF(int id)
        {
            var client = new RestClient(urlF + "/" + id);

            request = new RestRequest(Method.DELETE);

            request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }

        public List<Family> ExecuteGetRequestF()
        {
            var client = new RestClient(urlF);

            request = new RestRequest();

            response = client.Execute(request);

            var objRootF = JsonConvert.DeserializeObject<List<Family>>(response.Content);

            return objRootF;
        }

        private string urlG = "https://familyapp1.azurewebsites.net/api/Groceries";


        public bool ExecutePostRequestG(Groceries item)
        {
            var client = new RestClient(urlG);

            request = new RestRequest(Method.POST);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }

        public bool ExecutePutRequestG(Groceries item)
        {
            var client = new RestClient(urlG + "/" + item.FamilyID);

            request = new RestRequest(Method.PUT);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }

        public bool ExecuteDeleteRequestG(int id)
        {
            var client = new RestClient(urlG + "/" + id);

            request = new RestRequest(Method.DELETE);

            request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }



        public bool ExecuteDeleteRequestAllGrocery(string familyname)
        {
            var client = new RestClient(urlG + "?name=" + familyname);

            request = new RestRequest(Method.DELETE);

            request.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            try
            {
                IRestResponse response = client.Execute(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error;" + error.Message);
                return false;
            }
        }


        public List<Groceries> ExecuteGetRequestG()
        {
            var client = new RestClient(urlG);

            request = new RestRequest();

            response = client.Execute(request);

            //string tempresponse = "[{'Family':{'Groceries':[],'FamilyID':1,'FamilyName':'Smith','UserName':'Todd','UserPassword':'open'},'ListID':1,'FamilyID':1,'Grocery1':'Eggs'}]";

            var objRootG = JsonConvert.DeserializeObject<List<Groceries>>(response.Content);

            //var objRootG = JsonConvert.DeserializeObject<List<Groceries>>(tempresponse);

            return objRootG;
        }
    }
}