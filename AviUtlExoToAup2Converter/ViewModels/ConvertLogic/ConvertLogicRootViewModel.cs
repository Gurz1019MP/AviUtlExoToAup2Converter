using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class ConvertLogicRootViewModel : ConvertLogicViewModelBase
    {
        public ConvertLogicRootViewModel(ConvertLogicRoot model)
        {
            Model = model;
            LogicItems = [.. Model.LogicItems.CreateViewModels().Cast<LogicItemViewModel>()];

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.LogicItems), (s,e) => LogicItems = [.. Model.LogicItems.CreateViewModels().Cast<LogicItemViewModel>()] }
            });
        }

        public ConvertLogicRoot Model { get; }

        private LogicItemViewModel[]? _LogicItems;

        public LogicItemViewModel[]? LogicItems
        {
            get
            { return _LogicItems; }
            set
            { 
                if (_LogicItems == value)
                    return;
                _LogicItems = value;
                RaisePropertyChanged();
            }
        }

        private ViewModelCommand? _AddLogicItemCommand;

        public ViewModelCommand? AddLogicItemCommand
        {
            get
            {
                if (_AddLogicItemCommand == null)
                {
                    _AddLogicItemCommand = new ViewModelCommand(Model.AddLogicItem);
                }
                return _AddLogicItemCommand;
            }
        }
    }
}
