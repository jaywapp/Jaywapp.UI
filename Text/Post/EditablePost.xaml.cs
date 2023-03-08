using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Jaywapp.UI.Text.Post
{
    /// <summary>
    /// EditablePost.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class EditablePost : UserControl, INotifyPropertyChanged
    {
        #region Const Field
        private const string CONFIRM = "Confirm";
        private const string EDIT = "Edit";
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty TitleTextProperty = DependencyProperty.Register(
            nameof(TitleText), typeof(string), typeof(EditablePost), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty TitleTextFontSizeProperty = DependencyProperty.Register(
            nameof(TitleTextFontSize), typeof(int), typeof(EditablePost), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ContentTextProperty = DependencyProperty.Register(
            nameof(ContentText), typeof(string), typeof(EditablePost), new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ContentTextFontSizeProperty = DependencyProperty.Register(
            nameof(ContentTextFontSize), typeof(int), typeof(EditablePost), new FrameworkPropertyMetadata(null));
        #endregion

        #region Internal Field
        private bool _isEditable = false;
        private string _buttonContent = "";
        #endregion

        #region Properties
        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public int TitleTextFontSize
        {
            get => (int)GetValue(TitleTextFontSizeProperty);
            set => SetValue(TitleTextFontSizeProperty, value);
        }

        public string ContentText
        {
            get => (string)GetValue(ContentTextProperty);
            set => SetValue(ContentTextProperty, value);
        }

        public int ContentTextFontSize
        {
            get => (int)GetValue(ContentTextFontSizeProperty);
            set => SetValue(ContentTextFontSizeProperty, value);
        }

        public bool IsEditable
        {
            get => _isEditable;
            set
            {
                _isEditable = value;
                RaisePropertyChanged();
            }
        }

        public string ButtonContent
        {
            get => _buttonContent;
            set
            {
                _buttonContent = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Constructor
        public EditablePost()
        {
            InitializeComponent();
            IsEditable = false;
            ButtonContent = EDIT;
        }
        #endregion

        #region Functions
        private void Edit(object sender, RoutedEventArgs e)
        {
            IsEditable = !IsEditable;
            ButtonContent = IsEditable ? CONFIRM : EDIT;
        }
        #endregion
    }
}
