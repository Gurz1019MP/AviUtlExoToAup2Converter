using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class GetAttributeValueViewModel<T>(GetAttributeValue<T> model) : ConvertLogicViewModelBase
    {
        public GetAttributeValue<T> Model { get; } = model;
    }
}
