using AviUtlExoToAup2Converter.Models.ConvertLogic;

namespace AviUtlExoToAup2Converter.ViewModels.ConvertLogic
{
    public class FloatValueViewModel(FloatValue model) : ConvertLogicViewModelBase
    {
        public FloatValue Model { get; } = model;
    }
}
