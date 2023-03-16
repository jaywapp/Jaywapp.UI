using Jaywapp.Infrastructure.Block.Interface;
using System.Windows;
using System.Windows.Controls;

namespace Jaywapp.UI.Block
{
    /// <summary>
    /// BlockView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class BlockView : UserControl
    {
        public static readonly DependencyProperty BlockProperty = DependencyProperty.Register(
            nameof(Block), typeof(IBlock), typeof(BlockView), new FrameworkPropertyMetadata(null));

        public IBlock Block
        {
            get => (IBlock)GetValue(BlockProperty);
            set => SetValue(BlockProperty, value);
        }

        public BlockView()
        {
            InitializeComponent();
        }
    }
}
