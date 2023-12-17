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

    public ObservableCollection<NodeViewModel> Nodes;

    public MainViewModel()
    {
        Nodes = new ObservableCollection<NodeViewModel>()
        {
            new ConstantNodeViewModel(new ConstantNode() {InputValue=211}),

        };

        Nodes[0].X = 200;
        Nodes[0].Y = 300;
        Nodes[0].Width= 100;
        Nodes[0].Height = 100;
    }
}
