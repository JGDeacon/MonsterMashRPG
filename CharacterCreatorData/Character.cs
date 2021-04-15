using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorData
{
    public class Character
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Guid User { get; set; }
        [Required,MinLength(4),MaxLength(16)]
        public string Name { get; set; }
        [Required,Range(5,10,ErrorMessage ="Valid enteries are int between 5 & 10")]
        public int BaseHP { get; set; }
        [Required, Range(5, 10, ErrorMessage = "Valid enteries are int between 5 & 10")]
        public int BaseStr { get; set; }
        [Required, Range(5, 10, ErrorMessage = "Valid enteries are int between 5 & 10")]
        public int BaseSpd { get; set; }
        public int Level { get; set; }
        public Item InventoryOne { get; set; }
        public Item InventoryTwo { get; set; }
        public Item InventoryThree { get; set; }

    }
}
