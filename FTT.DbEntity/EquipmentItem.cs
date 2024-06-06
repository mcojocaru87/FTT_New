using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTT.DbEntity
{
    public class EquipmentItem : EntityIdentity
    {
        public int EquipmentId { get; set; }
        public int Units { get; set; }
        public decimal Weight { get; set; }
        public string UoM { get; set; } = string.Empty;

        public virtual Equipment Equipment { get; set; } = null!;
    }
}
