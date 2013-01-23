using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class SpecApiController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var item = new RescuerSpec();
            item.Alpinist = new Spec() {Id = 4, Name = "Test"};
            item.AlpinistToken = true;
            item.Tehnogenschik = new Spec[] { new Spec() { Id = 4, Name = "Test" } };
            if (item == null)
            {
                var notFoundResponse = new HttpResponseMessage();
                notFoundResponse.StatusCode = HttpStatusCode.NotFound;
                notFoundResponse.Content = new StringContent("Item not found");
                throw new HttpResponseException(notFoundResponse);
            }
            var response = Request.CreateResponse<RescuerSpec>(HttpStatusCode.OK, item);

            // set it to expire in 5 minutes
            response.Content.Headers.Expires = new DateTimeOffset(DateTime.Now.AddSeconds(30));
            return response;
        }
    }
}
