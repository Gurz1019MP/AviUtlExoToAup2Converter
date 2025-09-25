using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class GetPropertyViewModel<T>(GetProperty<T> model) : ConvertLogicViewModelBase
    {
        public GetProperty<T> Model { get; } = model;
    }
}
