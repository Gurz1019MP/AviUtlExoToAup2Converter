using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2.Effect
{
    public class DefaultDrawViewModel(DefaultDraw model) : ViewModel, IEffectViewModel
    {
        #region Property

        public string EffectName => _model.EffectName;
        public Vector3 Position => _model.Position;
        public Vector3 Center => _model.Center;
        public Vector3 Rotate => _model.Rotate;
        public float Zoom => _model.Zoom;
        public float Aspect => _model.Aspect;
        public float Alpha => _model.Alpha;
        public BlendMode BlendMode => _model.BlendMode;

        #endregion

        #region Field

        private readonly DefaultDraw _model = model;

        #endregion
    }
}
