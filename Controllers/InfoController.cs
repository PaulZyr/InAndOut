using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class InfoController : Controller
    {
        [Route("{id}")]
        [HttpGet]
        public IActionResult GetInfo(int id)
        {
            return Ok($"You have entered: {id}");
        }

        // same result
        //[HttpGet]
        //public IActionResult GetInfo([FromRoute] int id)
        //{
        //    return Ok($"You have entered: {id}");
        //}

        // local/Info/GetSomeData?values=mvccore
        public IActionResult GetSomeData([FromQuery] string values)
        {
            return Ok($"The value <{values}> is from query string");
        }

        [HttpPost]
        public IActionResult PostInfo([FromHeader] string parentRequestId)
        {
            return Ok($"Got a header with parentRequestId <{parentRequestId}>");
        }

        [HttpPost]
        public IActionResult SaveFile([FromForm] string filename, [FromForm] IFormFile file)
        {
            return Ok("Success");
        }
    }
}
