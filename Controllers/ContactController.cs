using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        [Route("Main")]
        public IActionResult Index()
        {
            return Ok("Action main is called");
        }

        [Route("Details/{id?}")]
        public IActionResult SomeActionName()
        {
            return Ok("Action main is called");
        }
    }
}
