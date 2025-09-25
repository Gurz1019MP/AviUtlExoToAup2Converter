using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace AviUtlExoToAup2Converter.Views
{
    public class GhostAdorner : Adorner
    {
        public GhostAdorner(UIElement adornedElement) : base(adornedElement)
        {
            IsHitTestVisible = false;
        }

        public Point CurrentPoint
        {
            get { return (Point)GetValue(CurrentPointProperty); }
            set { SetValue(CurrentPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPointProperty =
            DependencyProperty.Register("CurrentPoint", typeof(Point), typeof(GhostAdorner), new PropertyMetadata(new Point(0, 0)));

        public Point Offset
        {
            get { return (Point)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(Point), typeof(GhostAdorner), new PropertyMetadata(new Point(0, 0)));

        private VisualBrush? _brush;

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var pt = new Point(CurrentPoint.X + Offset.X, CurrentPoint.Y + Offset.Y);
            var rect = new Rect(pt, AdornedElement.RenderSize);
            if (_brush == null)
            {
                _brush = new VisualBrush(AdornedElement);
                _brush.Opacity = 0.5;
            }

            drawingContext.DrawRectangle(_brush, null, rect);
        }
    }
}
