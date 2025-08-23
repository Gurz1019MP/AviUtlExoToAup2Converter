using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2.Effect
{
    public class DefaultPlayViewModel(DefaultPlay model) : ViewModel, IEffectViewModel
    {
        #region Property

        public string EffectName => _model.EffectName;
        public float Volume => _model.Volume;
        public float Pan => _model.Pan;

        #endregion

        #region Field

        private readonly DefaultPlay _model = model;

        #endregion
    }
}
