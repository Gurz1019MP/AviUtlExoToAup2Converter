using AviUtlExoToAup2Converter.Models;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace AviUtlExoToAup2Converter.ViewModels
{
    public class SettingViewModel : ViewModel
    {
        #region .ctor

        public SettingViewModel(Setting model)
        {
            _model = model;
            CompositeDisposable.Add(new PropertyChangedWeakEventListener(_model)
            {
                { nameof(_model.Logic), (s, e) => Logic = ViewModelFactory.CreateViewModel(_model.Logic) as ConvertLogicRootViewModel },
            });
        }

        #endregion

        #region Property

        private string _LogicPath = string.Empty;

        public string LogicPath
        {
            get
            { return _LogicPath; }
            set
            { 
                if (_LogicPath == value)
                    return;
                _LogicPath = value;
                RaisePropertyChanged();
                LoadLogicCommand?.RaiseCanExecuteChanged();
                SaveLogicCommand?.RaiseCanExecuteChanged();
            }
        }

        private ConvertLogicRootViewModel? _Logic;

        public ConvertLogicRootViewModel? Logic
        {
            get
            { return _Logic; }
            set
            { 
                if (_Logic == value)
                    return;
                _Logic = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(HasLogic));
                RaisePropertyChanged(nameof(NoLogic));
                CreateNewLogicCommand?.RaiseCanExecuteChanged();
                SaveLogicCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool HasLogic => Logic != null;
        public bool NoLogic => Logic == null;

        private Dictionary<string, object>? _EmptyLogicObjects;
        public Dictionary<string, object> EmptyLogicObjects
        {
            get
            {
                if (_EmptyLogicObjects == null)
                {
                    _EmptyLogicObjects = new()
                    {
                        { "ConditionEqualViewModel`1", new ConditionEqualViewModel<Empty>(new Models.ConvertLogic.ConditionEqual<Empty>()) },
                        { "BoolConditionEqualViewModel", new BoolConditionEqualViewModel(new Models.ConvertLogic.BoolConditionEqual()) },
                        { "IntMapperViewModel", new IntMapperViewModel(new Models.ConvertLogic.IntMapper()) },
                        { "FloatMapperViewModel", new FloatMapperViewModel(new Models.ConvertLogic.FloatMapper()) },
                        { "StringMapperViewModel", new StringMapperViewModel(new Models.ConvertLogic.StringMapper()) },
                        { "PlayPositionMapperViewModel", new PlayPositionMapperViewModel(new Models.ConvertLogic.PlayPositionMapper()) },
                        { "IntValueViewModel", new IntValueViewModel(new Models.ConvertLogic.IntValue()) },
                        { "FloatValueViewModel", new FloatValueViewModel(new Models.ConvertLogic.FloatValue()) },
                        { "StringValueViewModel", new StringValueViewModel(new Models.ConvertLogic.StringValue()) },
                        { "GetAttributeValueViewModel`1", new GetAttributeValueViewModel<Empty>(new Models.ConvertLogic.GetAttributeValue<Empty>()) },
                        { "GetPropertyViewModel`1", new GetPropertyViewModel<Empty>(new Models.ConvertLogic.GetProperty<Empty>()) },
                        { "FindFirstFilterByNameViewModel", new FindFirstFilterByNameViewModel(new Models.ConvertLogic.FindFirstFilterByName()) },
                        { "BlendModeValueViewModel", new BlendModeValueViewModel(new Models.ConvertLogic.BlendModeValue()) },
                        { "FrameToTimeViewModel", new FrameToTimeViewModel(new Models.ConvertLogic.FrameToTime()) },
                        { "CalcSumViewModel`1", new CalcSumViewModel<Empty>(new Models.ConvertLogic.CalcSum<Empty>()) },
                        { "CalcSubViewModel`1", new CalcSubViewModel<Empty>(new Models.ConvertLogic.CalcSub<Empty>()) },
                    };
                }
                return _EmptyLogicObjects;
            }
        }

        #endregion

        private ViewModelCommand? _LoadLogicCommand;

        public ViewModelCommand LoadLogicCommand
        {
            get
            {
                if (_LoadLogicCommand == null)
                {
                    _LoadLogicCommand = new ViewModelCommand(LoadLogic, CanLoadLogic);
                }
                return _LoadLogicCommand;
            }
        }

        public bool CanLoadLogic()
        {
            return System.IO.Path.Exists(_LogicPath);
        }

        public void LoadLogic()
        {
            _model.LoadLogic(LogicPath);
        }

        private ViewModelCommand _SaveLogicCommand;

        public ViewModelCommand SaveLogicCommand
        {
            get
            {
                if (_SaveLogicCommand == null)
                {
                    _SaveLogicCommand = new ViewModelCommand(SaveLogic, CanSaveLogic);
                }
                return _SaveLogicCommand;
            }
        }

        public bool CanSaveLogic()
        {
            return !string.IsNullOrEmpty(LogicPath) && Logic != null;
        }

        public void SaveLogic()
        {
            _model.SaveLogic(LogicPath);
        }

        private ViewModelCommand? _CreateNewLogicCommand;

        public ViewModelCommand CreateNewLogicCommand
        {
            get
            {
                if (_CreateNewLogicCommand == null)
                {
                    _CreateNewLogicCommand = new ViewModelCommand(CreateNewLogic, CanCreateNewLogic);
                }
                return _CreateNewLogicCommand;
            }
        }

        public bool CanCreateNewLogic()
        {
            return Logic == null;
        }

        public void CreateNewLogic()
        {
            _model.CreateNewLogic();
        }


        private ListenerCommand<object>? _DropRemoveCommand;

        public ListenerCommand<object> DropRemoveCommand
        {
            get
            {
                if (_DropRemoveCommand == null)
                {
                    _DropRemoveCommand = new ListenerCommand<object>(_model.DropRemove);
                }
                return _DropRemoveCommand;
            }
        }

        private readonly Setting _model;
    }
}
