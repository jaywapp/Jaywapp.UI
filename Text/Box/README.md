# PlaceHolderTextBox
This is textbox has placeholder. You can use this for provide input information.
### Empty
![image](https://user-images.githubusercontent.com/20869970/221494846-9a781607-b3d5-45e5-be01-20ffa7abb902.png)
### Input Something
![image](https://user-images.githubusercontent.com/20869970/221494891-7800988f-c667-404e-b949-b00a4c0ec8bf.png)

## Usage
```
<Window x:Class="Jaywapp.UI.Viewer.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:text="clr-namespace:Jaywapp.UI.Text;assembly=Jaywapp.UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        x:Name="_userControl">
    <Grid>
        <text:PlaceHolderTextBox Margin="50" Height="50"
                PlaceHolderText="Search!"
                Text="{Binding ElementName=_userControl, Path=Text, Mode=TwoWay}"/>
    </Grid>
</Window>
```

### PlaceHolderText :heavy_check_mark:
Text for empty state. You can set PlaceHolderText directly in xaml and set binding from behind code or ViewModel.
### Text :heavy_check_mark:
Text is similar to original `textbox` from wpf.
### TextChanged :heavy_check_mark:
Receive and deliver the original event from `textbox`. At this point, deliver the PlaceHolderText to the sender and the default to RoutedEventArgs.
### Foreground
Gets the default value from `UserControl`
### VerticalAlignment
Gets the default value from `UserControl`
### HorizontalAlignment
Gets the default value from `UserControl`
### FontSize
Gets the default value from `UserControl`
