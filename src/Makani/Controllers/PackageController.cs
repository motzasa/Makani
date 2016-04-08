using Makani.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public JsonResult Post([FromBody]Package package)
        {
            return Json(true);
        }
    }
}
