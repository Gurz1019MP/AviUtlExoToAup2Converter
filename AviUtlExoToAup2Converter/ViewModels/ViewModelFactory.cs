using Livet;

namespace AviUtlExoToAup2Converter.ViewModels
{
    static class ViewModelFactory
    {
        public static ViewModel CreateViewModel(dynamic model)
        {
            Type type = model.GetType();
            string targetTypeString;
            if (type.IsGenericType)
            {
                targetTypeString = type.GetGenericTypeDefinition().FullName?.Replace("Model", "ViewModel").Replace("`1", string.Empty) + "ViewModel`1[[" + type.GetGenericArguments()[0].FullName + "]]";
            }
            else
            {
                targetTypeString = type.FullName?.Replace("Model", "ViewModel") + "ViewModel";
            }
            Type? targetType = Type.GetType(targetTypeString);
            if (targetType == null)
            {
                throw new InvalidOperationException("Modelに対応するViewModel定義が見つかりません");
            }
            else
            {
                object? instance = Activator.CreateInstance(targetType, new[] { model });
                if (instance == null)
                {
                    throw new InvalidOperationException("ViewModelインスタンスの作成に失敗しました");
                }
                else
                {
                    return (ViewModel)instance;
                }
            }
        }

        public static IReadOnlyCollection<ViewModel> CreateViewModels<T>(this IReadOnlyCollection<T> models)
        {
            List<ViewModel> viewModels = [];
            foreach (T model in models)
            {
                if (model != null)
                {
                    try
                    {
                        viewModels.Add(CreateViewModel(model));
                    }
                    catch (InvalidOperationException e)
                    {

                    }
                }
            }
            return viewModels;
        }
    }
}
