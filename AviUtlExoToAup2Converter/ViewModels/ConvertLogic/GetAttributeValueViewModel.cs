using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class GetAttributeValueViewModel<T> : ViewModel, IValueViewModel<T>
    {
        public GetAttributeValueViewModel(GetAttributeValue<T> model)
        {
            _model = model;
        }

        public string Reference
        {
            get {  return _model.Reference; }
            set { _model.Reference = value; }
        }

        public string From
        {
            get { return _model.From; }
            set { _model.From = value; }
        }

        private readonly GetAttributeValue<T> _model;
    }
}
