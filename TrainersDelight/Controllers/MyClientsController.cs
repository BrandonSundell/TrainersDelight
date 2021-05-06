using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainersDelight.Controllers
{
    public class MyClientsController : Controller
    {
        // GET: MyClientsController
        public ActionResult Index()
        {
            return View();
        }
    }
}
