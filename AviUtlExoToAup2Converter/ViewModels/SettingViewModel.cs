using AviUtlExoToAup2Converter.Models;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels
{
    public class SettingViewModel : ViewModel
    {
        #region .ctor

        public SettingViewModel(Setting model)
        {
            _model = model;
            _listener = new PropertyChangedWeakEventListener(_model)
            {
                { nameof(_model.Logic), (s, e) => Logic = _model.Logic == null ? null : (ConvertLogicRootViewModel)ViewModelFactory.CreateViewModel(_model.Logic) },
            };
            CompositeDisposable.Add(_listener);
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
            }
        }

        #endregion

        private ViewModelCommand? _LoadLogicCommand;

        public ViewModelCommand? LoadLogicCommand
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

        private readonly Setting _model;
        private PropertyChangedWeakEventListener _listener;
    }
}
