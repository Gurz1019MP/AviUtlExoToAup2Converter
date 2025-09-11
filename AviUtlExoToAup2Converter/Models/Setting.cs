using AviUtlExoToAup2Converter.Models.ConvertLogic;
using AviUtlExoToAup2Converter.Models.DAO;
using Livet;

namespace AviUtlExoToAup2Converter.Models
{
    public class Setting : NotificationObject
    {
        #region Property

        private ConvertLogicRoot? _Logic;

        public ConvertLogicRoot? Logic
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

        #region Method

        public void LoadLogic(string path)
        {
            Logic = XmlAccessObject.Deserialize(path);
        }

        public void SaveLogic(string path)
        {
            if (Logic == null) return;
            if (string.IsNullOrEmpty(path)) return;

            XmlAccessObject.Serialize(Logic, path);
        }

        public void CreateNewLogic()
        {
            Logic = new ConvertLogicRoot()
            {
                LogicItems = [new LogicItem()]
            };
        }

        public void DropRemove(object obj)
        {
            if (Logic == null) return;

            foreach(LogicItem item in Logic.LogicItems)
            {
                item.RemoveObject(obj);
            }
        }

        #endregion
    }
}
