using Jaywapp.UI.Interface;
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
        #region Constructor
        public FilterView()
        {
            InitializeComponent();
        }
        #endregion

        #region Functions
        /// <summary>
        /// 단일 필터항목 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFilter(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is FilterGroupItem item))
                return;

            item.AddFilter();
        }

        /// <summary>
        /// 복합 필터 그룹 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFilterGroup(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is FilterGroupItem item))
                return;

            item.AddFilterGroup();
        }

        /// <summary>
        /// 항목 제거
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button) || !(button.DataContext is IFilterItem item))
                return;

            item.RemoveSelf();
        }
        #endregion
    }
}
