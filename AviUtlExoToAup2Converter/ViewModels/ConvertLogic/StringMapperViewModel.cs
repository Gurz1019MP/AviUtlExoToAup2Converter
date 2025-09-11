using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class StringMapperViewModel : ConvertLogicViewModelBase
    {
        public StringMapperViewModel(StringMapper model)
        {
            Model = model;
            From = ViewModelFactory.CreateViewModel(Model.From) as ConvertLogicViewModelBase;

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.From), (s, e) => From = ViewModelFactory.CreateViewModel(Model.From) as ConvertLogicViewModelBase }
            });
        }

        public StringMapper Model { get; }

        private ConvertLogicViewModelBase? _From;

        public ConvertLogicViewModelBase? From
        {
            get
            { return _From; }
            set
            {
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasFrom));
                RaisePropertyChanged(nameof(NoFrom));
            }
        }

        public bool HasFrom => From != null;
        public bool NoFrom => From == null;

        private ListenerCommand<object>? _DropFromCommand;

        public ListenerCommand<object> DropFromCommand
        {
            get
            {
                if (_DropFromCommand == null)
                {
                    _DropFromCommand = new ListenerCommand<object>(Model.DropFrom);
                }
                return _DropFromCommand;
            }
        }
    }
}
