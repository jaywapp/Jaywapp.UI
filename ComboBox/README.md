# EnumComboBox
You can easily use combobox about Enum type with description attribute.
![image](https://user-images.githubusercontent.com/20869970/224641034-a5d5d3b1-524e-4680-869c-452ee900b28a.png)

## Usage
### View
```
<Window x:Class="JFilter.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:combobox="clr-namespace:Jaywapp.UI.ComboBox;assembly=Jaywapp.UI"
        mc:Ignorable="d" Title="MainWindow" Height="450" Width="800">
    <combobox:EnumComboBox Margin="50" Enum="{Binding EnumValue, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
</Window>
```

### Enum
```
public enum eEnumValue
{
    [Description("Alphabet A")]
    A,
    [Description("Alphabet B")]
    B,
    [Description("Alphabet C")]
    C,
}
```

### Enum :heavy_check_mark:
this is Enum value binding with ui.
