# EditablePost
This is posting control. You can write header and content text with edit button.
![editablepost](https://user-images.githubusercontent.com/20869970/224026972-38047527-61b9-463b-99f1-836de58fd7f5.gif)

## Usage
```
<Window x:Class="Jaywapp.UI.Viewer.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:post="clr-namespace:Jaywapp.UI.Text.Post;assembly=Jaywapp.UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <post:EditablePost 
            Margin="20" BorderBrush="Black" BorderThickness="1"
            TitleText="Title"
            TitleTextFontSize="20"
            ContentText="This is Content"
            ContentTextFontSize="12"/>
    </Grid>
</Window>

```

### TitleText :heavy_check_mark:
this is title text of posting.
### TitleTextFontSize :heavy_check_mark:
You can control title text font size.
### ContentText :heavy_check_mark:
this is content text of posting.
### ContentTextFontSize :heavy_check_mark:
You can control content text font size.

