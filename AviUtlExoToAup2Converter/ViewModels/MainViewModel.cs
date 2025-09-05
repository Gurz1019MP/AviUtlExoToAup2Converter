using AviUtlExoToAup2Converter.Models;
using AviUtlExoToAup2Converter.ViewModels.Item.Aup2;
using AviUtlExoToAup2Converter.ViewModels.Item.Exo;
using Livet;
using Livet.Commands;
using Livet.EventListeners.WeakEvents;

namespace AviUtlExoToAup2Converter.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region .ctor

        public MainViewModel()
        {
            _model = new MainModel();
            _listener = new PropertyChangedWeakEventListener(_model)
            {
                { nameof(_model.ExoItem), (s, e) => ExoItem = _model.ExoItem == null ? null : (ExoItemViewModel)ViewModelFactory.CreateViewModel(_model.ExoItem) },
                { nameof(_model.ExoItem2), (s, e) => ExoItem2 = _model.ExoItem2 == null ? null : (ExoItem2ViewModel)ViewModelFactory.CreateViewModel(_model.ExoItem2) },
                { nameof(_model.Aup2Item), (s, e) => Aup2Item = _model.Aup2Item == null ? null : (Aup2ItemViewModel)ViewModelFactory.CreateViewModel(_model.Aup2Item) },
                { nameof(_model.Aup2Item2), (s, e) => Aup2Item2 = _model.Aup2Item2 == null ? null : (Aup2Item2ViewModel)ViewModelFactory.CreateViewModel(_model.Aup2Item2) },
            };
            CompositeDisposable.Add(_listener);
        }

        #endregion

        #region Property

        private string _ExoPath = string.Empty;

        public string ExoPath
        {
            get
            { return _ExoPath; }
            set
            { 
                if (_ExoPath == value)
                    return;
                _ExoPath = value;
                RaisePropertyChanged();
                ImportCommand?.RaiseCanExecuteChanged();
            }
        }

        private string _Aup2Path = string.Empty;

        public string Aup2Path
        {
            get
            { return _Aup2Path; }
            set
            { 
                if (_Aup2Path == value)
                    return;
                _Aup2Path = value;
                RaisePropertyChanged();
                ExportCommand?.RaiseCanExecuteChanged();
            }
        }

        private ExoItemViewModel? _ExoItem;

        public ExoItemViewModel? ExoItem
        {
            get
            { return _ExoItem; }
            set
            { 
                if (_ExoItem == value)
                    return;
                _ExoItem = value;
                RaisePropertyChanged();
                ConvertCommand?.RaiseCanExecuteChanged();
            }
        }

        private ExoItem2ViewModel? _ExoItem2;

        public ExoItem2ViewModel? ExoItem2
        {
            get
            { return _ExoItem2; }
            set
            {
                if (_ExoItem2 == value)
                    return;
                _ExoItem2 = value;
                RaisePropertyChanged();
                ConvertCommand?.RaiseCanExecuteChanged();
            }
        }


        private Aup2ItemViewModel? _Aup2Item;

        public Aup2ItemViewModel? Aup2Item
        {
            get
            { return _Aup2Item; }
            set
            { 
                if (_Aup2Item == value)
                    return;
                _Aup2Item = value;
                RaisePropertyChanged();
                ExportCommand?.RaiseCanExecuteChanged();
            }
        }

        private Aup2Item2ViewModel? _Aup2Item2;

        public Aup2Item2ViewModel? Aup2Item2
        {
            get
            { return _Aup2Item2; }
            set
            {
                if (_Aup2Item2 == value)
                    return;
                _Aup2Item2 = value;
                RaisePropertyChanged();
                ExportCommand?.RaiseCanExecuteChanged();
            }
        }

        #endregion


        private ViewModelCommand? _ImportCommand;

        public ViewModelCommand? ImportCommand
        {
            get
            {
                if (_ImportCommand == null)
                {
                    _ImportCommand = new ViewModelCommand(Import, CanImport);
                }
                return _ImportCommand;
            }
        }

        public bool CanImport()
        {
            return System.IO.Path.Exists(_ExoPath);
        }

        public void Import()
        {
            _model.Import(ExoPath);
            Aup2Path = System.IO.Path.ChangeExtension(ExoPath, ".aup2");
        }


        private ViewModelCommand? _ConvertCommand;

        public ViewModelCommand? ConvertCommand
        {
            get
            {
                if (_ConvertCommand == null)
                {
                    _ConvertCommand = new ViewModelCommand(Convert, CanConvert);
                }
                return _ConvertCommand;
            }
        }

        public bool CanConvert()
        {
            return ExoItem2 != null;
            //return ExoItem != null;
        }

        public void Convert()
        {
            _model.Convert();
        }


        private ViewModelCommand? _ExportCommand;

        public ViewModelCommand? ExportCommand
        {
            get
            {
                if (_ExportCommand == null)
                {
                    _ExportCommand = new ViewModelCommand(Export, CanExport);
                }
                return _ExportCommand;
            }
        }

        public bool CanExport()
        {
            return Aup2Item2 != null && Aup2Path != null;
            //return Aup2Item != null && Aup2Path != null;
        }

        public void Export()
        {
            _model.Export(Aup2Path);
        }


        private MainModel _model;
        private PropertyChangedWeakEventListener _listener;
    }
}
