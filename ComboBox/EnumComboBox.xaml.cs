using Jaywapp.Infrastructure.Converter;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Jaywapp.UI.ComboBox
{
    /// <summary>
    /// EnumComboBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EnumComboBox : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private ObservableCollection<object> _candidates = new ObservableCollection<object>();
        #endregion

        public static readonly DependencyProperty EnumProperty = DependencyProperty.Register(
            nameof(Enum),
            typeof(Enum),
            typeof(EnumComboBox),
            new FrameworkPropertyMetadata(
                null,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                OnDependencyPropertyChanged));

        public Enum Enum
        {
            get => (Enum)GetValue(EnumProperty);
            set => SetValue(EnumProperty, value);
        }

        public ObservableCollection<object> Candidates
        {
            get => _candidates;
            set
            {
                _candidates = value;
                RaisePropertyChanged();
            }
        }

        public EnumComboBox()
        {
            InitializeComponent();
        }

        private static void OnDependencyPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is EnumComboBox view))
                return;

            if(e.Property == EnumProperty)
            {
                view.OnEnumChanged(e);
            }
        }

        private void OnEnumChanged(DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue.GetType();

            var candidates = new ObservableCollection<object>();
            foreach(var enumValue in type.GetEnumValues())
                candidates.Add(enumValue);

            Candidates = candidates;
        }
    }
}
