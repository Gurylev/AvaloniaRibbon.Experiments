using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUI.Ribbon
{
    public interface IRibbonTab : IInputElement
    {
        public bool IsSelected { get; set; }    
    }
}
