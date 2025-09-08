using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class BoolConditionEqualViewModel : ViewModel, IValueViewModel<bool>
    {
        public BoolConditionEqualViewModel(BoolConditionEqual model)
        {
            _model = model;
            _Operand1 = (IValueViewModel<bool>)ViewModelFactory.CreateViewModel(_model.Operand1);
            _Operand2 = (IValueViewModel<bool>)ViewModelFactory.CreateViewModel(_model.Operand2);
        }


        private IValueViewModel<bool> _Operand1;

        public IValueViewModel<bool> Operand1
        {
            get
            { return _Operand1; }
            set
            { 
                if (_Operand1 == value)
                    return;
                _Operand1 = value;
                RaisePropertyChanged();
            }
        }

        private IValueViewModel<bool> _Operand2;

        public IValueViewModel<bool> Operand2
        {
            get
            { return _Operand2; }
            set
            {
                if (_Operand2 == value)
                    return;
                _Operand2 = value;
                RaisePropertyChanged();
            }
        }

        private readonly BoolConditionEqual _model;
    }
}
