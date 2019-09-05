using Xamarin.Forms;

namespace Redmine.Views.Behaviors
{
    public class EnumStateBehavior : BehaviorBase<View>
    {
        public object Value
        {
            get => (object) GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(
                "Value",
                typeof(object),
                typeof(EnumStateBehavior),
                propertyChanged: ValuePropertyChanged);

        private static void ValuePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var behavior = bindable as EnumStateBehavior;
            if (behavior?.AssociatedObject == null || newvalue == null) return;

            VisualStateManager.GoToState(behavior.AssociatedObject as View, newvalue.ToString());
        }
    }
}