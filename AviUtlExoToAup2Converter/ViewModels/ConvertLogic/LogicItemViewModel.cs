using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class LogicItemViewModel : ViewModel
    {
        public LogicItemViewModel(LogicItem model)
        {
            _model = model;
            _LocalVars = [.. ViewModelFactory.CreateViewModels(model.LocalVars).Cast<VariableViewModel>()];
            _Condition = (IValueViewModel<bool>)ViewModelFactory.CreateViewModel(model.Condition);
            _Mappers = [.. ViewModelFactory.CreateViewModels(model.Mappers).Cast<IMapperViewModel>()];
        }

        public string EffectName
        {
            get { return _model.EffectName; }
            set { _model.EffectName = value; }
        }

        private VariableViewModel[] _LocalVars;

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


        private IValueViewModel<bool> _Condition;

        public IValueViewModel<bool> Condition
        {
            get
            { return _Condition; }
            set
            { 
                if (_Condition == value)
                    return;
                _Condition = value;
                RaisePropertyChanged();
            }
        }


        private IMapperViewModel[] _Mappers;

        public IMapperViewModel[] Mappers
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

        private readonly LogicItem _model;
    }
}
