using AviUtlExoToAup2Converter.Models.DAO;
using AviUtlExoToAup2Converter.ViewModels;
using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class Variable : NotificationObject, IRemovable
    {
        private string? _Key;

        [DataMember]
        public string? Key
        {
            get
            { return _Key; }
            set
            { 
                if (_Key == value)
                    return;
                _Key = value;
                RaisePropertyChanged();
            }
        }

        private IValue? _Value;

        [DataMember]
        public IValue? Value
        {
            get
            { return _Value; }
            set
            { 
                if (_Value == value)
                    return;
                _Value = value;
                RaisePropertyChanged();
            }
        }

        public dynamic Eval(Dictionary<string, object> proxy)
        {
            if (Value == null) throw new InvalidOperationException("Valueが設定されていません");

            return ((dynamic)Value).Invoke(proxy);
        }

        public void DropValue(object obj)
        {
            if (obj is IValue value)
            {
                Value = (value as ICloneable)?.Clone() as IValue;
            }
        }

        public void RemoveObject(object obj)
        {
            if (Value == obj)
            {
                Value = null;
            }

            if (Value is IRemovable removable)
            {
                removable.RemoveObject(obj);
            }
        }
    }
}
