namespace Jaywapp.UI.Interface
{
    /// <summary>
    /// Model including category information by using for combo box "ItemsSource"
    /// </summary>
    public interface ICategoriedItem
    {
        /// <summary>
        /// Category Information
        /// It will be used when grouping.
        /// </summary>
        string Category { get; }

        /// <summary>
        /// Combobox real value
        /// </summary>
        string Text { get; }
    }
}
