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
                defaultBindingMode: BindingMode.OneWay);

        public Layout CustomControl
        {
            get => (Layout)GetValue(CustomControlProperty);
            set => SetValue(CustomControlProperty, value);
        }
    }
}
