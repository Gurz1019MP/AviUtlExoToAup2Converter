using AviUtlExoToAup2Converter.Models;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region .ctor

        public MainViewModel()
        {
            _model = new MainModel();
            Convert = (ConvertViewModel)ViewModelFactory.CreateViewModel(_model.ConvertModel);
            Setting = (SettingViewModel)ViewModelFactory.CreateViewModel(_model.SettingModel);
        }

        #endregion

        #region Property

        private ConvertViewModel? _Convert;

        public ConvertViewModel? Convert
        {
            get
            { return _Convert; }
            set
            { 
                if (_Convert == value)
                    return;
                _Convert = value;
                RaisePropertyChanged();
            }
        }

        private SettingViewModel? _Setting;

        public SettingViewModel? Setting
        {
            get
            { return _Setting; }
            set
            { 
                if (_Setting == value)
                    return;
                _Setting = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        private MainModel _model;
    }
}
