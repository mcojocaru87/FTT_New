namespace FTT.ViewModels
{
    public class ComboBoxViewModel(int? valueMember, string displayMember)
    {
        public int? ValueMember { get; set; } = valueMember;
        public string DisplayMember { get; set; } = displayMember;
    }
}
