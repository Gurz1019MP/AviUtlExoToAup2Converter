using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FindFirstFilterByNameViewModel(FindFirstFilterByName model) : ConvertLogicViewModelBase
    {
        public FindFirstFilterByName Model { get; } = model;
    }
}
