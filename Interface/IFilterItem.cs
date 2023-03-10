using Jaywapp.Infrastructure.Filter.Interface;
using System;

namespace Jaywapp.UI.Interface
{
    public interface IFilterItem
    {
        Type Type { get; }
        IFilter ToFilter();
    }
}
