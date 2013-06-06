using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using RestSharp;
using ZTG.Customer.Commons;

namespace ZTG.Customer.Client.WP8.Helper
{
    public class RestHelper
    {
        private RestClient _restClient;

        public RestHelper(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
            _restClient.AddHandler("application/json", new CustomJsonDeserializer());
        }

        public void Get<T>(Action<T> callback) where T : class, new()
        {
            var noCaching = "?rand=" + DateTime.Now.ToString(); // Don't cache
            var request = new RestRequest(Common.CustomerUrl + noCaching, Method.GET);
            request.AddParameter("cache-control", "no-cache", ParameterType.HttpHeader);
            _restClient.ExecuteAsync<T>(request, response =>
                {
                    HandleResponse<T>(response);
                    callback(response.Data);
                });
        }

        public void Put<T>(T obj, Action callback)
        {
            var putRequest = new RestRequest(Common.CustomerUrl, Method.PUT) {RequestFormat = DataFormat.Json};
            putRequest.JsonSerializer = new CustomJsonSerializer();
            putRequest.AddBody(obj);
            _restClient.ExecuteAsync(putRequest, response =>
            {
                HandleResponse<T>(response);
                callback();
            });
        }

        public void Delete<T>(int id, Action callback)
        {
            var putRequest = new RestRequest(Common.CustomerUrl + @"/" + id, Method.DELETE);
            _restClient.ExecuteAsync(putRequest, response =>
            {
                HandleResponse<T>(response);
                callback();
            });
        }

        public void Post<T>(T obj, Action callback)
        {
            var putRequest = new RestRequest(Common.CustomerUrl, Method.POST) { RequestFormat = DataFormat.Json };
            putRequest.JsonSerializer = new CustomJsonSerializer();
            putRequest.AddBody(obj);
            _restClient.ExecuteAsync(putRequest, response =>
            {
                HandleResponse<T>(response);
                callback();
            });
        }

        private void HandleResponse<T>(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                Debug.WriteLine(response.ErrorException);
            }
            if (response.ErrorMessage != null)
            {
                Debug.WriteLine(response.ErrorMessage);
            }
        }
    }
}
