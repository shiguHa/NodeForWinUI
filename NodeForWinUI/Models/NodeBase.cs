using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeForWinUI.Models;
public abstract partial class NodeBase : ObservableObject
{
    [ObservableProperty]
    private double _x;

    [ObservableProperty]
    private double _y;

    [ObservableProperty]
    private double _width;

    [ObservableProperty]
    private double _height;

    [ObservableProperty]
    private string _name;

    public ObservableCollection<NodeConnectorModel> Inputs { get; } = new ObservableCollection<NodeConnectorModel>();

    public ObservableCollection<NodeConnectorModel> Outputs { get; } = new ObservableCollection<NodeConnectorModel>();

    public NodeBase()
    {

    }

    public void AddInputConnector()
    {
        Inputs.Add(new NodeConnectorModel(this)
        {
            ConnectIndex = Inputs.Count,
            IsInput = true,
        }) ;
    }

    public void AddOutputConnector()
    {
        Outputs.Add(new NodeConnectorModel(this)
        {
            ConnectIndex = Outputs.Count,
            IsInput = false,
        });
    }


}





//private void NodeBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
//{
//    if (e.PropertyName != nameof(Name))
//    {
//        Do(null);
//    }
//}

//public virtual double? Do(NodeBase? Caller)
//{
//    List<double?> results = new List<double?>();

//    for (int i = 0; i < PrevNodes.Count; ++i)
//    {
//        double? prevNodeResult = null;

//        var prevNode = PrevNodes[i];

//        if (prevNode.ConnectNode != null)
//        {
//            prevNodeResult = prevNode.ConnectNode.Result;
//            if (prevNodeResult == null)
//            {
//                prevNodeResult = prevNode.ConnectNode.Do(this);
//            }
//        }

//        results.Add(prevNodeResult);
//    }

//    Result = Calculate(results);

//    if (Caller == null)
//    {
//        foreach (var nextNode in NextNodes)
//        {
//            nextNode.ConnectNode?.Do(null);
//        }

//    }

//    return Result;
//}

//protected abstract double? Calculate(List<double?> PrevResults);



//public void ChangeConnectNodeNum(ObservableCollection<NodeConnectorModel> Nodes, int NewNodeNum)
//{
//    if (NewNodeNum < 0) return;

//    if (Nodes.Count > NewNodeNum)
//    {
//        while (Nodes.Count != NewNodeNum)
//        {
//            var lastNodeConnection = Nodes.Last();
//            if (lastNodeConnection.ConnectNode != null)
//            {
//                var lastNode = lastNodeConnection.ConnectNode;
//                var removeConnectionNodes = Nodes == PrevNodes ? lastNode.NextNodes : lastNode.PrevNodes;
//                RemoveTheReference(removeConnectionNodes, this);
//            }


//            Nodes.Remove(lastNodeConnection);
//        }
//    }
//    else
//    {
//        while (Nodes.Count != NewNodeNum)
//        {
//            Nodes.Add(new NodeConnectorModel()
//            {
//                ConnectIndex = Nodes.Count
//            });
//        }
//    }
//}

//public void RemoveTheReference(ObservableCollection<NodeConnectorModel> ConnectedNodes, NodeBase RemoveNode)
//{
//    foreach (var connectedNode in ConnectedNodes)
//    {
//        if (connectedNode.ConnectNode == RemoveNode)
//        {
//            connectedNode.ConnectNode = null;
//        }
//    }
//}
