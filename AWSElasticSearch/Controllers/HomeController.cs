using Core.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWSElasticSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private Core.DAL.IAWSCore IAWSCore;
        private IConfiguration config;
        public HomeController(Core.DAL.IAWSCore IAWSCore, IConfiguration Iconfig)
        {
            this.IAWSCore = IAWSCore;
            config = Iconfig;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string value)
        {
            String data = null;
            var domainUrl =config["Logging:AWSDomain:DomainEndPoint"];
            data = await IAWSCore.SearchData(value,domainUrl);
            var SearchResult = JsonConvert.DeserializeObject<Property>(data);
            return Ok(SearchResult);
        }
        
    }
}
