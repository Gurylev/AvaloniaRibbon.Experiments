using Avalonia;
using Avalonia.Collections;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using Avalonia.Styling;
using System;
using System.Linq;
using System.Collections;
using System.Diagnostics;
using Avalonia.Controls.Primitives;
using System.Collections.Specialized;
using Avalonia.LogicalTree;
using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace AvaloniaUI.Ribbon
{
    public class RibbonContextualTabGroup : HeaderedItemsControl, IRibbonTab
    {
  //      public static readonly StyledProperty<ObservableCollection<IRibbonTab>> ContextualTabsProperty =
  //AvaloniaProperty.Register<RibbonContextualTabGroup, ObservableCollection<IRibbonTab>>(nameof(ContextualTabs));

  //      public ObservableCollection<IRibbonTab> ContextualTabs
  //      {
  //          get { return GetValue(ContextualTabsProperty); }
  //          set { SetValue(ContextualTabsProperty, value); }
  //      }

        //       public static readonly StyledProperty<IRibbonTab> SelectedTabProperty =
        //AvaloniaProperty.Register<RibbonContextualTabGroup, IRibbonTab>(nameof(SelectedTab));

        //       public IRibbonTab SelectedTab
        //       {
        //           get { return GetValue(SelectedTabProperty); }
        //           set { SetValue(SelectedTabProperty, value); }
        //       }
        static RibbonContextualTabGroup()
        {
            IsVisibleProperty.Changed.AddClassHandler<RibbonContextualTabGroup>((sender, e) =>
            {
                if ((e.NewValue is bool visible) && (!visible))
                    sender.SwitchToNextVisibleTab();
            });

            ItemsSourceProperty.Changed.AddClassHandler<RibbonContextualTabGroup>((sender, args) =>
            {
                if (args.OldValue is INotifyCollectionChanged oldSource)
                    oldSource.CollectionChanged -= sender.ItemsCollectionChanged;
                if (args.NewValue is INotifyCollectionChanged newSource)
                {
                    newSource.CollectionChanged += sender.ItemsCollectionChanged;
                }
            });
        }

        protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
        {
            base.OnAttachedToVisualTree(e);
        }

        protected override void OnAttachedToLogicalTree(LogicalTreeAttachmentEventArgs e)
        {
            base.OnAttachedToLogicalTree(e);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
        }

        public RibbonContextualTabGroup()
        {
            //ItemsSource = new ObservableCollection<IRibbonTab>();
            //ContextualTabs = new ObservableCollection<IRibbonTab>();
            Items.CollectionChanged += ItemsCollectionChanged;           
        }

        void SwitchToNextVisibleTab()
        {
            Ribbon rbn = RibbonControlExtensions.GetParentRibbon(this);
            if ((rbn != null) && ((IAvaloniaList<object>)Items).Contains(rbn.SelectedItem))
            {
                int selIndex = rbn.SelectedIndex;

                rbn.CycleTabs(false);

                if (selIndex == rbn.SelectedIndex)
                    rbn.CycleTabs(true);
            }
        }

        protected void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (RibbonTab tab in e.OldItems.OfType<RibbonTab>())
                    tab.IsContextual = false;
            }

            if (e.NewItems != null)
            {
                foreach (RibbonTab tab in e.NewItems.OfType<RibbonTab>())
                    tab.IsContextual = true;
            }
        }

        protected override Type StyleKeyOverride => typeof(RibbonContextualTabGroup);
    }
}