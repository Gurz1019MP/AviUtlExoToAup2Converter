using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class PlayPositionMapperViewModel : ConvertLogicViewModelBase
    {
        public PlayPositionMapperViewModel(PlayPositionMapper model)
        {
            Model = model;
            Start = ViewModelFactory.CreateViewModel(Model.Start) as ConvertLogicViewModelBase;
            End = ViewModelFactory.CreateViewModel(Model.End) as ConvertLogicViewModelBase;
            Range = ViewModelFactory.CreateViewModel(Model.Range) as ConvertLogicViewModelBase;

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.Start), (s, e) => Start = ViewModelFactory.CreateViewModel(Model.Start) as ConvertLogicViewModelBase },
                { nameof(Model.End), (s, e) => End = ViewModelFactory.CreateViewModel(Model.End) as ConvertLogicViewModelBase },
                { nameof(Model.Range), (s, e) => Range = ViewModelFactory.CreateViewModel(Model.Range) as ConvertLogicViewModelBase },
            });
        }

        public PlayPositionMapper Model { get; set; }

        private ConvertLogicViewModelBase? _Start;

        public ConvertLogicViewModelBase? Start
        {
            get
            { return _Start; }
            set
            { 
                if (_Start == value)
                    return;
                _Start = value;
                RaisePropertyChanged();
            }
        }

        private ConvertLogicViewModelBase? _End;

        public ConvertLogicViewModelBase? End
        {
            get
            { return _End; }
            set
            {
                if (_End == value)
                    return;
                _End = value;
                RaisePropertyChanged();
            }
        }

        private ConvertLogicViewModelBase? _Range;

        public ConvertLogicViewModelBase? Range
        {
            get
            { return _Range; }
            set
            {
                if (_Range == value)
                    return;
                _Range = value;
                RaisePropertyChanged();
            }
        }

        public bool HasStart => Start != null;
        public bool NoStart => Start == null;
        public bool HasEnd => End != null;
        public bool NoEnd => End == null;
        public bool HasRange => Range != null;
        public bool NoRange => Range == null;

        private ListenerCommand<object>? _DropStartCommand;

        public ListenerCommand<object> DropStartCommand
        {
            get
            {
                if (_DropStartCommand == null)
                {
                    _DropStartCommand = new ListenerCommand<object>(Model.DropStart);
                }
                return _DropStartCommand;
            }
        }

        private ListenerCommand<object>? _DropEndCommand;

        public ListenerCommand<object> DropEndCommand
        {
            get
            {
                if (_DropEndCommand == null)
                {
                    _DropEndCommand = new ListenerCommand<object>(Model.DropEnd);
                }
                return _DropEndCommand;
            }
        }

        private ListenerCommand<object>? _DropRangeCommand;

        public ListenerCommand<object> DropRangeCommand
        {
            get
            {
                if (_DropRangeCommand == null)
                {
                    _DropRangeCommand = new ListenerCommand<object>(Model.DropRange);
                }
                return _DropRangeCommand;
            }
        }
    }
}
