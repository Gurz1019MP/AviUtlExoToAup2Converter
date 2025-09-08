using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;
using System.Numerics;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class CalcSubViewModel<T> : ViewModel, IValueViewModel<T> where T : INumber<T>
    {
        public CalcSubViewModel(CalcSub<T> model)
        {
            _model = model;
            _Operand1 = (IValueViewModel<T>)ViewModelFactory.CreateViewModel(_model.Operand1);
            _Operand2 = (IValueViewModel<T>)ViewModelFactory.CreateViewModel(_model.Operand2);
        }


        private IValueViewModel<T> _Operand1;

        public IValueViewModel<T> Operand1
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

        private IValueViewModel<T> _Operand2;

        public IValueViewModel<T> Operand2
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


        private readonly CalcSub<T> _model;
    }
}
