using Jaywapp.UI.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Jaywapp.UI.ComboBox.Categoried
{
    /// <summary>
    /// CategoriedComboBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CategoriedComboBox : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty CategoriedItemsSourceProperty = DependencyProperty.Register(
            nameof(CategoriedItemsSource),
            typeof(IEnumerable<ICategoriedItem>),
            typeof(CategoriedComboBox),
            CreateMetadata());

        public static readonly DependencyProperty SelectedTextProperty = DependencyProperty.Register(
            nameof(SelectedText), 
            typeof(string), 
            typeof(CategoriedComboBox),
            CreateMetadata());
        #endregion

        #region Properties
        public IEnumerable<ICategoriedItem> CategoriedItemsSource
        {
            get => (IEnumerable<ICategoriedItem>)GetValue(CategoriedItemsSourceProperty);
            set => SetValue(CategoriedItemsSourceProperty, value);
        }

        public string SelectedText
        {
            get => (string)GetValue(SelectedTextProperty);
            set => SetValue(SelectedTextProperty, value);
        }
        #endregion

        #region Constructor
        public CategoriedComboBox()
        {
            InitializeComponent();
            _comboBox.SelectionChanged += OnSelectedItemChanged;
        }
        #endregion

        #region Functions
        private static PropertyMetadata CreateMetadata()
        {
            return new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnDependencyPropertyChanged); 
        }

        private static void OnDependencyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var control = obj as CategoriedComboBox;

            if (e.Property == CategoriedItemsSourceProperty)
            {
                control.OnCategoriedItemsSourcePropertyChanged(e);
            }
            else if (e.Property == SelectedTextProperty)
            {
                control.OnSelectedTextPropertyChanged(e);
            }
        }

        private void OnSelectedTextPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var text = e.NewValue as string;
            var target = CategoriedItemsSource.FirstOrDefault(s => s.Text == text);
            if (target == null)
                return;

            _comboBox.SelectedItem = target;
        }

        private void OnCategoriedItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            var items = e.NewValue as IEnumerable<ICategoriedItem>;
            if (items == null)
                return;

            _comboBox.ItemsSource = CreateListCollectionView(items);
        }

        private void OnSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            var count = e.AddedItems.Count;
            var selected = e.AddedItems[count - 1];

            if (selected is ICategoriedItem item)
                SelectedText = item.Text;
        }

        private static ListCollectionView CreateListCollectionView(IEnumerable<ICategoriedItem> items)
        {
            var collectionView = new ListCollectionView(items.ToList());
            var groupDescription = new PropertyGroupDescription(nameof(ICategoriedItem.Category));

            collectionView.GroupDescriptions.Add(groupDescription);

            return collectionView;
        }
        #endregion
    }
}
