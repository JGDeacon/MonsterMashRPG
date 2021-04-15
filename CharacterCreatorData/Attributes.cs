using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorData
{
    public class Attributes
    {
        [Key]
        public int Level { get; set; }
        [Required]
        public int HP { get; set; }
        [Required]
        public int STR { get; set; }
        [Required]
        public int SPD { get; set; }
    }
}
