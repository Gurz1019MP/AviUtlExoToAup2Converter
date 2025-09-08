using AviUtlExoToAup2Converter.Models.ConvertLogic;
using AviUtlExoToAup2Converter.ViewModels.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FindFirstFilterByNameViewModel : ViewModel, IValueViewModel<GeneralFilterViewModel>
    {
        public FindFirstFilterByNameViewModel(FindFirstFilterByName model)
        {
            _model = model;
        }

        public string Name
        {
            get {  return _model.Name; }
            set { _model.Name = value; }
        }

        private readonly FindFirstFilterByName _model;
    }
}
