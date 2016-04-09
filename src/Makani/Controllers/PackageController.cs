using AutoMapper;
using Makani.Models;
using Makani.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
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
        ILogger _logger;

        public PackageController(MakaniRepository repo, ILogger<PackageController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var result = Mapper.Map<IEnumerable<PackageViewModel>>(_repo.GetAllPackages());
            return Json(result);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]PackageViewModel packageVm)
        {
            if(ModelState.IsValid)
            {
                var newPackage = Mapper.Map<Package>(packageVm);

                //Save to database
                _logger.LogInformation("Adding new package");
                _repo.AddPackage(newPackage);

                if (_repo.SaveAll())
                {
                    Response.StatusCode = (int)HttpStatusCode.Created;
                    return Json(Mapper.Map<PackageViewModel>(newPackage));
                }
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            _logger.LogError("Failed to add new package");
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
