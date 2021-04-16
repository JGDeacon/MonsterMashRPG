using CharacterCreatorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharacterCreatorAPI.Controllers
{
    public class SeedController : ApiController
    {
        public IHttpActionResult Post()
        {
            SeedService seedService = new SeedService();
            seedService.SeedAdjustmentTable();
            seedService.SeedLevelTable();
            return Ok();
            
        }
    }
}
