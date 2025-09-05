using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ObjectItemViewModel : ViewModel
    {
        #region .ctor
        public ObjectItemViewModel(ObjectItem model)
        {
            _model = model;
            Attributes = model.Attributes;
            Filters = [.. _model.Filters.CreateViewModels().Cast<GeneralFilterViewModel>()];
        }
        #endregion

        #region Property

        public IAttribute[] Attributes { get; }

        public GeneralFilterViewModel[] Filters { get; }
        #endregion

        #region Field

        private readonly ObjectItem _model;

        #endregion
    }
}
