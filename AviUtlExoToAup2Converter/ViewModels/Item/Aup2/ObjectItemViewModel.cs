using AviUtlExoToAup2Converter.Models.Item.Aup2;
using AviUtlExoToAup2Converter.ViewModels.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class ObjectItemViewModel : ViewModel
    {
        #region .ctor

        public ObjectItemViewModel(ObjectItem model)
        {
            _model = model;
            Effects = [.. _model.Effects.CreateViewModels().Cast<IEffectViewModel>()];
        }

        #endregion

        #region Property

        public int Layer => _model.Layer;
        public bool IsFocus => _model.IsFocus;
        public Span Frame => _model.Frame;
        public IEffectViewModel[] Effects { get; }

        #endregion

        #region Field

        private readonly ObjectItem _model;

        #endregion
    }
}
