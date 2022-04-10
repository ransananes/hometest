using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using tester.Models;
using tester.Enum;
using tester.Models.Operations;
namespace tester.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class OperationsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return defaultOperations.availableOperations;
        }
        // POST api/<controller>
        public string Post([FromBody] object data)
        {
            var object_data = JsonConvert.SerializeObject(data);
            DataHandler data_handler = JsonConvert.DeserializeObject<DataHandler>(object_data);
            return data_handler.createFunction();
        }
    }
}