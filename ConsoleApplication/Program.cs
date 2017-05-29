using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes.Enums;
using WarriorsDomain.DataModel;
using WarriorsDomain.Classes;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new NullDatabaseInitializer<WarriorsContext>());
            //InsertWarrior();
            //InsertMultipleWarriors();
            //SimpleWarriorQueries();
            //QueryAndUpdateWarrior();     
            //QueryAndUpdateWarriorDisconnected();
            //RetrieveDataWithFind();
            // DeleteWarrior();
            //InserWarriorWithEquipment();
            // SimpleWarriorGraphQuery();
            ProjectionQuery();
            Console.ReadKey();
        }

        private static void InsertWarrior()
        {
            var wojownik = new Warrior
            {
                Name = "TomRent",
                ServedInKingdom = false,
                DateOfBirth = new DateTime(1998, 1, 1),
                BloodId = 1
            };
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Warriors.Add(wojownik);
                context.SaveChanges();
            }
        }
        private static void InsertMultipleWarriors()
        {
            var warrior1 = new Warrior
            {
                Name = "Eric Sanderson",
                ServedInKingdom = true,
                DateOfBirth = new DateTime(1968,2, 2),
                BloodId = 1
            };
            var warrior2 = new Warrior
            {
                Name = "Christopher Crusit",
                ServedInKingdom = true,
                DateOfBirth = new DateTime(1962, 3, 3),
                BloodId = 1
            };
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Warriors.AddRange(new List<Warrior> { warrior1, warrior2 });
                context.SaveChanges();
            }
        }

        private static void SimpleWarriorQueries()
        {
            using (var context = new WarriorsContext())
            {
                var warriors = context.Warriors
                    .Where(n => n.DateOfBirth >= new DateTime(1932,1,1))
                    .OrderBy(n => n.Name)
                    .Skip(1).Take(1)
                    .FirstOrDefault();
                //var query = context.Warriors;
                // var somewarriors = query.toList();
               
                    Console.WriteLine(warriors.Name);
                
            }
        }

        private static void QueryAndUpdateWarrior()
        {
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                var warrior = context.Warriors.FirstOrDefault();
                warrior.ServedInKingdom = (!warrior.ServedInKingdom);
                context.SaveChanges();
            }
        }

        private static void QueryAndUpdateWarriorDisconnected()
        {
            Warrior warrior;
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                warrior = context.Warriors.FirstOrDefault();
            }
            warrior.ServedInKingdom = (!warrior.ServedInKingdom);

            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Warriors.Add(warrior);
                context.Entry(warrior).State = EntityState.Modified; 
                context.SaveChanges();
            }
        }

        private static void RetrieveDataWithFind()
        {
            var keyvalue = 2;
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                var warrior = context.Warriors.Find(keyvalue);
                Console.WriteLine("After Find#1: " + warrior.Name);

                var someWarrior = context.Warriors.Find(keyvalue);
                Console.WriteLine("After Find#2:" + someWarrior.Name);
                warrior = null;
            }
        }

        private static void DeleteWarrior()
        {
            Warrior warrior;

            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                warrior = context.Warriors.FirstOrDefault();
                //context.Warriors.Remove(warrior);
                //context.SaveChanges();
            }
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Warriors.Attach(warrior);
                //context.Warriors.Remove(warrior);
                context.Entry(warrior).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        private static void InserWarriorWithEquipment()
        {
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;

                var warrior = new Warrior
                {
                    Name = "Robert Istern",
                    ServedInKingdom = true,
                    DateOfBirth = new DateTime(1991, 3, 4),
                    BloodId = 1
                };
                var bigSword = new WarriorEquipment
                {
                    Name = "Crystal Sword",
                    Type = EquipmentType.Weapon
                };
                var chainArmor = new WarriorEquipment
                {
                    Name = "Chain Armor",
                    Type = EquipmentType.Outwear
                };
                context.Warriors.Add(warrior);
                warrior.EquipmentOwned.Add(bigSword);
                warrior.EquipmentOwned.Add(chainArmor);
                context.SaveChanges();
            }
        } 

         private static void SimpleWarriorGraphQuery()
        {
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;

                var warrior = context.Warriors
                    .FirstOrDefault(n => n.Name.StartsWith("Rob"));
                Console.WriteLine("Warrioro Retrieved:" + warrior.Name);
                //context.Entry(warrior).Collection(n => n.EquipmentOwned).Load();
                Console.WriteLine("Warrior Equipment Count: {0}", warrior.EquipmentOwned.Count());
            }
        }
        private static void ProjectionQuery()
        {
            using (var context = new WarriorsContext())
            {
                context.Database.Log = Console.WriteLine;
                var warriors = context.Warriors
                    .Select(n => new { n.Name, n.DateOfBirth, n.EquipmentOwned })
                    .ToList();
            }
        }
    }
}
