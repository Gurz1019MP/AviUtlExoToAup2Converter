using AviUtlExoToAup2Converter.Models.ConvertLogic;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class IntValueViewModel : ViewModel, IValueViewModel<int>
    {
        public IntValueViewModel(IntValue model)
        {
            _model = model;
        }

        public int Value
        {
            get { return _model.Value; }
            set { _model.Value = value; }
        }

        private readonly IntValue _model;
    }
}
