using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class Scene2ViewModel : ViewModel
    {
        #region .ctor

        public Scene2ViewModel(Scene2 model)
        {
            _model = model;
            Attributes = _model.Attributes;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItem2ViewModel>()];
        }

        #endregion

        #region Property

        public IAttribute[] Attributes { get; }
        public ObjectItem2ViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly Scene2 _model;

        #endregion
    }
}
