using AviUtlExoToAup2Converter.ViewModels.ConvertLogic;
using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AviUtlExoToAup2Converter.Views.behavior
{
    public class DropBehavior : Behavior<Border>
    {
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(DropBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Drop += AssociatedObject_Drop;
            AssociatedObject.AllowDrop = true;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.Drop -= AssociatedObject_Drop;
            AssociatedObject.AllowDrop = false;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("ConvertLogicModel")) return;
            if (sender is not Border dropTarget) return;
            if (ReadOnlyProperty.GetIsReadOnly(dropTarget)) return;

            object data = e.Data.GetData("ConvertLogicModel");

            if (Command?.CanExecute(data) != true) return;
            
            Command.Execute(data);

            e.Handled = true;
        }
    }
}
