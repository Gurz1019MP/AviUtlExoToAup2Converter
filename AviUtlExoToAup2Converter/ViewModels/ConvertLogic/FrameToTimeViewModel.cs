using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FrameToTimeViewModel : ConvertLogicViewModelBase
    {
        public FrameToTimeViewModel(FrameToTime model)
        {
            Model = model;
            Frame = ViewModelFactory.CreateViewModel(Model.Frame) as ConvertLogicViewModelBase;

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.Frame), (s, e) => Frame = ViewModelFactory.CreateViewModel(Model.Frame) as ConvertLogicViewModelBase }
            });
        }

        public FrameToTime Model { get; }

        private ConvertLogicViewModelBase? _Frame;

        public ConvertLogicViewModelBase? Frame
        {
            get
            { return _Frame; }
            set
            { 
                if (_Frame == value)
                    return;
                _Frame = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasFrame));
                RaisePropertyChanged(nameof(NoFrame));
            }
        }

        public bool HasFrame => _Frame != null;
        public bool NoFrame => _Frame == null;


        private ListenerCommand<object>? _DropFrameCommand;

        public ListenerCommand<object> DropFrameCommand
        {
            get
            {
                if (_DropFrameCommand == null)
                {
                    _DropFrameCommand = new ListenerCommand<object>(Model.DropFrame);
                }
                return _DropFrameCommand;
            }
        }
    }
}
