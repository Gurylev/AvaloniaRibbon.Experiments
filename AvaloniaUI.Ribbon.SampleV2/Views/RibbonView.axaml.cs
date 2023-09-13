using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System.Threading.Tasks;
using System;
using AvaloniaUI.Ribbon.SampleV2.ViewModels;

namespace AvaloniaUI.Ribbon.SampleV2.Views
{
    public partial class RibbonView : Ribbon, IViewFor<RibbonViewModel>
    {
        public static readonly StyledProperty<RibbonViewModel?> ViewModelProperty = AvaloniaProperty
            .Register<RibbonView, RibbonViewModel?>(nameof(ViewModel));

        public RibbonViewModel? ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object? IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (RibbonViewModel?)value;
        }

        public RibbonView()
        {
            InitializeComponent();

            //ViewModel = AppHelper.GetRequiredService<RibbonViewModel>();
            //DataContext = ViewModel;

            this.GetObservable(DataContextProperty).Subscribe(OnDataContextChanged);
            this.GetObservable(ViewModelProperty).Subscribe(OnViewModelChanged);

            this.WhenActivated(disposables =>
            {
                
            });   
        }

        private void OnViewModelChanged(RibbonViewModel? value)
        {
            if (value == null)
            {
                ClearValue(DataContextProperty);
            }
            else if (DataContext != value)
            {
                DataContext = value;
            }
        }

        private void OnDataContextChanged(object? value)
        {
            if (value is RibbonViewModel viewModel)
            {
                ViewModel = viewModel;
            }
            else
            {
                ViewModel = null;
            }
        }

       
    }
}
