using CharacterCreatorData;
using CharacterCreatorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorServices
{
    public class CharacterService
    {
        private readonly Guid _userId;

        public CharacterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCharacter(CharacterCreate model)
        {
            var entity =
                new Character()
                {
                    User = _userId,
                    Name = model.Name,
                    BaseHP = model.HP,
                    BaseSpd = model.SPD,
                    BaseStr = model.STR,
                    Level = 1
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Character.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                    .Character
                    .Where(e => e.User == _userId)
                    .Select(
                        e =>
                        new CharacterListItem
                        {
                            ID = e.ID,
                            Name = e.Name,
                            HP = e.BaseHP + ctx.Attributes.FirstOrDefault(f => f.Level == e.Level).HP,
                            SPD = e.BaseSpd + ctx.Attributes.FirstOrDefault(f => f.Level == e.Level).SPD,
                            STR = e.BaseStr + ctx.Attributes.FirstOrDefault(f => f.Level == e.Level).STR,
                            Level = e.Level

                        });

                return query.ToArray();


            }

        }

        public CharacterDetail GetCharacterById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                        .Character
                        .Single(e => e.ID == id && e.User == _userId);
                int HPAdj = ctx.Attributes.Single(e => e.Level == entity.Level).HP;
                int STRAdj = ctx.Attributes.Single(e => e.Level == entity.Level).STR;
                int SPDAdj = ctx.Attributes.Single(e => e.Level == entity.Level).SPD;
                return
                    new CharacterDetail
                    {
                        ID = entity.ID,
                        Name = entity.Name,
                        HP = entity.BaseHP + HPAdj,
                        SPD = entity.BaseHP + STRAdj,
                        STR = entity.BaseStr + SPDAdj,
                        Level = entity.Level                        
                    };
            }
        }

    }
}
