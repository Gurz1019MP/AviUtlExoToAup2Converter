using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FloatMapperViewModel : ViewModel, IMapperViewModel
    {
        public FloatMapperViewModel(FloatMapper model)
        {
            _model = model;
            _From = (IValueViewModel<float>)ViewModelFactory.CreateViewModel(_model.From);
        }


        private IValueViewModel<float> _From;

        public IValueViewModel<float> From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }

        public string To
        {
            get { return _model.To; }
            set { _model.To = value; }
        }

        public string Format
        {
            get { return _model.Format; }
            set { _model.Format = value; }
        }

        private readonly FloatMapper _model;
    }
}
