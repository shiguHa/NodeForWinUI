using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeForWinUI.Models;
public partial class NodeConnectModel: ObservableObject
{

    [ObservableProperty]
    public NodeBase? _connectNode;

    [ObservableProperty]
    public int _connectIndex;

    public NodeConnectModel()
    {
    
       }
}

