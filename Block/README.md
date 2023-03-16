# BlockView
This control is for [IBlock](https://github.com/jaywapp/Jaywapp.Infastructure/blob/develop/Block/Interface/IBlock.cs) interface.

![캡처](https://user-images.githubusercontent.com/20869970/225476114-caf88b57-b9b8-48a2-8f07-43949ac305ab.PNG)

## Usage
### View
```
<block:BlockView Block="{Binding Block}" Margin="50" Width="300" BorderBrush="Black" BorderThickness="1"/>
```
### ViewModel
```
public class MainWindowViewModel : ReactiveObject
{
    public class Test : IBlock
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Test(string image, string name, string desc)
        {
            Image = image;
            Name = name;
            Description = desc;
        }
    }

    public IBlock Block { get; set; }

    public MainWindowViewModel()
    {
        Block = new Test(@"C:\Users\junyoung\Pictures\Region.png", "Test Block", 
            "This is Test Block. Test Block has description and Image. " +
            "This is Test Block. Test Block has description and Image." +
            "This is Test Block. Test Block has description and Image." +
            "This is Test Block. Test Block has description and Image.");
    }
}
```

# BlockFeedView
This is flexible grid control by using BlockView.

![230316](https://user-images.githubusercontent.com/20869970/225483229-971d0ae6-2492-4a57-a673-f463ab6a0d00.gif)

## Usage
```
<block:BlockFeedView Blocks="{Binding Blocks}"
    BlockWidth="300"
    BlockHeight="280"
    BlockBorderBrush="Black"
    BlockBorderThickness="1"
    BlockMargin="10"
    Margin="50"/>
```


