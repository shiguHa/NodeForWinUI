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
            new ConstantNodeViewModel(new ConstantNode() {InputValue=1}),
            new ConstantNodeViewModel(new ConstantNode() {InputValue=2}),
        };

        Nodes[0].X = 0;
        Nodes[0].Y = 0;
        Nodes[0].Width= 200;
        Nodes[0].Height = 200;

        Nodes[1].X = 100;
        Nodes[1].Y = 300;
        Nodes[1].Width = 200;
        Nodes[1].Height = 200;

        


    }
}
