using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task25.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        // GET: Error
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        // GET: Error/
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }


    }
}
