using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.ViewModels.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class ObjectItem2ViewModel : ViewModel
    {
        #region .ctor

        public ObjectItem2ViewModel(ObjectItem2 model)
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

        private readonly ObjectItem2 _model;

        #endregion
    }
}
