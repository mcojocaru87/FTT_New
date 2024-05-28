namespace FTT.DbEntity
{
    public class Setting : EntityIdentity
    {
        public int FailAttempts { get; set; }
        public int MaxReps { get; set; }        
    }
}
