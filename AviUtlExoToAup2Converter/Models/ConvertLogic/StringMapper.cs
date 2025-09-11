using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.Models.Item;
using AviUtlExoToAup2Converter.ViewModels;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class StringMapper : ConvertLogicBase, IMapper, ICloneable, IRemovable
    {
        private IValue<string>? _From;

        [DataMember]
        public IValue<string>? From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }

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

        public IAttribute Map(Dictionary<string, object> proxy)
        {
            if (From == null) throw new InvalidOperationException("Fromが設定されていません");

            string? value = From.Invoke(proxy);
            if (value == null)
            {
                value = string.Empty;
            }
            return new StringAttribute(To, value);
        }

        public object Clone()
        {
            return new StringMapper()
            {
                From = (From as ICloneable)?.Clone() as IValue<string>,
                To = To
            };
        }

        public void DropFrom(object obj)
        {
            if (obj is IValue<string> valueString)
            {
                From = (valueString as ICloneable)?.Clone() as IValue<string>;
            }
            else if (obj is IValue<Empty> valueEmpty)
            {
                From = valueEmpty.ToType<Empty, string>();
            }
        }

        public void RemoveObject(object obj)
        {
            if (From == obj)
            {
                From = null;
            }

            if (From is IRemovable removable)
            {
                removable.RemoveObject(obj);
            }
        }
    }
}
