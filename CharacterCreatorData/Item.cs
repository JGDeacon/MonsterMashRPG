using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorData
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int HPModifier { get; set; }
        public int STRModifier { get; set; }
        public int SPDModifier { get; set; }
    }
}
