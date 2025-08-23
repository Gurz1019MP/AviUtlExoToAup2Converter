using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class SceneViewModel : ViewModel
    {
        #region .ctor

        public SceneViewModel(Scene model)
        {
            _model = model;
            ObjectItems = [.. _model.ObjectItems.CreateViewModels().Cast<ObjectItemViewModel>()];
        }

        #endregion

        #region Property

        public int Id => _model.Id;
        public string Name => _model.Name;
        public int VideoWidth => _model.VideoWidth;
        public int VideoHeight => _model.VideoHeight;
        public int VideoRate => _model.VideoRate;
        public int VideoScale => _model.VideoScale;
        public int AudioRate => _model.AudioRate;
        public int CursorFrame => _model.CursorFrame;
        public int DisplayFrame => _model.DisplayFrame;
        public int DisplayLayer => _model.DisplayLayer;
        public int DisplayZoom => _model.DisplayZoom;
        public int DisplayOrder => _model.DisplayOrder;
        public int? DisplayCamera => _model.DisplayCamera;
        public ObjectItemViewModel[] ObjectItems { get; }

        #endregion

        #region Field

        private readonly Scene _model;

        #endregion
    }
}
