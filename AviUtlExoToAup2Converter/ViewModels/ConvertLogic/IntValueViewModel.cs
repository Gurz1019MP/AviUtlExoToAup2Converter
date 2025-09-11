using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class IntValueViewModel(IntValue model) : ConvertLogicViewModelBase
    {
        public IntValue Model { get; } = model;
    }
}
