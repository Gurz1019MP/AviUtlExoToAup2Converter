using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class BoolConditionEqual : ConvertLogicBase, IValue<bool>, ICloneable, IRemovable
    {
        private IValue<bool>? _Operand1;

        [DataMember]
        public IValue<bool>? Operand1
        {
            get
            { return _Operand1; }
            set
            { 
                if (_Operand1 == value)
                    return;
                _Operand1 = value;
                RaisePropertyChanged();
            }
        }

        private IValue<bool>? _Operand2;

        [DataMember]
        public IValue<bool>? Operand2
        {
            get
            { return _Operand2; }
            set
            { 
                if (_Operand2 == value)
                    return;
                _Operand2 = value;
                RaisePropertyChanged();
            }
        }

        public bool Invoke(Dictionary<string, object> proxy)
        {
            if (Operand1 == null) return false;
            if (Operand2 == null) return false;

            bool value1 = Operand1.Invoke(proxy);
            if (!value1) return false;

            bool value2 = Operand2.Invoke(proxy);

            return value1 && value2;
        }

        public object Clone()
        {
            return new BoolConditionEqual()
            {
                Operand1 = (Operand1 as ICloneable)?.Clone() as IValue<bool>,
                Operand2 = (Operand2 as ICloneable)?.Clone() as IValue<bool>
            };
        }

        public void DropOperand1(object obj)
        {
            if (obj is IValue<bool> valueBool)
            {
                Operand1 = (valueBool as ICloneable)?.Clone() as IValue<bool>;
            }
        }

        public void DropOperand2(object obj)
        {
            if (obj is IValue<bool> valueBool)
            {
                Operand2 = (valueBool as ICloneable)?.Clone() as IValue<bool>;
            }
        }

        public void RemoveObject(object obj)
        {
            if (Operand1 == obj)
            {
                Operand1 = null;
            }
            else if (Operand2 == obj)
            {
                Operand2 = null;
            }

            if (Operand1 is IRemovable removableOperand1)
            {
                removableOperand1.RemoveObject(obj);
            }
            
            if (Operand2 is IRemovable removableOperand2)
            {
                removableOperand2.RemoveObject(obj);
            }
        }
    }
}
