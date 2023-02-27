using System.Windows;
using System.Windows.Media;

namespace Jaywapp.UI.Custom.DropDown
{
    public partial class DropDownSelectControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty ThemeColorProperty = DependencyProperty.Register(
            nameof(ThemeColor),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ThemeOppositeColorProperty = DependencyProperty.Register(
            nameof(ThemeOppositeColor),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PopupBackgroundColorProperty = DependencyProperty.Register(
            nameof(PopupBackgroundColor),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PopupBorderBrushProperty = DependencyProperty.Register(
            nameof(PopupBorderBrush),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty PopupBorderThicknessProperty = DependencyProperty.Register(
           nameof(PopupBorderThickness),
           typeof(Thickness),
           typeof(DropDownSelectControl),
           new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty StatusTextColorProperty = DependencyProperty.Register(
            nameof(StatusTextColor),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ListBackgroundColorProperty = DependencyProperty.Register(
            nameof(ListBackgroundColor),
            typeof(Brush),
            typeof(DropDownSelectControl),
            new FrameworkPropertyMetadata(null));
        #endregion

        #region Properties
        public Brush ThemeColor
        {
            get => (Brush)GetValue(ThemeColorProperty);
            set => SetValue(ThemeColorProperty, value);
        }

        public Brush ThemeOppositeColor
        {
            get => (Brush)GetValue(ThemeOppositeColorProperty);
            set => SetValue(ThemeOppositeColorProperty, value);
        }

        public Brush PopupBackgroundColor
        {
            get => (Brush)GetValue(PopupBackgroundColorProperty);
            set => SetValue(PopupBackgroundColorProperty, value);
        }

        public Brush PopupBorderBrush
        {
            get => (Brush)GetValue(PopupBorderBrushProperty);
            set => SetValue(PopupBorderBrushProperty, value);
        }

        public Thickness PopupBorderThickness
        {
            get => (Thickness)GetValue(PopupBorderThicknessProperty);
            set => SetValue(PopupBorderThicknessProperty, value);
        }

        public Brush StatusTextColor
        {
            get => (Brush)GetValue(StatusTextColorProperty);
            set => SetValue(StatusTextColorProperty, value);
        }

        public Brush ListBackgroundColor
        {
            get => (Brush)GetValue(ListBackgroundColorProperty);
            set => SetValue(ListBackgroundColorProperty, value);
        }
        #endregion

        #region Functions
        private void InitializeDecoration()
        {
            ThemeColor = new SolidColorBrush(Colors.DodgerBlue);
            ThemeOppositeColor = new SolidColorBrush(Colors.White);
            PopupBackgroundColor = new SolidColorBrush(Colors.White);
            PopupBorderBrush = new SolidColorBrush(Colors.Black);
            PopupBorderThickness = new Thickness(1);

            StatusTextColor = new SolidColorBrush(Colors.LightSlateGray);
        }
        #endregion
    }
}
