using AviUtlExoToAup2Converter.Models.Item.Exo;
using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ObjectItem2ViewModel : ViewModel
    {
        #region .ctor
        public ObjectItem2ViewModel(ObjectItem2 model)
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

        private readonly ObjectItem2 _model;

        #endregion
    }
}
