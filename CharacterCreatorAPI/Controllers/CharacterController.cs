using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharacterCreatorAPI.Controllers
{
    public class CharacterController
    {
        private ChracterService CreateCharacterService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var characterService = new CharacterService(userID);
            return characterService;

        }
    }
}