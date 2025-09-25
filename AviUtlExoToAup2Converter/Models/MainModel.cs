using Livet;

namespace AviUtlExoToAup2Converter.Models
{
    public class MainModel : NotificationObject
    {
        #region Property

        private Convert _ConvertModel = new();

        public Convert ConvertModel
        {
            get
            { return _ConvertModel; }
            set
            { 
                if (_ConvertModel == value)
                    return;
                _ConvertModel = value;
                RaisePropertyChanged();
            }
        }

        private Setting _SettingModel = new();

        public Setting SettingModel
        {
            get
            { return _SettingModel; }
            set
            { 
                if (_SettingModel == value)
                    return;
                _SettingModel = value;
                RaisePropertyChanged();
            }
        }

        #endregion
    }
}
