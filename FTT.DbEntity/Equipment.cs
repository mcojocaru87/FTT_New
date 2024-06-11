namespace FTT.DbEntity
{
    public class Equipment : EntityIdentity
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public bool IsDumbbell { get; set; }
        public bool IsPlate { get; set; }

        public virtual ICollection<EquipmentItem> Items { get; set; } = [];
    }
}
