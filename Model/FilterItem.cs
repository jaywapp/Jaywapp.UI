using Jaywapp.Infrastructure;
using Jaywapp.Infrastructure.Collections;
using Jaywapp.Infrastructure.Filter.Attribute;
using Jaywapp.Infrastructure.Filter.Interface;
using Jaywapp.Infrastructure.Filter.Model;
using Jaywapp.UI.Interface;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;

namespace Jaywapp.UI.Model
{
    public class FilterItem : ReactiveObject, IFilterItem
    {
        #region Internal Field
        private eLogicalOperator _logical;
        private IFilterPropertySelector _selector;
        public eFilteringOperator _operator;
        public string _expect;

        private ObservableCollection<eFilteringOperator> _candidateOperators = new ObservableCollection<eFilteringOperator>();
        #endregion

        #region Properties
        public Type Type { get; }

        public eLogicalOperator Logical
        {
            get => _logical;
            set => this.RaiseAndSetIfChanged(ref _logical, value);
        }

        public IFilterPropertySelector Selector
        {
            get => _selector;
            set => this.RaiseAndSetIfChanged(ref _selector, value);
        }

        public eFilteringOperator Operator
        {
            get => _operator;
            set => this.RaiseAndSetIfChanged(ref _operator, value);
        }

        public string Expect
        {
            get => _expect;
            set => this.RaiseAndSetIfChanged(ref _expect, value);
        }

        public ObservableCollection<IFilterPropertySelector> CandidateSelectors { get; }
        public ObservableCollection<eFilteringOperator> CandidateOperators
        {
            get => _candidateOperators;
            set => this.RaiseAndSetIfChanged(ref _candidateOperators, value);
        }
        #endregion

        #region Constructor
        public FilterItem(IEnumerable<IFilterPropertySelector> candidates)
        {
            Type = GetType();

            CandidateSelectors = candidates.ToObservableCollection();

            this.WhenAnyValue(x => x.Selector)
                .Where(s=> s != null)
                .Select(s =>
                {
                    return GetItemsSouce(typeof(eFilteringOperator), s.Type)
                        .ToObservableCollection();
                })
                .BindTo(this, x => x.CandidateOperators);
        }
        #endregion

        #region Functions
        public IFilter ToFilter()
        {
            return new Filter()
            {
                Logical = Logical,
                Selector = Selector,
                Operator = Operator,
                Expect = Expect,
            };
        }

        public static List<eFilteringOperator> GetItemsSouce(Type type, eFilterableTargetProperty targetType)
        {
            var targets = new List<eFilteringOperator>();

            if (type == typeof(eFilteringOperator))
            {
                foreach (eFilteringOperator op in typeof(eFilteringOperator).GetEnumValues())
                {
                    if(!op.IsTargetField(targetType))
                        continue;

                    targets.Add(op);
                }
            }

            return targets;
        }
        #endregion
    }
}
