using Livet;
using System.Runtime.Serialization;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    [DataContract]
    public class LogicItem : NotificationObject, IRemovable
    {
        private string _EffectName = string.Empty;

        [DataMember]
        public string EffectName
        {
            get
            { return _EffectName; }
            set
            { 
                if (_EffectName == value)
                    return;
                _EffectName = value;
                RaisePropertyChanged();
            }
        }

        private Variable[] _LocalVars = [];

        [DataMember]
        public Variable[] LocalVars
        {
            get
            { return _LocalVars; }
            set
            { 
                if (_LocalVars == value)
                    return;
                _LocalVars = value;
                RaisePropertyChanged();
            }
        }

        private IValue<bool>? _Condition;

        [DataMember]
        public IValue<bool>? Condition
        {
            get
            { return _Condition; }
            set
            { 
                if (_Condition == value)
                    return;
                _Condition = value;
                RaisePropertyChanged();
                RefleshConditionWeakEventListener();
            }
        }

        private IMapper[] _Mappers = [];

        [DataMember]
        public IMapper[] Mappers
        {
            get
            { return _Mappers; }
            set
            { 
                if (_Mappers == value)
                    return;
                _Mappers = value;
                RaisePropertyChanged();
            }
        }

        public void DropCondition(object? obj)
        {
            if (obj is IValue<bool> valueBool)
            {
                Condition = (valueBool as ICloneable)?.Clone() as IValue<bool>;
            }
        }

        public void AddVariable()
        {
            LocalVars = [.. LocalVars.Append(new Variable())];
        }

        public void DropMapper(object obj)
        {
            if (obj is IMapper mapper)
            {
                IMapper? cloneMapper = (mapper as ICloneable)?.Clone() as IMapper;
                if (cloneMapper == null) return;
                Mappers = [.. Mappers.Append(cloneMapper)];
            }
        }

        public void RemoveObject(object obj)
        {
            if (Condition == obj)
            {
                Condition = null;
            }

            if (Condition is IRemovable removableCondition)
            {
                removableCondition.RemoveObject(obj);
            }

            List<Variable> removeVariable = [];
            foreach(Variable variable in LocalVars)
            {
                if (variable == obj)
                {
                    removeVariable.Add(variable);
                }

                variable.RemoveObject(obj);
            }
            LocalVars = [.. LocalVars.Except(removeVariable)];

            List<IMapper> removeMappers = [];
            foreach(IMapper mapper in Mappers)
            {
                if (mapper == obj)
                {
                    removeMappers.Add(mapper);
                }

                if (mapper is IRemovable removableMapper)
                {
                    removableMapper.RemoveObject(obj);
                }
            }

            Mappers = [.. Mappers.Except(removeMappers)];
        }

        private void RefleshConditionWeakEventListener()
        {
            if (Condition is not ConvertLogicBase eventSource) return;
            ReplaceModelWeakEventManager.AddHandler(eventSource, (s, e) => DropCondition(e.Model));
        }
    }
}
