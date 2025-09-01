using AviUtlExoToAup2Converter.Models.Item.Exo.Filter;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo.Filter
{
    public class GeneralFilterViewModel(GeneralFilter model) : ViewModel
    {
        public string Name => _model.Name;

        public IAttribute[] Attributes => _model.Attributes;

        private GeneralFilter _model = model;
    }
}
