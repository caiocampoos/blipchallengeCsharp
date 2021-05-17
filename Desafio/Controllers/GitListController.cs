using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;
using Desafio.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Desafio.Controllers
{
   public class GitListController : ApiController
    {   
        [HttpGet]
        public async Task<dynamic> GetDynamics()
        {
            var responseString = await ApiGitCall.makeRequest("https://api.github.com/orgs/takenet/repos");
           
            return responseString;

            
        }
         

    }
}
