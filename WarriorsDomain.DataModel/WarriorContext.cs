using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarriorsDomain.Classes;
using WarriorsDomain.Classes.Interfaces;

namespace WarriorsDomain.DataModel
{
    public class WarriorContext : DbContext
    {
        public DbSet<Warrior> Warriors { get; set; }
        public DbSet<Blood> Bloods { get; set; }
        public DbSet<WarriorEquipment> Equipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().
                Configure(c => c.Ignore("isDirty"));
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added|| 
                e.State == EntityState.Modified))
                .Select(e=>e.Entity as IModificationHistory)
                )
            {
                history.DateModified = DateTime.Now;
                if(history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now; ;
                }
            }
            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e=> e.Entity is IModificationHistory)
                .Select(e => e.Entity as IModificationHistory)
                )
            {
                history.isDirty = false;
            }
            return result;

        }
    }
}
