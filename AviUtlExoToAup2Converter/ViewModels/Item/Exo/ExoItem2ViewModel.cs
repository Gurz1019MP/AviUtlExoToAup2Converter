using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ExoItem2ViewModel : ViewModel
    {
        #region .ctor

        public ExoItem2ViewModel(ExoItem2 model)
        {
            _model = model;
            Attributes = model.Attributes;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItem2ViewModel>()];
        }

        #endregion

        #region Property

        public IAttribute[] Attributes { get; }

        public ObjectItem2ViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly ExoItem2 _model;

        #endregion
    }
}
