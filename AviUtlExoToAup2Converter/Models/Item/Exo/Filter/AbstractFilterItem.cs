using Livet;

namespace AviUtlExoToAup2Converter.Models.Item.Exo.Filter
{
    public abstract class AbstractFilterItem : NotificationObject
    {
        #region Property

        public abstract string Name { get; }

        #endregion

        #region Method

        public abstract void SetProperty(string propertyName, string value);

        public abstract IReadOnlyList<string> ToContentText();

        public abstract AbstractFilterItem Clone();

        public static AbstractFilterItem CreateFilterItem(string name)
        {
            object? instance = Activator.CreateInstance(FilterNameMapper[name]);
            if (instance == null)
            {
                throw new InvalidOperationException("FilterItemインスタンスの作成に失敗しました");
            }
            else
            {
                return (AbstractFilterItem)instance;
            }
        }

        #endregion

        #region Field

        private static Dictionary<string, Type> FilterNameMapper = new()
        {
            { "音声ファイル", typeof(AudioFile) },
            { "動画ファイル", typeof(MovieFile) },
            { "標準再生", typeof(DefaultPlay) },
            { "標準描画", typeof(DefaultDraw) },
        };

        #endregion
    }
}
