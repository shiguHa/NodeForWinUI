using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeForWinUI.Models;
public sealed partial class ConstantNode : NodeBase
{

    [ObservableProperty]
    private double _inputValue = 0;


    public ConstantNode()
    {
    
         Name = "Constant";
    }

}
