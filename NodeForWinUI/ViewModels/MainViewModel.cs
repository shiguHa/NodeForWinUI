using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NodeForWinUI.Models;

namespace NodeForWinUI.ViewModels;

//https://www.ayumax.net/entry/2019/05/13/190518/
//https://github.com/ayumax/NodeCalculator/blob/master/NodeCalculator/Models/NodeBase.cs
//https://tech.drecom.co.jp/ac2020-wpf-node-editor/
//https://github.com/p4j4dyxcry/TsNode


public partial class MainViewModel : ObservableRecipient
{

    public NodeNetworkViewModel NodeNetwork = new();

    public MainViewModel()
    {
        var constantNode1 = new ConstantNodeViewModel(new ConstantNode()
        {
            InputValue = 1,
            X = 0,
            Y = 0,
            Width = 100,
            Height = 200
        });

        var constantNode2 = new ConstantNodeViewModel(new ConstantNode()
        {
            InputValue = 2,
            X = 300,
            Y = 300,
            Width = 100,
            Height = 100
        });

        NodeNetwork.Nodes.Add(constantNode1);
        NodeNetwork.Nodes.Add(constantNode2);

        constantNode2.AddInputConnector();

        var connectionViewModel = new NodeConnectionViewModel();
        connectionViewModel.Connect( constantNode1.Outputs[0], constantNode2.Inputs[2]);

        NodeNetwork.Connections.Add(connectionViewModel);

    }
}
