using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes.Enums;

namespace WarriorsDomain.Classes
{
    public class WarriorEquipment : IModificationHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]
        public Warrior Warrior { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool isDirty { get; set; }

    }
}
