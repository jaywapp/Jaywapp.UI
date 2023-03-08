using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jaywapp.UI.Text.Box
{
    /// <summary>
    /// PlaceHolderTextBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PlaceHolderTextBox : UserControl, INotifyPropertyChanged
    {
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Internal Field
        private string _displayText;
        private bool _isEmpty = true;
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(PlaceHolderTextBox),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PlaceHolderTextProperty = DependencyProperty.Register(
            nameof(PlaceHolderText),
            typeof(string),
            typeof(PlaceHolderTextBox),
            new FrameworkPropertyMetadata(null));

        public static readonly RoutedEvent TextChanegdEvent = EventManager.RegisterRoutedEvent(
            nameof(TextChanged),
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PlaceHolderTextBox));
        #endregion

        #region Properties
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string PlaceHolderText
        {
            get => (string)GetValue(PlaceHolderTextProperty);
            set => SetValue(PlaceHolderTextProperty, value);
        }

        public string DisplayText
        {
            get => _displayText;
            set
            {
                _displayText = value;
                RaisePropertyChanged();
            }
        }

        public bool IsEmpty
        {
            get => _isEmpty;
            set
            {
                _isEmpty = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Event
        public event RoutedEventHandler TextChanged
        {
            add => AddHandler(TextChanegdEvent, value);
            remove => RemoveHandler(TextChanegdEvent, value);
        }
        #endregion

        #region Constructor
        public PlaceHolderTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            Text = textBox.Text;
            DisplayText = textBox.Text;
            IsEmpty = string.IsNullOrEmpty(textBox.Text);
            RaiseEvent(new RoutedEventArgs(TextChanegdEvent));
        }
        #endregion
    }
}
