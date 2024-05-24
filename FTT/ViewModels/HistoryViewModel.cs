namespace FTT.ViewModels
{
    using System.Collections.Generic;

    public class HistoryViewModel
    {
        private Dictionary<string, object> properties = new();

        public object this[string propertyName]
        {
            get
            {
                properties.TryGetValue(propertyName, out var value);
                return value;
            }
            set
            {
                properties[propertyName] = value;
            }
        }

        public Dictionary<string, object> GetProperties() => properties;
    }
}
