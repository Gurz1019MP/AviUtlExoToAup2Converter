using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class StringValueViewModel : ViewModel, IValueViewModel<string>
    {
        public StringValueViewModel(StringValue model)
        {
            _model = model;
        }

        public string Value
        {
            get {  return _model.Value; }
            set { _model.Value = value; }
        }

        private readonly StringValue _model;
    }
}
