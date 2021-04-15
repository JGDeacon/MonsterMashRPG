using CharacterCreatorData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorModels
{
    public class CharacterDescription
    {
        public int ID { get; set; }
       
        public string Name { get; set; }
       
        public int HP { get; set; }
      
        public int STR { get; set; }
        
        public int SPD { get; set; }

        public int Level { get; set; }

        public Item InventoryOne { get; set; }

        public Item InventoryTwo { get; set; }

        public Item InventoryThree { get; set; }

        public DateTimeOffset TotalTimePlayed { get; set; }

    }
}
