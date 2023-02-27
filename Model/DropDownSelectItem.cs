using Jaywapp.UI.Interface;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Jaywapp.UI.Model
{
    public class DropDownSelectItem<T> : IDropDownSelectItem, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private bool _isSelected;
        #endregion

        #region Properties
        public T Source { get; }
        public string Title { get; }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                RaisePropertyChanged();
                Selected?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Event
        public event EventHandler Selected;
        #endregion

        #region Constructor
        public DropDownSelectItem(T source)
        {
            Source = source;
            Title = source.ToString();
        }
        #endregion

        #region Functions
        public object GetSource() => Source;
        #endregion
    }
}
