using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public class DefaultDrawViewModel(DefaultDraw model) : AbstractFilterItemViewModel(model)
    {
        #region Property

        public override string Name => _model.Name;
        public float X => _model.X;
        public float Y => _model.Y;
        public float Z => _model.Z;
        public float Zoom => _model.Zoom;
        public float Alpha => _model.Alpha;
        public float Rotate => _model.Rotate;
        public byte Blend => _model.Blend;

        #endregion

        #region Field

        private readonly DefaultDraw _model = model;

        #endregion
    }
}
