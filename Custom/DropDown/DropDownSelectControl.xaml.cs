using Jaywapp.UI.Interface;
using Jaywapp.UI.Model;
using Jaywapp.UI.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jaywapp.UI.Custom.DropDown
{
    /// <summary>
    /// EnumDrowDownButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class DropDownSelectControl : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(
          nameof(DataSource),
          typeof(IEnumerable<object>),
          typeof(DropDownSelectControl),
          new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnDependencyPropertyChanged));

        public static readonly DependencyProperty SelectedSourceProperty = DependencyProperty.Register(
            nameof(SelectedSource),
            typeof(IEnumerable<object>),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public IEnumerable<object> DataSource
        {
            get => (IEnumerable<object>)GetValue(DataSourceProperty);
            set => SetValue(DataSourceProperty, value);
        }

        public IEnumerable<object> SelectedSource
        {
            get => (IEnumerable<object>)GetValue(SelectedSourceProperty);
            set => SetValue(SelectedSourceProperty, value);
        }
        #endregion

        #region Internal Field
        private string _displayText;
        private string _status;
        private string _filteringPattern;
        private BindingList<IDropDownSelectItem> _itemsSource = new BindingList<IDropDownSelectItem>();
        private BindingList<IDropDownSelectItem> _selectedItems = new BindingList<IDropDownSelectItem>();
        #endregion

        #region Properties
        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                RaisePropertyChanged();
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        public BindingList<IDropDownSelectItem> ItemsSource
        {
            get
            {
                var items = _itemsSource;

                if (!string.IsNullOrEmpty(_filteringPattern))
                {
                    var filtered = items
                        .Where(i => i.Title.Contains(_filteringPattern))
                        .ToList();

                    items = ToBindingList(filtered);
                }

                return items;
            }
            set
            {
                _itemsSource = value;
                RaisePropertyChanged();
                UpdateStatus();
            }
        }
        public BindingList<IDropDownSelectItem> SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value;
                RaisePropertyChanged();

                var sources = value.Select(i => i.GetSource()).ToList();
                var displayText = string.Join(", ", value.Select(i => i.Title));

                SelectedSource = sources;
                DisplayText = displayText;

                UpdateStatus();
            }
        }
        #endregion

        #region Constructor
        public DropDownSelectControl()
        {
            InitializeDecoration();
            InitializeComponent();
        }
        #endregion

        #region Functions
        private static void OnDependencyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as DropDownSelectControl;

            if (e.Property == DataSourceProperty)
                control.OnDataSourcePropertyChanged(e);
        }

        private void OnDataSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (!(e.NewValue is IEnumerable<object> dataSource))
                return;

            var items = dataSource
                .Select(s => new DropDownSelectItem<object>(s))
                .Cast<IDropDownSelectItem>()
                .ToList();

            items.ForEach(i => i.Selected += UpdateSelections);
            ItemsSource = ToBindingList(items);
        }

        private void UpdateSelections(object sender, EventArgs args)
        {
            SelectedItems = ToBindingList(ItemsSource.Where(i => i.IsSelected));
        }

        private static BindingList<T> ToBindingList<T>(IEnumerable<T> enumerable)
        {
            return new BindingList<T>(enumerable.ToList());
        }

        private void OnTextChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PlaceHolderTextBox textBox))
                return;

            _filteringPattern = textBox.Text;
            RaisePropertyChanged(nameof(ItemsSource));
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            foreach (var item in ItemsSource)
                item.IsSelected = true;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            foreach (var item in ItemsSource)
                item.IsSelected = false;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            foreach (var item in ItemsSource)
                item.IsSelected = false;

            _toggle.IsChecked = false;
        }

        private void Done(object sender, RoutedEventArgs e)
        {
            _toggle.IsChecked = false;
        }

        private void UpdateStatus()
        {
            Status = $"{SelectedItems.Count} of {ItemsSource.Count}";
        }
        #endregion
    }
}
