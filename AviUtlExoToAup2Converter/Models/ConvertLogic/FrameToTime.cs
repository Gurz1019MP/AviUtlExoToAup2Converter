using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.ViewModels;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Media.Media3D;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class FrameToTime : ConvertLogicBase, IValue<float>, ICloneable, IRemovable
    {
        private IValue<int>? _Frame;

        [DataMember]
        public IValue<int>? Frame
        {
            get
            { return _Frame; }
            set
            { 
                if (_Frame == value)
                    return;
                _Frame = value;
                RaisePropertyChanged();
            }
        }

        public float Invoke(Dictionary<string, object> proxy)
        {
            if (Frame == null) throw new InvalidOperationException("Frameが設定されていません");

            object target = proxy["baseItem"];
            Type type = target.GetType();
            PropertyInfo? propertyInfo = type.GetProperty("Attributes");
            if (propertyInfo == null) return default;

            object? objValue = propertyInfo.GetValue(target);
            if (objValue == null) return default;

            int rate = ((IAttribute[])objValue).GetValue<int>("rate");
            int scale = ((IAttribute[])objValue).GetValue<int>("scale");
            float frameRate = rate / scale;
            return Frame.Invoke(proxy) / frameRate;
        }

        public object Clone()
        {
            return new FrameToTime()
            {
                Frame = (Frame as ICloneable)?.Clone() as IValue<int>
            };
        }

        public void DropFrame(object obj)
        {
            if (obj is IValue<int> valueInt)
            {
                Frame = (valueInt as ICloneable)?.Clone() as IValue<int>;
            }
        }

        public void RemoveObject(object obj)
        {
            if (Frame == obj)
            {
                Frame = null;
            }

            if (Frame is IRemovable removable)
            {
                removable.RemoveObject(this);
            }
        }
    }
}
