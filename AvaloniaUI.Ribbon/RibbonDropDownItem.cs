using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using Avalonia.Controls.Templates;

namespace AvaloniaUI.Ribbon
{

    public class RibbonDropDownItem : AvaloniaObject
    {
        public static readonly DirectProperty<RibbonDropDownItem, string> TextProperty =
            AvaloniaProperty.RegisterDirect<RibbonDropDownItem, string>(
                nameof(Text),
                o => o.Text,
                (o, v) => o.Text = v);
        
        private string _text = string.Empty;
        [Content]
        public string Text
        {
            get => _text;
            set => SetAndRaise(TextProperty, ref _text, value);
        }


        public static readonly StyledProperty<IControlTemplate> IconProperty = RibbonButton.IconProperty.AddOwner<RibbonDropDownItem>(); //AvaloniaProperty.Register<RibbonControlItem, IControlTemplate>(nameof(Icon));
        public IControlTemplate Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        
        public static readonly StyledProperty<bool> IsCheckedProperty = AvaloniaProperty.Register<RibbonDropDownItem, bool>(nameof(IsChecked));
        public bool IsChecked
        {
            get => GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public static readonly StyledProperty<ICommand> CommandProperty = Button.CommandProperty.AddOwner<RibbonDropDownItem>();
        public ICommand Command
        {
            get => GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }


        public static readonly StyledProperty<object> CommandParameterProperty = Button.CommandParameterProperty.AddOwner<RibbonDropDownItem>();
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }
    }
}