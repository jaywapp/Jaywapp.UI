# FilterView
This view is used for filtering objects. You can define filtering components by your purpose.
![image](https://user-images.githubusercontent.com/20869970/224468785-24f5f30f-5744-44b5-ad76-243f67bcaf2e.png)

## Usage
### Step1. Define Selectors.
You must define Selector classes for extract property from object. For defining selector, I should refer to [IFilterPropertySelector](https://github.com/jaywapp/Jaywapp.Infastructure/blob/develop/Filter/Interface/IFilterPropertySelector.cs) of [Jaywapp.Infrastructure](https://github.com/jaywapp/Jaywapp.Infastructure).

**[Example]**
```
public class NameSelector : IFilterPropertySelector
{
    public string Name => "차종 이름";
    public eFilteringType Type => eFilteringType.String;

    public object Select(object target)
    {
        if (!(target is Car car))
            return null;

        return car.Name;
    }

    public override string ToString() => Name;
}

public class YearSelector : IFilterPropertySelector
{
    public string Name => "연식";
    public eFilteringType Type => eFilteringType.Number;

    public object Select(object target)
    {
        if (!(target is Car car))
            return null;

        return car.Year;
    }

    public override string ToString() => Name;
}

public class TypeSelector : IFilterPropertySelector
{
    public string Name => "차종";
    public eFilteringType Type => eFilteringType.Enum;

    public object Select(object target)
    {
        if (!(target is Car car))
            return null;

        return car.Type;
    }

    public override string ToString() => Name;
}

public class PriceSelector : IFilterPropertySelector
{
    public string Name => "가격";
    public eFilteringType Type => eFilteringType.Number;

    public object Select(object target)
    {
        if (!(target is Car car))
            return null;

        return car.Price;
    }

    public override string ToString() => Name;
}
```

### Step2. View and ViewModel
Next step. You write view and view model(or behind code). 

**[View Example]**
```
<Window x:Class="JFilter.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:filtering="clr-namespace:Jaywapp.UI.Filtering;assembly=Jaywapp.UI"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <filtering:FilterView Grid.Row="0" Margin="20" DataContext="{Binding FilterItem}"/>
</Window>
```

In code about view, There is binding between DataContext and `FilterItem`. After view is writen, You must create `FilterItem` in view model or behind code.
When you create `FilterItem`, you have to create as `FilterGroupItem`.


**[Defining FilterItem Example]**
```
var selectors = new List<IFilterPropertySelector>()
{
    new NameSelector(),
    new YearSelector(),
    new TypeSelector(),
    new PriceSelector(),
};

FilterItem = new FilterGroupItem(selectors);
```

### Step3. Convert to Filter and Use Filter
After user set filtering options using `FilterView`, Filtering is working by filter converted from `FilterItem`.

```
// convert to filter
var filter = FilterItem.ToFilter();

// filtering
var targets = objs.Where(o => filter.IsFiltered(o)).ToList();
```

### Whole of ViewModel
```
using Jaywapp.Infrastructure.Filter.Interface;
using Jaywapp.UI.Interface;
using Jaywapp.UI.Model;
using JFilter.Selector;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;

namespace JFilter
{
    public enum eCarType
    {
        SUV,
        Truck,
        PassengerCar,
    }

    public class Car
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public eCarType Type { get; set; }

        public Car(string name, int year, int price, eCarType type)
        {
            Name = name;
            Year = year;
            Price = price;
            Type = type;
        }
    }

    public class MainWindowViewModel : ReactiveObject
    {
        public IFilterItem FilterItem { get; }
        public List<Car> Cars { get; }

        public MainWindowViewModel()
        {
            var selectors = new List<IFilterPropertySelector>()
        {
            new NameSelector(),
            new YearSelector(),
            new TypeSelector(),
            new PriceSelector(),
        };

            FilterItem = new FilterGroupItem(selectors);

            Cars = new List<Car>()
        {
            new Car("Sonata", 2000, 20000000, eCarType.PassengerCar),
            new Car("Spotage", 2010, 30000000, eCarType.SUV),
            new Car("Mighty", 2014, 50000000, eCarType.Truck),
        };
        }


        internal void Check()
        {
            var filter = FilterItem?.ToFilter();
            if (filter == null)
                return;

            var cars = Cars.Where(c => filter.IsFiltered(c)).ToList();
        }
    }
}

```
