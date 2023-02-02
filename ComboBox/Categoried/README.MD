# CategoriedComboBox
![CategoriedComboBox](https://user-images.githubusercontent.com/20869970/216238850-4b5ff663-0553-4ef0-94c8-6779d1ebd86f.gif)

ComboBox for selection by grouping items. You can make groups using 'category'. 

## Usage
### Model (CategoriedItem)
You must define `Model` that is inherited by `ICategoriedItem`. this model is used as source in combobox.

```
public class CategoriedItem : ICategoriedItem
{
    public string Category { get; set; }
    public string Text { get; set; }

    public CategoriedItem(string category, string text)
    {
        Category = category;
        Text = text;
    }
}
```

### View
```
<Window x:Class="Jaywapp.UI.CategoriedComboBox.Usage.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
        xmlns:ui="clr-namespace:Jaywapp.UI.ComboBox.Categoried;assembly=Jaywapp.UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <StackPanel>
        <!-- Use CategoriedComboBox -->
        <ui:CategoriedComboBox Width="300" Height="30" 
                CategoriedItemsSource="{Binding Items}"
                SelectedText="{Binding Selected}"/>
    </StackPanel>
</Window>
```

### ViewModel
```
public class MainWindowViewModel : ReactiveObject
{
    private List<CategoriedItem> _items = new List<CategoriedItem>();
    private string _selected;

    public List<CategoriedItem> Items
    {
        get => _items;
        set => this.RaiseAndSetIfChanged(ref _items, value);
    }

    public string Selected
    {
        get => _selected;
        set => this.RaiseAndSetIfChanged(ref _selected, value);
    }

    public MainWindowViewModel()
    {
        Items = new List<CategoriedItem>()
        {
            new CategoriedItem("Group1", "Value1"),
            new CategoriedItem("Group1", "Value2"),
            new CategoriedItem("Group1", "Value3"),

            new CategoriedItem("Group2", "Value4"),
            new CategoriedItem("Group2", "Value5"),

            new CategoriedItem("Group3", "Value6"),

            new CategoriedItem("Group4", "Value7"),
            new CategoriedItem("Group4", "Value8"),
            new CategoriedItem("Group4", "Value9"),
        };
    }

}
```

