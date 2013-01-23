using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class DictApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage All()
        {
            var result = new Dictionary<string, List<DictItem>>();

            var specs = new List<string> {"alpinist", "tehnogenschik"};

            foreach (var spec in specs)
            {
                var dict = (new Dict()).Get(spec);
                dict.Insert(0, new DictItem {Id = 0, Name = " "});
                result.Add(spec, dict);
            }
            var response = Request.CreateResponse<Dictionary<string, List<DictItem>>>(HttpStatusCode.OK, result);

            // set it to expire in 5 minutes
            response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(30));
            return response;
        }
        
        [HttpGet]
        public HttpResponseMessage Get(string name, bool required = false)
        {
            var dict = (new Dict()).Get(name);
            if (!required)
                dict.Insert(0, new DictItem{Id = 0, Name = " "});

            var response = Request.CreateResponse<List<DictItem>>(HttpStatusCode.OK, dict);

            // set it to expire in 5 minutes
            response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(30));
            return response;
        }
    }
}
