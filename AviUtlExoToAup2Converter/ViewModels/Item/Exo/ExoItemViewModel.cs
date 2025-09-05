using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class ExoItemViewModel : ViewModel
    {
        #region .ctor

        public ExoItemViewModel(ExoItem model)
        {
            _model = model;
            Attributes = model.Attributes;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItemViewModel>()];
        }

        #endregion

        #region Property

        public IAttribute[] Attributes { get; }

        public ObjectItemViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly ExoItem _model;

        #endregion
    }
}
