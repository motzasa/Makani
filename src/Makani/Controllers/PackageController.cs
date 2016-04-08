using Makani.Models;
using Makani.ViewModels;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Makani.Controllers
{
    [Route("api/packages")]
    public class PackageController : Controller
    {
        MakaniRepository _repo;

        public PackageController(MakaniRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var result = _repo.GetAllPackages();
            return Json(result);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]PackageViewModel package)
        {
            if(ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.Created;
                return Json(true);
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
