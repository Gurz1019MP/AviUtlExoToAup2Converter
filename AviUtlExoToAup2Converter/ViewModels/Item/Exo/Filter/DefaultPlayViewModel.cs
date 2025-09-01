using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public class DefaultPlayViewModel(DefaultPlay model) : AbstractFilterItemViewModel(model)
    {
        #region Property

        public override string Name => _model.Name;
        public float Volume => _model.Volume;
        public float Pan => _model.Pan;

        #endregion

        #region Field

        private readonly DefaultPlay _model = model;

        #endregion
    }
}
