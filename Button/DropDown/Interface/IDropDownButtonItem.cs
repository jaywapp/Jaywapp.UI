using System;

namespace Jaywapp.UI.Button.DropDown.Interface
{
    public interface IDropDownButtonItem
    {
        event EventHandler Selected;

        string Title { get; }
        bool IsSelected { get; set; }

        object GetSource();
    }
}
