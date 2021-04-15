using CharacterCreatorData;
using CharacterCreatorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorServices
{
    public class SeedService
    {
        public bool CreateLevel(AddLevel model)
        {
            var entity = new LevelTable()
            {
              XP = model.XP
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public void SeedLevelTable()
        {
            var entity = new Attributes()
                 {
                HP=16,
                STR=3,
                SPD=3
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity);
                ctx.SaveChanges();
            }
            var entity1 = new Attributes()
            {
                HP = 20,
                STR = 6,
                SPD = 6
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity1);
                ctx.SaveChanges();
            }
            var entity2 = new Attributes()
            {
                HP = 24,
                STR = 10,
                SPD = 10
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity2);
                ctx.SaveChanges();
            }
            var entity3 = new Attributes()
            {
                HP = 28,
                STR = 11,
                SPD = 11
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity3);
                ctx.SaveChanges();
            }
            var entity4 = new Attributes()
            {
                HP = 35,
                STR = 14,
                SPD = 14
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity4);
                ctx.SaveChanges();
            }
            var entity5 = new Attributes()
            {
                HP = 41,
                STR = 19,
                SPD = 19
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity5);
                ctx.SaveChanges();
            }
            var entity6 = new Attributes()
            {
                HP = 50,
                STR = 25,
                SPD = 25
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity6);
                ctx.SaveChanges();
            }
            var entity7 = new Attributes()
            {
                HP = 55,
                STR = 30,
                SPD = 30
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity7);
                ctx.SaveChanges();
            }
            var entity8 = new Attributes()
            {
                HP = 61,
                STR = 34,
                SPD = 34
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity8);
                ctx.SaveChanges();
            }
            var entity9 = new Attributes()
            {
                HP = 68,
                STR = 39,
                SPD = 39
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attributes.Add(entity9);
                ctx.SaveChanges();
            }
            
        }
        public void SeedAdjustmentTable()
        {
            var entity = new LevelTable()
            {
                Level=1,
                XP=20
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity);
                ctx.SaveChanges();
            }
            var entity1 = new LevelTable()
            {
                Level = 2,
                XP = 50
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity1);
                ctx.SaveChanges();
            }
            var entity2 = new LevelTable()
            {
                Level = 3,
                XP = 80
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity2);
                ctx.SaveChanges();
            }
            var entity3 = new LevelTable()
            {
                XP = 110
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity3);
                ctx.SaveChanges();
            }
            var entity4 = new LevelTable()
            {
                XP = 140
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity4);
                ctx.SaveChanges();
            }
            var entity5 = new LevelTable()
            {
                XP = 170
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity5);
                ctx.SaveChanges();
            }
            var entity6 = new LevelTable()
            {
                XP = 200
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity6);
                ctx.SaveChanges();
            }
            var entity7 = new LevelTable()
            {
                XP = 230
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity7);
                ctx.SaveChanges();
            }
            var entity8 = new LevelTable()
            {
                XP = 260
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity8);
                ctx.SaveChanges();
            }
            var entity9 = new LevelTable()
            {
                XP = 290
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.LevelTable.Add(entity9);
                ctx.SaveChanges();
            }
        }
    }
}
