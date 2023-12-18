using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeForWinUI.Models;
public sealed partial class NodeConnectorModel: ObservableObject
{

    [ObservableProperty]
    private NodeBase? _equippedNode;

    [ObservableProperty]
    private int _connectIndex;

    [ObservableProperty]
    private bool _isConnected;

    [ObservableProperty]
    private bool _isInput;

    public NodeConnectorModel(NodeBase equippedNode)
    {
        EquippedNode = equippedNode;
      }
}

