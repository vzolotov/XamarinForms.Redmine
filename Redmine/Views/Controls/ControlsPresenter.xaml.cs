using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Redmine.Views.Controls
{
    public partial class ControlsPresenter : ContentView
    {
        public ControlsPresenter()
        {
            InitializeComponent();
            BindingContextChanged += Handle_BindingContextChanged;
        }

        void Handle_BindingContextChanged(object sender, EventArgs e)
        {
            BindingContextChanged -= Handle_BindingContextChanged;
            switch(Device.Idiom)
            {
                case TargetIdiom.Tablet:
                case TargetIdiom.Desktop:
                case TargetIdiom.TV:
                    Content = DesktopControl;
                    break;
                case TargetIdiom.Phone:
                case TargetIdiom.Watch:
                    Content = MobileControl;
                    break;
                default: throw new NotSupportedException("Device idiom not supported");
            }
        }


        public static BindableProperty DesktopControlProperty =
            BindableProperty.Create(
                nameof(DesktopControl),
                typeof(ContentView),
                typeof(ControlsPresenter),
                null,
                defaultBindingMode: BindingMode.OneWay);

        public ContentView DesktopControl
        {
            get => (ContentView)GetValue(DesktopControlProperty);
            set => SetValue(DesktopControlProperty, value);
        }

        public static BindableProperty MobileControlProperty =
            BindableProperty.Create(
                nameof(MobileControl),
                typeof(ContentView),
                typeof(ControlsPresenter),
                null,
                defaultBindingMode: BindingMode.OneWay);

        public ContentView MobileControl
        {
            get => (ContentView)GetValue(MobileControlProperty);
            set => SetValue(MobileControlProperty, value);
        }
    }
}
