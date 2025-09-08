using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class BlendModeValueViewModel : ViewModel, IValueViewModel<string>
    {
        public BlendModeValueViewModel(BlendModeValue model)
        {
            _model = model;
            _Value = (IValueViewModel<int>)ViewModelFactory.CreateViewModel(_model.Value);
        }

        private IValueViewModel<int> _Value;

        public IValueViewModel<int> Value
        {
            get
            { return _Value; }
            set
            { 
                if (_Value == value)
                    return;
                _Value = value;
                RaisePropertyChanged();
            }
        }

        private readonly BlendModeValue _model;
    }
}
