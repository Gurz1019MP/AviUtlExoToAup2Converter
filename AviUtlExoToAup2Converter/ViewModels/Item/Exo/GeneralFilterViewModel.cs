using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Exo;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Exo
{
    public class GeneralFilterViewModel(GeneralFilter model) : ViewModel
    {
        public string Name => _model.Name;

        public IAttribute[] Attributes => _model.Attributes;

        private GeneralFilter _model = model;
    }
}
