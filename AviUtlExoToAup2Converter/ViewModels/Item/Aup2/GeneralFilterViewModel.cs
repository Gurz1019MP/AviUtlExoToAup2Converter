using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.Models.Item.Aup2;
using Livet;

namespace AviUtlExoToAup2Converter.ViewModels.Item.Aup2
{
    public class GeneralEffectViewModel(GeneralEffect model) : ViewModel
    {
        public string Name => _model.Name;

        public IAttribute[] Attributes => _model.Attributes;

        private GeneralEffect _model = model;
    }
}
