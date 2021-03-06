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
        private static int MaxXP = 290;
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
                    Level = 1,
                    XP=0
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Character.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool AddXP(AddXP model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Character character = ctx.Character.Single(e => e.ID == model.CharacterID);
                character.XP = character.XP + model.XPChange;
                if (character.XP>MaxXP)
                {
                    character.Level = 10;
                }
                else if (character.XP <=20)
                {
                    character.Level = 1;
                }
                else
                {
                    character.Level = SetLevel(character.XP);
                }                
                if (ctx.SaveChanges()==1)
                {
                    return true;
                }
                return false;
            }
        }

        private int SetLevel(int xp)
        {
            using(var ctx = new ApplicationDbContext())
            {
                try
                {
                    int returnLevel = ctx.LevelTable.FirstOrDefault(e => e.XP <= xp).Level;
                    return (returnLevel > 0) ? returnLevel : 1;
                }
                catch (Exception)
                {

                    return 10;
                }
                
               
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
                            Level = e.Level,
                            XP = e.XP
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
                        Level = entity.Level,
                        XP = entity.XP
                        
                    };
            }
        }

    }
}
