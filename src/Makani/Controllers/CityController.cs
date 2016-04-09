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
    [Route("api/packages/{packageName}/cities")]
    public class CityController : Controller
    {
        private ILogger<CityController> _logger;
        private MakaniRepository _repo;

        public CityController(MakaniRepository repo, ILogger<CityController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get(string packageName)
        {
            try
            {
                var package = _repo.GetPackageByName(packageName);

                if (package == null)
                {
                    return Json(null);
                }

                return Json(Mapper.Map<IEnumerable<CityViewModel>>(package.Cities));
            }
            catch
            {
                _logger.LogError($"Failed to get cities for package {packageName}");
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Error occured finding package name");
            }
        }

        [HttpPost("")]
        public JsonResult Post(string packageName, [FromBody]CityViewModel cityVm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newCity = Mapper.Map<City>(cityVm);

                    _repo.AddCity(newCity);

                    if(_repo.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<CityViewModel>(newCity));
                    }
                }
            }
            catch
            {
                _logger.LogError("Failed to save new city");
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Failed to save new stop");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed for new city");
        }
    }
}
