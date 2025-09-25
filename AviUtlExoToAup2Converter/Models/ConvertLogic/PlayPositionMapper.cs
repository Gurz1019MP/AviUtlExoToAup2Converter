using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.ViewModels;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class PlayPositionMapper : ConvertLogicBase, IMapper, ICloneable, IRemovable
    {
        private string? _To;

        [DataMember]
        public string? To
        {
            get
            { return _To; }
            set
            { 
                if (_To == value)
                    return;
                _To = value;
                RaisePropertyChanged();
            }
        }

        private IValue<float>? _Start;

        [DataMember]
        public IValue<float>? Start
        {
            get
            { return _Start; }
            set
            { 
                if (_Start == value)
                    return;
                _Start = value;
                RaisePropertyChanged();
            }
        }

        private IValue<float>? _End;

        [DataMember]
        public IValue<float>? End
        {
            get
            { return _End; }
            set
            { 
                if (_End == value)
                    return;
                _End = value;
                RaisePropertyChanged();
            }
        }

        private IValue<int>? _Range;

        [DataMember]
        public IValue<int>? Range
        {
            get
            { return _Range; }
            set
            { 
                if (_Range == value)
                    return;
                _Range = value;
                RaisePropertyChanged();
            }
        }

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            if (To == null) throw new InvalidOperationException("Toが設定されていません");
            if (Start == null) throw new InvalidOperationException("Startが設定されていません");
            if (End == null) throw new InvalidOperationException("Endが設定されていません");
            if (Range == null) throw new InvalidOperationException("Rangeが設定されていません");

            return new PlayPositionAttribute(To, new PlayPosition()
            {
                Start = Start.Invoke(proxy),
                End = End.Invoke(proxy),
                Range = Range.Invoke(proxy),
            });
        }

        public object Clone()
        {
            return new PlayPositionMapper()
            {
                To = To,
                Start = (Start as ICloneable)?.Clone() as IValue<float>,
                End = (End as ICloneable)?.Clone() as IValue<float>,
                Range = (Range as ICloneable)?.Clone() as IValue<int>,
            };
        }

        public void DropStart(object obj)
        {
            if (obj is IValue<float> valueFloat)
            {
                Start = (valueFloat as ICloneable)?.Clone() as IValue<float>;
            }
        }

        public void DropEnd(object obj)
        {
            if (obj is IValue<float> valueFloat)
            {
                End = (valueFloat as ICloneable)?.Clone() as IValue<float>;
            }
        }

        public void DropRange(object obj)
        {
            if (obj is IValue<int> valueInt)
            {
                Range = (valueInt as ICloneable)?.Clone() as IValue<int>;
            }
        }

        public void RemoveObject(object obj)
        {
            if (Start == obj)
            {
                Start = null;
            }
            else if (End == obj)
            {
                End = null;
            }
            else if (Range == obj)
            {
                Range = null;
            }

            if (Start is IRemovable removableStart)
            {
                removableStart.RemoveObject(this);
            }

            if (End is IRemovable removableEnd)
            {
                removableEnd.RemoveObject(this);
            }

            if (Range is IRemovable removableRange)
            {
                removableRange.RemoveObject(this);
            }
        }
    }
}
