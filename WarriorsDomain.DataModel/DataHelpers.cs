using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes;

namespace WarriorsDomain.DataModel
{
    public class DataHelpers
    {
        public static void NewDoWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<WarriorsContext>());
            using (var context = new WarriorsContext())
            {
                if (context.Warriors.Any())
                {
                    return;
                }
                var ErtoBlood = context.Bloods.Add(new Blood { BloodName = "Erto Blood" });
                var ClashBlood = context.Bloods.Add(new Blood { BloodName = "Clash Blood" });
                var OtenBlood = context.Bloods.Add(new Blood { BloodName = "Oten Blood" });

            }
        }
    }
}
