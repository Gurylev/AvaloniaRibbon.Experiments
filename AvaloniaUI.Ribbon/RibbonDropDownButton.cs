using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Generators;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Styling;
using Avalonia.VisualTree;


using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvaloniaUI.Ribbon
{
    public class RibbonDropDownButton : ItemsControl, IRibbonControl, ICanAddToQuickAccess
    {


        public static readonly AvaloniaProperty<RibbonControlSize> SizeProperty;
        public static readonly AvaloniaProperty<RibbonControlSize> MinSizeProperty;
        public static readonly AvaloniaProperty<RibbonControlSize> MaxSizeProperty;
        public static readonly StyledProperty<bool> CanAddToQuickAccessProperty = RibbonButton.CanAddToQuickAccessProperty.AddOwner<RibbonDropDownButton>();
        public bool CanAddToQuickAccess
        {
            get => GetValue(CanAddToQuickAccessProperty);
            set => SetValue(CanAddToQuickAccessProperty, value);
        }


        public static readonly StyledProperty<IControlTemplate> IconProperty = RibbonButton.IconProperty.AddOwner<RibbonDropDownButton>();
        public IControlTemplate Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }


        public static readonly StyledProperty<IControlTemplate> LargeIconProperty = RibbonButton.LargeIconProperty.AddOwner<RibbonDropDownButton>();
        public IControlTemplate LargeIcon
        {
            get => GetValue(LargeIconProperty);
            set => SetValue(LargeIconProperty, value);
        }


        public static readonly StyledProperty<IControlTemplate> QuickAccessIconProperty = RibbonButton.QuickAccessIconProperty.AddOwner<RibbonToggleButton>();
        public IControlTemplate QuickAccessIcon
        {
            get => GetValue(QuickAccessIconProperty);
            set => SetValue(QuickAccessIconProperty, value);
        }


        public static readonly StyledProperty<IControlTemplate> QuickAccessTemplateProperty = RibbonButton.QuickAccessTemplateProperty.AddOwner<RibbonDropDownButton>();
        public IControlTemplate QuickAccessTemplate
        {
            get => GetValue(QuickAccessTemplateProperty);
            set => SetValue(QuickAccessTemplateProperty, value);
        }


        public static readonly StyledProperty<object> ContentProperty = ContentControl.ContentProperty.AddOwner<RibbonDropDownButton>();
        public static readonly StyledProperty<bool> IsDropDownOpenProperty = ComboBox.IsDropDownOpenProperty.AddOwner<RibbonDropDownButton>();


        public RibbonControlSize Size
        {
            get => (RibbonControlSize)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        public RibbonControlSize MinSize
        {
            get => (RibbonControlSize)GetValue(MinSizeProperty);
            set => SetValue(MinSizeProperty, value);
        }

        public RibbonControlSize MaxSize
        {
            get => (RibbonControlSize)GetValue(MaxSizeProperty);
            set => SetValue(MaxSizeProperty, value);
        }

        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public bool IsDropDownOpen
        {
            get => GetValue(IsDropDownOpenProperty);
            set => SetValue(IsDropDownOpenProperty, value);
        }


        //protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        //{
        //    base.OnAttachedToVisualTree(e);

        //    try
        //    {
        //        var p = e.Parent.FindDescendantOfType<Popup>(true);
        //        //var p = this.FindControl<Control>("PART_Popup"); //this.Get<Popup>("PART_Popup");//this.Find<Popup>("PART_Popup"); //this.FindControl<Popup>("local|RibbonSplitButton /template/ Popup#PART_Popup");
        //        if (p != null)
        //        {
        //            p.KeyDown += P_KeyDown;
        //            //this.AddDisposableHandler(Popup.KeyDownEvent, P_KeyDown);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private static T GetControl<T>(TemplateAppliedEventArgs e, string name) where T : class
        //{
        //    return e.NameScope.Get<T>(name);
        //}
        //protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        //{
        //    base.OnApplyTemplate(e);

        //    var p = GetControl<Popup>(e, "PART_Popup");
        //    if (p is null)
        //        return;
        //    p.PointerPressed += (sender, e) =>
        //    {
        //        Console.WriteLine($"===> Popup_PointerPressed event. IsPrimary: {e.Pointer.IsPrimary}");
        //        if (!(sender is Popup popup))
        //            return;
        //        popup.IsOpen = false;
        //    };
        //}

        static RibbonDropDownButton()
        {
            RibbonControlHelper<RibbonDropDownButton>.SetProperties(out SizeProperty, out MinSizeProperty, out MaxSizeProperty);

            //_ = RibbonDropDownItemPresenter.PointerPressedEvent
            //                               .Raised
            //                               .Subscribe(onNext: args =>
            //                               {
            //                                   if (!(args.Item1 is Popup item))
            //                                       return;

            //                                   RibbonDropDownButton? ribbonDropDownButton = null;

            //                                   var parentButton = item.FindAncestorOfType<RibbonDropDownButton>()
            //                                                                   ?? item.FindAncestorOfType<RibbonSplitButton>();
            //                                   if (parentButton != null)
            //                                       parentButton.IsDropDownOpen = false;

            //                                   //item.IsOpen = false;
            //                               });
        }



        //TODO
        //protected override IItemContainerGenerator CreateItemContainerGenerator()
        //{
        //    return new ItemContainerGenerator<RibbonDropDownItemPresenter>(this, RibbonDropDownItemPresenter.ContentProperty, RibbonDropDownItemPresenter.ContentTemplateProperty);
        //}
    }

    //public class RibbonDropDownItem : GalleryItem { }
    public class RibbonDropDownButtonItemsPresenter : ItemsPresenter
    {
        //protected override IItemContainerGenerator CreateItemContainerGenerator()
        //{
        //    return new ItemContainerGenerator<RibbonDropDownItemPresenter>(this, RibbonDropDownItemPresenter.ContentProperty, RibbonDropDownItemPresenter.ContentTemplateProperty);
        //}

        protected override Type StyleKeyOverride => typeof(ItemsPresenter);
    }
}
