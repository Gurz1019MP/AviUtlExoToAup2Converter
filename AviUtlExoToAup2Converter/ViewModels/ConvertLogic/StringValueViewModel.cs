using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class StringValueViewModel(StringValue model) : ConvertLogicViewModelBase
    {
        public StringValue Model { get; } = model;
    }
}
