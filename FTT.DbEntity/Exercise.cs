namespace FTT.DbEntity
{
    public class Exercise : EntityIdentity
    {
        public required string Name { get; set; }
        public int Multiplier { get; set; }
        public string Category { get; set; } = string.Empty;
        public int EquipmentId { get; set; }
    }
}
