using System;
using System.Collections.Generic;
using System.Linq;
using Service.Core;
using Microsoft.AspNetCore.Mvc;
using Service.Core.Service;
using Service.Core.Domain.Entity;

namespace Service.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataProviderController : ControllerBase
    {
        private DataProviderService<DataProvider> _dataProviderService;
        string url = string.Empty;
        public DataProviderController()
        {
            _dataProviderService = new DataProviderService<DataProvider>();
            url = "http://localhost:5028/PN/GetData";
        }

        [HttpGet("GetData")]
        public object GetData()
        {
            var result = _dataProviderService.GetData(url);
            return result;
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
