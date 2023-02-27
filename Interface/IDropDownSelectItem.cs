using System;

namespace Jaywapp.UI.Interface
{
    public interface IDropDownSelectItem
    {
        event EventHandler Selected;

        string Title { get; }
        bool IsSelected { get; set; }

        object GetSource();
    }
}
