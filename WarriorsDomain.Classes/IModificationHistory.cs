using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarriorsDomain.Classes
{
    public interface IModificationHistory
    {
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }
        bool isDirty { get; set}
    }
}
