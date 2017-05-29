using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes;

namespace WarriorsDomain.DataModel
{
    public class ConnectedRepository
    {
        private readonly WarriorContext _context = new WarriorContext();

        public Warrior GetWarriorWithEquipment(int id)
        {
            return _context.Warriors.Include(n => n.EquipmentOwned)
                .FirstOrDefault(n => n.Id == id);
        }
        public Warrior GetWarriorById(int id)
        {
            return _context.Warriors.Find(id);
        }
        public List<Warrior> GetWarriors()
        {
            return _context.Warriors.ToList();
        }
        public IEnumerable GetBloodList()
        {
            return _context.Bloods
                .OrderBy(b => b.BloodName)
                .Select(b => new { b.Id, b.BloodName })
                .ToList();
        }

        public ObservableCollection<Warrior> WarriorsInMemory()
        {
            if (_context.Warriors.Local.Count == 0)
            {
                GetWarriors();
            }
            return _context.Warriors.Local;
        }

        public void Save()
        {
            RemoveEmptyNewWarrior();
            _context.SaveChanges();
        }

        public Warrior NewWarrior()
        {
            var warrior = new Warrior();
            _context.Warriors.Add(warrior);
            return warrior;
        }
        public void RemoveEmptyNewWarrior()
        {
            //When not saved new warrior and leave program.
            for (var i = _context.Warriors.Local.Count; i > 0; i--)
            {
                var warrior = _context.Warriors.Local[i - 1];
                if (_context.Entry(warrior).State == EntityState.Added && !warrior.isDirty)
                {
                    _context.Warriors.Remove(warrior);
                }
            }
        }

        public void DeleteCurrentWarrior(Warrior warrior)
        {
            _context.Warriors.Remove(warrior);
            Save();
        }

        public void DeleteEquipment(ICollection equipmentList)
        {
            foreach (WarriorEquipment equip in equipmentList)
            {
                _context.Equipment.Remove(equip);
            }
        }

        public void DeleteEquipment(IList oldItems)
        {
            throw new NotImplementedException();
        }
    }
}
