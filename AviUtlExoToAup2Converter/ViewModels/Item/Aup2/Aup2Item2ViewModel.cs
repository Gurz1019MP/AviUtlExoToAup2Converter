using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class Aup2Item2ViewModel : ViewModel
    {
        #region .ctor

        public Aup2Item2ViewModel(Aup2Item2 model)
        {
            _model = model;
            Scenes = [.. _model.Scenes.CreateViewModels().Cast<Scene2ViewModel>()];
        }

        #endregion

        #region Property

        public Scene2ViewModel[] Scenes { get; }

        #endregion

        #region Field

        private readonly Aup2Item2 _model;

        #endregion
    }
}
