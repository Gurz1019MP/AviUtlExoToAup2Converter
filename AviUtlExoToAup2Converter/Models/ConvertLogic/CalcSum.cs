using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class CalcSum<T> : ConvertLogicBase, IValue<T>, ICloneable, IRemovable
    {
        private IValue<T>? _Operand1;

        [DataMember]
        public IValue<T>? Operand1
        {
            get
            { return _Operand1; }
            set
            { 
                if (_Operand1 == value)
                    return;
                _Operand1 = value;
                RaisePropertyChanged();
                RefleshOperand1WeakEventListener();
            }
        }

        private IValue<T>? _Operand2;

        [DataMember]
        public IValue<T>? Operand2
        {
            get
            { return _Operand2; }
            set
            { 
                if (_Operand2 == value)
                    return;
                _Operand2 = value;
                RaisePropertyChanged();
                RefleshOperand2WeakEventListener();
            }
        }

        public T? Invoke(Dictionary<string, object> proxy)
        {
            if (Operand1 == null) throw new InvalidOperationException("Operand1が設定されていません");
            if (Operand2 == null) throw new InvalidOperationException("Operand2が設定されていません");
            
            T? value1 = Operand1.Invoke(proxy);
            T? value2 = Operand2.Invoke(proxy);
            if (value1 != null && value2 != null)
            {
                return (dynamic)value1 + (dynamic)value2;
            }
            else
            {
                return default;
            }
        }

        public object Clone()
        {
            return new CalcSum<T>()
            {
                Operand1 = (Operand1 as ICloneable)?.Clone() as IValue<T>,
                Operand2 = (Operand2 as ICloneable)?.Clone() as IValue<T>,
            };
        }

        public void DropOperand1(object? obj)
        {
            if (obj is IValue<T> value)
            {
                Operand1 = (value as ICloneable)?.Clone() as IValue<T>;
            }
            else if (typeof(T) == typeof(Empty))
            {
                if (obj is IValue<int> intValue)
                {
                    CalcSum<int> model = this.ToType<T, int>();
                    model.Operand1 = intValue;
                    RaiseReplaceModel(model);
                }
                else if (obj is IValue<float> floatValue)
                {
                    CalcSum<float> model = this.ToType<T, float>();
                    model.Operand1 = floatValue;
                    RaiseReplaceModel(model);
                }
            }
        }

        public void DropOperand2(object? obj)
        {
            if (obj is IValue<T> value)
            {
                Operand2 = (value as ICloneable)?.Clone() as IValue<T>;
            }
            else if (typeof(T) == typeof(Empty))
            {
                if (obj is IValue<int> intValue)
                {
                    CalcSum<int> model = this.ToType<T, int>();
                    model.Operand2 = intValue;
                    RaiseReplaceModel(model);
                }
                else if (obj is IValue<float> floatValue)
                {
                    CalcSum<float> model = this.ToType<T, float>();
                    model.Operand2 = floatValue;
                    RaiseReplaceModel(model);
                }
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

        private void RefleshOperand1WeakEventListener()
        {
            if (Operand1 is not ConvertLogicBase eventSource) return;
            ReplaceModelWeakEventManager.AddHandler(eventSource, (s, e) => DropOperand1(e.Model));
        }

        private void RefleshOperand2WeakEventListener()
        {
            if (Operand2 is not ConvertLogicBase eventSource) return;
            ReplaceModelWeakEventManager.AddHandler(eventSource, (s, e) => DropOperand2(e.Model));
        }
    }
}
