using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public abstract class AbstractFilterItemViewModel(AbstractFilterItem model) : ViewModel
    {
        #region Property

        public abstract string Name { get; }

        #endregion

        #region Field

        private readonly AbstractFilterItem _model = model;
        
        #endregion
    }
}
