using Service.Core.Domain.Entity;
using Service.Core.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Service.Core;
using Service.Core.Services;

namespace Service.Core.Service
{
    public class DataProviderService<T> : Service<T> where T : class
    {
        public DataProviderService()
        {

        }

        public DataProvider GetData(string url)
        {
            var result = GetAsync(url).Result as DataProvider;
            return result;
        }
    }
}
