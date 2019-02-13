using Newtonsoft.Json;
using Service.Core.Domain.Entity;
using Service.Core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Service
{
    public class Service<TRequest> : IService<TRequest> where TRequest : class
    {
        public async Task<TRequest> GetAsync(string endpoint)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:55587/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage response = await client.GetAsync("api/Department/1");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TRequest>(jsonString);
                    }
                    else
                    {
                        throw new Exception($"{response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Post(TRequest entity, string endpoint)
        {
            throw new NotImplementedException();
        }
        private void GetPOSTResponse(Uri uri, string data, Action<Response> callback)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType = "text/plain;charset=utf-8";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] bytes = encoding.GetBytes(data);

            request.ContentLength = bytes.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                // Send the data.
                requestStream.Write(bytes, 0, bytes.Length);
            }

            request.BeginGetResponse((x) =>
            {
                using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                {
                    if (callback != null)
                    {
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
                        callback(ser.ReadObject(response.GetResponseStream()) as Response);
                    }
                }
            }, null);
        }
    }
}
