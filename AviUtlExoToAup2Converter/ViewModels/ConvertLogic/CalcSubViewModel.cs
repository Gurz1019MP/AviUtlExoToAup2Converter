using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class CalcSubViewModel<T> : ConvertLogicViewModelBase
    {
        public CalcSubViewModel(CalcSub<T> model)
        {
            Model = model;
            Operand1 = ViewModelFactory.CreateViewModel(Model.Operand1) as ConvertLogicViewModelBase;
            Operand2 = ViewModelFactory.CreateViewModel(Model.Operand2) as ConvertLogicViewModelBase;

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.Operand1), (s, e) => Operand1 = ViewModelFactory.CreateViewModel(Model.Operand1) as ConvertLogicViewModelBase },
                { nameof(Model.Operand2), (s, e) => Operand2 = ViewModelFactory.CreateViewModel(Model.Operand2) as ConvertLogicViewModelBase },
            });
        }

        public CalcSub<T> Model { get; }

        private ConvertLogicViewModelBase? _Operand1;

        public ConvertLogicViewModelBase? Operand1
        {
            get
            { return _Operand1; }
            set
            { 
                if (_Operand1 == value)
                    return;
                _Operand1 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasOperand1));
                RaisePropertyChanged(nameof(NoOperand1));
            }
        }

        private ConvertLogicViewModelBase? _Operand2;

        public ConvertLogicViewModelBase? Operand2
        {
            get
            { return _Operand2; }
            set
            {
                if (_Operand2 == value)
                    return;
                _Operand2 = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasOperand2));
                RaisePropertyChanged(nameof(NoOperand2));
            }
        }

        public bool HasOperand1 => Operand1 != null;
        public bool NoOperand1 => Operand1 == null;
        public bool HasOperand2 => Operand2 != null;
        public bool NoOperand2 => Operand2 == null;


        private ListenerCommand<object>? _DropOperand1Command;

        public ListenerCommand<object>? DropOperand1Command
        {
            get
            {
                if (_DropOperand1Command == null)
                {
                    _DropOperand1Command = new ListenerCommand<object>(Model.DropOperand1);
                }
                return _DropOperand1Command;
            }
        }

        private ListenerCommand<object>? _DropOperand2Command;

        public ListenerCommand<object> DropOperand2Command
        {
            get
            {
                if (_DropOperand2Command == null)
                {
                    _DropOperand2Command = new ListenerCommand<object>(Model.DropOperand2);
                }
                return _DropOperand2Command;
            }
        }
    }
}
