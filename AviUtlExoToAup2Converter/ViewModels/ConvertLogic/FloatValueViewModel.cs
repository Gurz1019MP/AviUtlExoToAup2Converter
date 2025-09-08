using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FloatValueViewModel : ViewModel, IValueViewModel<float>
    {
        public FloatValueViewModel(FloatValue model)
        {
            _model = model;
        }

        public float Value
        {
            get {  return _model.Value; }
            set { _model.Value = value; }
        }

        private readonly FloatValue _model;
    }
}
