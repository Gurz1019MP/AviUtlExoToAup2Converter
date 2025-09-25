using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AviUtlExoToAup2Converter.Models.ConvertLogic
{
    public class ReplaceModelWeakEventManager : WeakEventManager
    {
        private ReplaceModelWeakEventManager() { }

        public static void AddHandler(ConvertLogicBase source, EventHandler<ConvertLogicBase.ReplaceModelEventArgs> handler)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(handler);

            CurrentManager.ProtectedAddHandler(source, handler);
        }

        public static void RemoveHandler(ConvertLogicBase source, EventHandler<ConvertLogicBase.ReplaceModelEventArgs> handler)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(handler);

            CurrentManager.ProtectedRemoveHandler(source, handler);
        }

        private static ReplaceModelWeakEventManager CurrentManager
        {
            get
            {
                Type managerType = typeof(ReplaceModelWeakEventManager);
                ReplaceModelWeakEventManager manager = (ReplaceModelWeakEventManager)GetCurrentManager(managerType);

                if (manager == null)
                {
                    manager = new ReplaceModelWeakEventManager();
                    SetCurrentManager(managerType, manager);
                }

                return manager;
            }
        }

        protected override ListenerList NewListenerList()
        {
            return new ListenerList<ConvertLogicBase.ReplaceModelEventArgs>();
        }

        protected override void StartListening(object source)
        {
            ConvertLogicBase typedSource = (ConvertLogicBase)source;
            typedSource.ReplaceModel += new EventHandler<ConvertLogicBase.ReplaceModelEventArgs>(OnReplaceModel);
        }

        protected override void StopListening(object source)
        {
            ConvertLogicBase typedSource = (ConvertLogicBase)source;
            typedSource.ReplaceModel -= new EventHandler<ConvertLogicBase.ReplaceModelEventArgs>(OnReplaceModel);
        }

        void OnReplaceModel(object sender, ConvertLogicBase.ReplaceModelEventArgs e)
        {
            DeliverEvent(sender, e);
        }
    }
}
