using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheArena.BLL;
using TheArena.Models;
using TheArena.ViewModels;

namespace TheArena.Controllers
{
    public class SearchAPIController : ApiController
    {
        private SearchBLL search = new SearchBLL();

        [HttpGet]
        public IHttpActionResult SimpleSearch(string id)
        {
            return Ok(search.SimpleSearch(id));
        }

        [HttpPost]
        public IHttpActionResult AdvancedSearch(AdvancedSearch advanced)
        {
            return Ok(search.ComplexSearch(advanced));
        }
    }
}

