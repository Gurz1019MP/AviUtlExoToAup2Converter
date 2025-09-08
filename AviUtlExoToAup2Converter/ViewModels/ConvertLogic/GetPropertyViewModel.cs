using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class GetPropertyViewModel<T> : ViewModel, IValueViewModel<T>
    {
        public GetPropertyViewModel(GetProperty<T> model)
        {
            _model = model;
        }

        public string Reference
        {
            get { return _model.Reference; }
            set { _model.Reference = value; }
        }

        public string Property
        {
            get { return _model.Property; }
            set { _model.Property = value; }
        }

        private readonly GetProperty<T> _model;
    }
}
