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
                var item = new FilterItem(selectors);

                item.Logical = filter.Logical;
                item.Selector = filter.Selector;
                item.Operator = filter.Operator;
                item.Expect = filter.Expect;

                return item;
            }
            else if(target is FilterGroup filterGroup)
            {
                var item = new FilterGroupItem(selectors);

                foreach (var child in filterGroup.Children)
                {
                    var childItem = Convert(child, selectors);
                    childItem.Parent = item;

                    item.Children.Add(childItem);
                }

                return item;
            }

            return null;
        }
    }
}
