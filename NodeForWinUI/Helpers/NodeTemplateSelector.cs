using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using NodeForWinUI.ViewModels;

namespace NodeForWinUI.Helpers;
public class NodeTemplateSelector : DataTemplateSelector
{
    public DataTemplate ConstantNodeTemplate
    {
        get; set;
    }
    public DataTemplate PlusNodeTemplate
    {
        get; set;
    }
    public DataTemplate MinusNodeTemplate
    {
        get; set;
    }
    public DataTemplate ResultNodeTemplate
    {
        get; set;
    }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
        if (item is ConstantNodeViewModel)
            return ConstantNodeTemplate;
        //else if (item is PlusNodeViewModel)
        //    return PlusNodeTemplate;
        //else if (item is MinusNodeViewModel)
        //    return MinusNodeTemplate;
        //else if (item is ResultNodeViewModel)
        //    return ResultNodeTemplate;
        else
            return base.SelectTemplateCore(item, container);
    }
}
