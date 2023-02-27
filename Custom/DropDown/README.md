# DropDownSelectControl
For filtering list, You can use this control. this control filter the list using checking and searching.
### When DropDownSelectControl Clicked
![image](https://user-images.githubusercontent.com/20869970/221497998-47ae07d2-8875-4d9f-bec3-ba368583cc2c.png)
### When some items are selected
![image](https://user-images.githubusercontent.com/20869970/221498121-6d373e5d-a992-4618-a8ea-379f018cdfcc.png)
### When searching
![image](https://user-images.githubusercontent.com/20869970/221498190-a243360b-dbeb-4f68-84ff-5b8878290134.png)

## Usage
### xaml
```
<Window x:Class="Jaywapp.UI.Viewer.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:dropdown="clr-namespace:Jaywapp.UI.Custom.DropDown;assembly=Jaywapp.UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        x:Name="_userControl">
    <dropdown:DropDownSelectControl
            DataSource="{Binding ElementName=_userControl, Path=Items}"
            SelectedSource="{Binding ElementName=_userControl, Path=SelectedItems, Mode=TwoWay}"/>
</Window>
```
### behind
```
public partial class MainWindow : Window, INotifyPropertyChanged
{
    #region Property Changed
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    #endregion

    #region Internal Field
    private ObservableCollection<string> _items = new ObservableCollection<string>();
    private IEnumerable<object> _selectedItems = Enumerable.Empty<object>();
    #endregion

    #region Properties
    public ObservableCollection<string> Items
    {
        get => _items;
        set
        {
            _items = value;
            RaisePropertyChanged();
        }
    }

    public IEnumerable<object> SelectedItems
    {
        get => _selectedItems;
        set
        {
            _selectedItems = value;
            RaisePropertyChanged();
        }
    }
    #endregion

    #region Constructor
    public MainWindow()
    {
        Items = new ObservableCollection<string>()
        {
            "Test1",
            "Test2",
            "Test3",
            "Test4",
        };

        InitializeComponent();
    }
    #endregion
}
```

### DataSource :heavy_check_mark:
filtering condition list. You can bind with objects in behind code or view model.
### SelectedSource :heavy_check_mark:
selected condition list. You can bind with objects in behind code or view model.
(:heavy_exclamation_mark: it must be defined as `IEnumerable<object>`)

## Configuration
![230227](https://user-images.githubusercontent.com/20869970/221499596-a57e038e-7bd7-4585-87ab-eb3e19b6658d.png)
### Color Configuration
- ThemeColor : theme color of control.
- ThemeOppositeColor : theme opposite color of control.
- PopupBackgroundColor : popup`s background color.
- PopupBorderBrush : popup`s border color.
- StatusTextColor : state text color.
- ListBackgroundColor : color of list in popup view.

### Other Configuration
- PopupBorderThickness : state text thickness
