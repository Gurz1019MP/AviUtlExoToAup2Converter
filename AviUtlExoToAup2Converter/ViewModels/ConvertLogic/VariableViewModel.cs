using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class VariableViewModel : ViewModel
    {
        public VariableViewModel(Variable model)
        {
            _model = model;
            _Value = (IValueViewModel)ViewModelFactory.CreateViewModel(_model.Value);
        }

        public string Key
        {
            get {  return _model.Key; }
            set { _model.Key = value; }
        }


        private IValueViewModel _Value;

        public IValueViewModel Value
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


        private readonly Variable _model;
    }
}
