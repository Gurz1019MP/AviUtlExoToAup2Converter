using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class IntMapperViewModel : ViewModel, IMapperViewModel
    {
        public IntMapperViewModel(IntMapper model)
        {
            _model = model;
            _From = (IValueViewModel<int>)ViewModelFactory.CreateViewModel(_model.From);
        }

        private IValueViewModel<int> _From;

        public IValueViewModel<int> From
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

        private readonly IntMapper _model;
    }
}
