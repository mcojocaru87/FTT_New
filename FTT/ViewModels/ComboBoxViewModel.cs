namespace FTT.ViewModels
{
    public class ComboBoxViewModel(object? valueMember, string displayMember)
    {
        public object? ValueMember { get; set; } = valueMember;
        public string DisplayMember { get; set; } = displayMember;
    }
}
