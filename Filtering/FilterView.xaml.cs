using Jaywapp.UI.Model;
using System.Windows;
using System.Windows.Controls;

namespace Jaywapp.UI.Filtering
{
    /// <summary>
    /// FilterView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FilterView : UserControl
    {
        public FilterView()
        {
            InitializeComponent();
        }

        private void AddFilter(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is FilterGroupItem item))
                return;

            item.AddFilter();
        }

        private void AddFilterGroup(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is FilterGroupItem item))
                return;

            item.AddFilterGroup();
        }
    }
}
