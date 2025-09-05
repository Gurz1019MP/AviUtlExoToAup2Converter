using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class SceneViewModel : ViewModel
    {
        #region .ctor

        public SceneViewModel(Scene model)
        {
            _model = model;
            Attributes = _model.Attributes;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItemViewModel>()];
        }

        #endregion

        #region Property

        public IAttribute[] Attributes { get; }
        public ObjectItemViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly Scene _model;

        #endregion
    }
}
