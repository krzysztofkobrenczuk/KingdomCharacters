﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsDomain.Classes
{
    public class Warrior : IModificationHistory
    {
        public Warrior()
        {
            EquipmentOwned = new List<WarriorEquipment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInKingdom { get; set; }
        public Blood Blood { get; set; }
        public int BloodId { get; set; }
        public List<WarriorEquipment> EquipmentOwned { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool isDirty { get; set; }


    }
}
