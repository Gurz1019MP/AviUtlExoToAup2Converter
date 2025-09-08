using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class ConvertLogicRootViewModel : ViewModel
    {
        public ConvertLogicRootViewModel(ConvertLogicRoot model)
        {
            _model = model;
            LogicItems = [.. _model.LogicItems.CreateViewModels().Cast<LogicItemViewModel>()];
        }

        private LogicItemViewModel[] _LogicItems = [];

        public LogicItemViewModel[] LogicItems
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

        private readonly ConvertLogicRoot _model;
    }
}
