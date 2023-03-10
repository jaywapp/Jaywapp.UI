using Jaywapp.Infrastructure;
using Jaywapp.Infrastructure.Filter.Interface;
using Jaywapp.Infrastructure.Filter.Model;
using Jaywapp.UI.Interface;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Jaywapp.UI.Model
{
    public class FilterGroupItem : ReactiveObject, IFilterItem
    {
        #region Internal Field
        private IReadOnlyList<IFilterPropertySelector> _selectorCandidates;
        private eLogicalOperator _logical;
        private ObservableCollection<IFilterItem> _children = new ObservableCollection<IFilterItem>();
        #endregion

        #region Properties
        public Type Type { get; }

        public eLogicalOperator Logical
        {
            get => _logical;
            set => this.RaiseAndSetIfChanged(ref _logical, value);
        }

        public ObservableCollection<IFilterItem> Children
        {
            get => _children;
            set => this.RaiseAndSetIfChanged(ref _children, value);
        }
        #endregion

        #region Constructor
        public FilterGroupItem(IEnumerable<IFilterPropertySelector> candidates)
        {
            Type = GetType();
            _selectorCandidates = candidates.ToList();
        }
        #endregion

        #region Functions
        public IFilter ToFilter()
        {
            return new FilterGroup()
            {
                Logical = Logical,
                Children = Children.Select(c => c.ToFilter()).OfType<IFilter>().ToList(),
            };
        }
        #endregion

        #region Functions
        public void AddFilter()
        {
            Children.Add(new FilterItem(_selectorCandidates));
            this.RaisePropertyChanged(nameof(Children));
        }

        public void AddFilterGroup()
        {
            Children.Add(new FilterGroupItem(_selectorCandidates));
            this.RaisePropertyChanged(nameof(Children));
        }
        #endregion
    }
}
