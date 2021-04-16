using CharacterCreatorModels;
using CharacterCreatorServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CharacterCreatorAPI.Controllers
{
    public class XPController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            return characterService;
        }
        public IHttpActionResult Put(AddXP model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCharacterService();
            if (!service.AddXP(model))
            {
                return InternalServerError();
            }
            return Ok("Character XP Adjusted");

        }
    }
}
