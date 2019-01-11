using System;
using System.ComponentModel;
using Redmine.ViewModels;
using Xamarin.Forms;

namespace Redmine.Views
{
    public partial class PageBase
    {
        public PageBase()
        {
            InitializeComponent();
            Appearing += PageBase_AppearingAsync;
        }

        async void PageBase_AppearingAsync(object sender, EventArgs e)
        {
            Appearing -= PageBase_AppearingAsync;
            var vm = BindingContext as ViewModelBase;
            await vm?.NavigateToAsync(null);
        }
        
        public static BindableProperty CustomControlProperty =
            BindableProperty.Create(
                nameof(CustomControl),
                typeof(Layout),
                typeof(PageBase),
                null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: OnCustomControlChanged);

        private static void OnCustomControlChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(newvalue is Layout control)) return;
            if (!(bindable is PageBase page)) return;
            control.BindingContext = page.BindingContext;
            page.presenter.Content = control;
        }

        public Layout CustomControl
        {
            get => (Layout)GetValue(CustomControlProperty);
            set => SetValue(CustomControlProperty, value);
        }
        
        public static BindableProperty VisualElementControlProperty =
            BindableProperty.Create(
                nameof(CustomControl),
                typeof(ListView),
                typeof(PageBase),
                null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: OnVisualElementChanged);

        private static void OnVisualElementChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(newvalue is ListView control)) return;
            if (!(bindable is PageBase page)) return;
            control.BindingContext = page.BindingContext;
            page.presenter.Content = control;
        }

        public ListView VisualElementControl
        {
            get => (ListView)GetValue(VisualElementControlProperty);
            set => SetValue(VisualElementControlProperty, value);
        }
    }
}
