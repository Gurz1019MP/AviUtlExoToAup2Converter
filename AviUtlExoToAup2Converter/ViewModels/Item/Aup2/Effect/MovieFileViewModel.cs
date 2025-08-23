using AviUtlExoToAup2Converter.Models.Item.Aup2.Effect;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2.Effect
{
    public class MovieFileViewModel(MovieFile model) : ViewModel, IEffectViewModel
    {
        #region Property

        public string EffectName => _model.EffectName;
        public SpanF PlayPosition => _model.PlayPosition;
        public Span PlayRange => _model.PlayRange;
        public float PlaySpeed => _model.PlaySpeed;
        public string FilePath => _model.FilePath;
        public int Track => _model.Track;
        public bool IsLoop => _model.IsLoop;
        public bool HaveAudio => _model.HaveAudio;

        #endregion

        #region Field

        private readonly MovieFile _model = model;

        #endregion
    }
}
