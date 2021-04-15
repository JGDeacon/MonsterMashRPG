using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorModels
{
    public class CharacterCreate
    {

        [Required, MinLength(4), MaxLength(16)]
        public string Name { get; set; }

        [Required, Range(5, 10, ErrorMessage = "Valid enteries are int between 5 & 10")]
        public int HP { get; set; }

        [Required, Range(5, 10, ErrorMessage = "Valid enteries are int between 5 & 10")]
        public int STR { get; set; }

        [Required, Range(5, 10, ErrorMessage = "Valid enteries are int between 5 & 10")]
        public int SPD { get; set; }
    }
}
