using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class VariableViewModel : ConvertLogicViewModelBase
    {
        public VariableViewModel(Variable model)
        {
            Model = model;
            Value = ViewModelFactory.CreateViewModel(Model.Value) as ConvertLogicViewModelBase;

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.Value), (s, e) => Value = ViewModelFactory.CreateViewModel(Model.Value) as ConvertLogicViewModelBase },
                { nameof(Model.Key), (s, e) => {
                    ToDictionary = Model.Key == null ? [] : new Dictionary<string, string>(){ { Model.Key, Model.Key } };
                }}
            });
        }

        public Variable Model { get; }

        private ConvertLogicViewModelBase? _Value;

        public ConvertLogicViewModelBase? Value
        {
            get
            { return _Value; }
            set
            { 
                if (_Value == value)
                    return;
                _Value = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasValue));
                RaisePropertyChanged(nameof(NoValue));
            }
        }

        public bool HasValue => Value != null;
        public bool NoValue => Value == null;


        private Dictionary<string, string> _ToDictionary = [];

        public Dictionary<string, string> ToDictionary
        {
            get
            { return _ToDictionary; }
            set
            { 
                if (_ToDictionary == value)
                    return;
                _ToDictionary = value;
                RaisePropertyChanged();
            }
        }


        private ListenerCommand<object>? _DropValueCommand;

        public ListenerCommand<object> DropValueCommand
        {
            get
            {
                if (_DropValueCommand == null)
                {
                    _DropValueCommand = new ListenerCommand<object>(Model.DropValue);
                }
                return _DropValueCommand;
            }
        }
    }
}
