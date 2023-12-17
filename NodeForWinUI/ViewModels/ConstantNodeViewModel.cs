using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NodeForWinUI.Models;

namespace NodeForWinUI.ViewModels;
public partial class ConstantNodeViewModel : NodeViewModel
{

    [ObservableProperty]
    public double _inputValue;

    public ConstantNodeViewModel(ConstantNode constantNode)
        : base(constantNode)
    {
        InputValue = constantNode.InputValue;
    }

}
