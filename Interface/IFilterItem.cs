using Jaywapp.Infrastructure.Filter.Interface;
using Jaywapp.Infrastructure.Filter.Model;
using Jaywapp.UI.Model;
using System;
using System.Collections.Generic;

namespace Jaywapp.UI.Interface
{
    public interface IFilterItem
    {
        IFilterItem Parent { get; set; }
        Type Type { get; }
        IFilter ToFilter();
        void RemoveSelf();
    }

    public static class FilterItemExt
    {
        public static IFilterItem Convert(this IFilter target, IEnumerable<IFilterPropertySelector> selectors)
        {
            if(target is Filter filter)
            {
                return new FilterItem(selectors);
            }
            else if(target is FilterGroup filterGroup)
            {
                var item = new FilterGroupItem(selectors);

                foreach (var child in filterGroup.Children)
                    item.Children.Add(Convert(child, selectors));

                return item;
            }

            return null;
        }
    }
}
