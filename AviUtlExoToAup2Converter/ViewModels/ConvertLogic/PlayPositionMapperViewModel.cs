using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class PlayPositionMapperViewModel : ViewModel, IMapperViewModel
    {
        public PlayPositionMapperViewModel(PlayPositionMapper model)
        {
            _model = model;
            _Start = (IValueViewModel<float>)ViewModelFactory.CreateViewModel(_model.Start);
            _End = (IValueViewModel<float>)ViewModelFactory.CreateViewModel(_model.End);
            _Range = (IValueViewModel<int>)ViewModelFactory.CreateViewModel(_model.Range);
        }

        public string To
        {
            get { return _model.To; }
            set { _model.To = value; }
        }


        private IValueViewModel<float> _Start;

        public IValueViewModel<float> Start
        {
            get
            { return _Start; }
            set
            { 
                if (_Start == value)
                    return;
                _Start = value;
                RaisePropertyChanged();
            }
        }

        private IValueViewModel<float> _End;

        public IValueViewModel<float> End
        {
            get
            { return _End; }
            set
            {
                if (_End == value)
                    return;
                _End = value;
                RaisePropertyChanged();
            }
        }

        private IValueViewModel<int> _Range;

        public IValueViewModel<int> Range
        {
            get
            { return _Range; }
            set
            {
                if (_Range == value)
                    return;
                _Range = value;
                RaisePropertyChanged();
            }
        }

        private readonly PlayPositionMapper _model;
    }
}
