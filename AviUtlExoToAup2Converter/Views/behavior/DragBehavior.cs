using Microsoft.Xaml.Behaviors;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace AviUtlExoToAup2Converter.Views.behavior
{
    public class DragBehavior : Behavior<Border>
    {
        public object Model
        {
            get { return (object)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(object), typeof(DragBehavior), new PropertyMetadata(null));

        private bool _isDragReady = false;
        private GhostAdorner? _ghostAdorner;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out PointI lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetDpiForWindow(IntPtr hWnd);

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseDown += AssociatedObject_MouseDown;
            AssociatedObject.MouseUp += AssociatedObject_MouseUp;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.GiveFeedback += AssociatedObject_GiveFeedback;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseDown -= AssociatedObject_MouseDown;
            AssociatedObject.MouseUp -= AssociatedObject_MouseUp;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.GiveFeedback -= AssociatedObject_GiveFeedback;
        }

        private void AssociatedObject_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _isDragReady = true;
        }

        private void AssociatedObject_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isDragReady= false;
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDragReady) return;
            _isDragReady = false;

            if (e.LeftButton != MouseButtonState.Pressed) return;
            if (sender is not Border dragSource) return;

            var layer = AdornerLayer.GetAdornerLayer(dragSource);
            _ghostAdorner = new GhostAdorner(dragSource);
            PointI lpPoint = GetScaledCursorPos(Process.GetCurrentProcess().MainWindowHandle);
            _ghostAdorner.Offset = new(-lpPoint.X, -lpPoint.Y);
            layer.Add(_ghostAdorner);

            DataObject data = new("ConvertLogicModel", Model);
            DragDrop.DoDragDrop(dragSource, data, DragDropEffects.Move);

            layer.Remove(_ghostAdorner);
            dragSource = null!;
            _ghostAdorner = null!;
        }

        private void AssociatedObject_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (_ghostAdorner == null) return;

            PointI lpPoint = GetScaledCursorPos(Process.GetCurrentProcess().MainWindowHandle);
            _ghostAdorner.CurrentPoint = new(lpPoint.X, lpPoint.Y);
            _ghostAdorner.InvalidateVisual();
        }

        public static PointI GetScaledCursorPos(IntPtr hWnd)
        {
            GetCursorPos(out PointI lpPoint);
            
            uint dpi = GetDpiForWindow(hWnd);
            double dpiScale = dpi / 96.0;

            return new PointI
            {
                X = (int)(lpPoint.X / dpiScale),
                Y = (int)(lpPoint.Y / dpiScale),
            };
        }

        public struct PointI
        {
            public int X; public int Y;
        }
    }
}
