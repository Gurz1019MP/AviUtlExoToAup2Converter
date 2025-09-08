using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class StringMapperViewModel : ViewModel, IMapperViewModel
    {
        public StringMapperViewModel(StringMapper model)
        {
            _model = model;
            _From = (IValueViewModel<string>)ViewModelFactory.CreateViewModel(_model.From);
        }

        private IValueViewModel<string> _From;

        public IValueViewModel<string> From
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

        private readonly StringMapper _model;
    }
}
