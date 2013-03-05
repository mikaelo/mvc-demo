using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class DemoController : Controller
    {
        //
        // GET: /Demo/

        public ActionResult MakeRequest()
        {
            return View();
        }

        [HttpPost]
        [ActionName("MakeRequest")]
        public ActionResult MakeRequest_Post(string request)
        {
            return Content("Post request " + request);
        }

        [HttpPut]
        [ActionName("MakeRequest")]

        public ActionResult MakeRequest_Put(string request)
        {
            return Content("Put request " + request);
        }


    }
}
