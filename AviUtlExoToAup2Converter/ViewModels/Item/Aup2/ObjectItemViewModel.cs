using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class ObjectItemViewModel : ViewModel
    {
        #region .ctor

        public ObjectItemViewModel(ObjectItem model)
        {
            _model = model;
            Attributes = _model.Attributes;
            Effects = [.. _model.Effects.CreateViewModels().Cast<GeneralEffectViewModel>()];
        }

        #endregion

        #region Property

        public IAttribute[] Attributes { get; }
        public GeneralEffectViewModel[] Effects { get; }

        #endregion

        #region Field

        private readonly ObjectItem _model;

        #endregion
    }
}
