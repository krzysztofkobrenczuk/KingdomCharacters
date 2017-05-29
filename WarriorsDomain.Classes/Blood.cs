using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes.Interfaces;

namespace WarriorsDomain.Classes
{
    public class Blood : IModificationHistory
    {
        public Blood()
        {
            Warriors = new List<Warrior>();
        }
        public int Id { get; set; }
        public string BloodName { get; set; }
        public List<Warrior> Warriors { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool isDirty { get; set; }
    }
}
