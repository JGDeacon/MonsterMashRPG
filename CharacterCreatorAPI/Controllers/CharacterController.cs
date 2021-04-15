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
    public class CharacterController : ApiController
    {
        private CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userId);
            return characterService;
        }

        public IHttpActionResult Get()
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacters();
            return Ok(characters);
        }

        public IHttpActionResult Post(CharacterCreate character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCharacterService();

            if (!service.CreateCharacter(character))
                return InternalServerError();

            return Ok("Your character has been created!");
        }

        public IHttpActionResult Get(int id)
        {
            CharacterService characterService = CreateCharacterService();
            var characters = characterService.GetCharacterById(id);
            return Ok(characters);

        }
    }
}
