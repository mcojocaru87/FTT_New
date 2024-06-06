using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTT.DbEntity
{
    public class Equipment : EntityIdentity
    {
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<EquipmentItem> Items { get; set; } = [];
    }
}
