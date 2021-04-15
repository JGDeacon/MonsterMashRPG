using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorData
{
    public class LevelTable
    {
        [Key]
        public int Level { get; set; }
        public int XP { get; set; }
    }
}
