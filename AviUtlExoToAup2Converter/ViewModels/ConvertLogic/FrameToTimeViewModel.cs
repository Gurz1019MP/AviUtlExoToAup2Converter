using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FrameToTimeViewModel : ViewModel, IValueViewModel<float>
    {
        public FrameToTimeViewModel(FrameToTime model)
        {
            _model = model;
            _Frame = (IValueViewModel<int>)ViewModelFactory.CreateViewModel(_model.Frame);
        }


        private IValueViewModel<int> _Frame;

        public IValueViewModel<int> Frame
        {
            get
            { return _Frame; }
            set
            { 
                if (_Frame == value)
                    return;
                _Frame = value;
                RaisePropertyChanged();
            }
        }


        private readonly FrameToTime _model;
    }
}
