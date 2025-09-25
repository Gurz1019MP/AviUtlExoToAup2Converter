using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class LogicItemViewModel : ViewModel
    {
        public LogicItemViewModel(LogicItem model)
        {
            Model = model;
            LocalVars = [.. ViewModelFactory.CreateViewModels(Model.LocalVars).Cast<VariableViewModel>()];
            Condition = ViewModelFactory.CreateViewModel(Model.Condition) as ConvertLogicViewModelBase;
            Mappers = [.. ViewModelFactory.CreateViewModels(Model.Mappers).Cast<ConvertLogicViewModelBase>()];
            RefreshVariableItems();

            CompositeDisposable.Add(new PropertyChangedWeakEventListener(Model)
            {
                { nameof(Model.LocalVars), (s, e) => {
                    LocalVars = [.. ViewModelFactory.CreateViewModels(Model.LocalVars).Cast<VariableViewModel>()];
                    RefreshVariableItems();
                }},
                { nameof(Model.Condition), (s, e) => Condition = ViewModelFactory.CreateViewModel(Model.Condition) as ConvertLogicViewModelBase },
                { nameof(Model.Mappers), (s, e) => Mappers = [.. ViewModelFactory.CreateViewModels(Model.Mappers).Cast<ConvertLogicViewModelBase>()] },
            });
        }

        public LogicItem Model { get; }

        public string EffectName
        {
            get { return Model.EffectName; }
            set { Model.EffectName = value; }
        }

        private VariableViewModel[] _LocalVars = [];

        public VariableViewModel[] LocalVars
        {
            get
            { return _LocalVars; }
            set
            {
                if (_LocalVars == value)
                    return;
                _LocalVars = value;
                RaisePropertyChanged();
            }
        }


        private ConvertLogicViewModelBase? _Condition;

        public ConvertLogicViewModelBase? Condition
        {
            get
            { return _Condition; }
            set
            {
                if (_Condition == value)
                    return;
                _Condition = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasCondition));
                RaisePropertyChanged(nameof(NoCondition));
            }
        }

        public bool HasCondition => Condition != null;
        public bool NoCondition => Condition == null;

        private ConvertLogicViewModelBase[]? _Mappers;

        public ConvertLogicViewModelBase[]? Mappers
        {
            get
            { return _Mappers; }
            set
            {
                if (_Mappers == value)
                    return;
                _Mappers = value;
                RaisePropertyChanged();
            }
        }


        private Dictionary<string, string> _VariableItems = _constVariableItems;

        public Dictionary<string, string> VariableItems
        {
            get
            { return _VariableItems; }
            set
            {
                if (_VariableItems == value)
                    return;
                _VariableItems = value;
                RaisePropertyChanged();
            }
        }

        private ListenerCommand<object>? _DropConditionCommand;

        public ListenerCommand<object> DropConditionCommand
        {
            get
            {
                if (_DropConditionCommand == null)
                {
                    _DropConditionCommand = new ListenerCommand<object>(Model.DropCondition);
                }
                return _DropConditionCommand;
            }
        }

        private ViewModelCommand? _AddVariableCommand;

        public ViewModelCommand AddVariableCommand
        {
            get
            {
                if (_AddVariableCommand == null)
                {
                    _AddVariableCommand = new ViewModelCommand(Model.AddVariable);
                }
                return _AddVariableCommand;
            }
        }

        private ListenerCommand<object>? _DropMapperCommand;

        public ListenerCommand<object> DropMapperCommand
        {
            get
            {
                if (_DropMapperCommand == null)
                {
                    _DropMapperCommand = new ListenerCommand<object>(Model.DropMapper);
                }
                return _DropMapperCommand;
            }
        }

        private void RefreshVariableItems()
        {
            VariableItems = _constVariableItems.Concat(
                LocalVars.Where(v => v.ToDictionary != null)
                         .SelectMany(v => v.ToDictionary))
                         .ToDictionary();
            foreach (VariableViewModel variableViewModel in LocalVars)
            {
                CompositeDisposable.Add(new PropertyChangedWeakEventListener(variableViewModel)
                {
                    { nameof(variableViewModel.ToDictionary), (s, e) => {
                        VariableItems = _constVariableItems.Concat(
                            LocalVars.Where(v => v.ToDictionary != null)
                                     .SelectMany(v => v.ToDictionary))
                                     .ToDictionary();
                    }}
                });
            }
        }

        private static readonly Dictionary<string, string> _constVariableItems = new()
        {
            { "Exoファイル共通レベル", "baseItem" },
            { "変換対象のフィルタを内包するオブジェクト", "baseObjectItem" },
            { "変換対象のフィルタ", "filter" },
        };
    }
}
