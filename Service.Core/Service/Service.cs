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

namespace Service.Core.Services
{
    public class Service<TRequest> : IService<TRequest> where TRequest : class
    {
        public async Task<TRequest> GetAsync(string endpoint)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //GET Method  
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var result =  JsonConvert.DeserializeObject<TRequest>(jsonString);
                        return result;

                        //using (StreamReader r = new StreamReader("getDataResponseStatic.json"))
                        //{
                        //    string json = r.ReadToEnd();
                        //    var item = JsonConvert.DeserializeObject<TRequest>(json);
                        //    return item;
                        //}
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
            using (var client = new HttpClient())
            {
                try
                {
                    string postJson = JsonConvert.SerializeObject(entity);
                    var content = new StringContent(postJson.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage result = client.PostAsync(new Uri(endpoint), content).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
