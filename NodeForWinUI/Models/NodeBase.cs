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
    private string _name;

    [ObservableProperty]
    private double? _result;

    public ObservableCollection<NodeConnectModel> PrevNodes {get;} = new ObservableCollection<NodeConnectModel>();

    public ObservableCollection<NodeConnectModel> NextNodes { get; } = new ObservableCollection<NodeConnectModel>();

    public NodeBase()
    {
        this.PropertyChanged += NodeBase_PropertyChanged;

        PrevNodes.CollectionChanged += (s, e) => Do(null);
        NextNodes.CollectionChanged += (s, e) => Do(null);
    }

    private void NodeBase_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(Name))
        {
            Do(null);
        }
    }

    public virtual double? Do(NodeBase? Caller)
    {
        List<double?> results = new List<double?>();

        for (int i = 0; i < PrevNodes.Count; ++i)
        {
            double? prevNodeResult = null;

            var prevNode = PrevNodes[i];

            if (prevNode.ConnectNode != null)
            {
                prevNodeResult = prevNode.ConnectNode.Result;
                if (prevNodeResult == null)
                {
                    prevNodeResult = prevNode.ConnectNode.Do(this);
                }
            }

            results.Add(prevNodeResult);
        }

        Result = Culculate(results);

        if (Caller == null)
        {
            foreach (var nextNode in NextNodes)
            {
                nextNode.ConnectNode?.Do(null);
            }

        }

        return Result;
    }

    protected abstract double? Culculate(List<double?> PrevResults);



    public void ChangeConnectNodeNum(ObservableCollection<NodeConnectModel> Nodes, int NewNodeNum)
    {
        if (NewNodeNum < 0) return;

        if (Nodes.Count > NewNodeNum)
        {
            while (Nodes.Count != NewNodeNum)
            {
                var lastNodeConnection = Nodes.Last();
                if (lastNodeConnection.ConnectNode != null)
                {
                    var lastNode = lastNodeConnection.ConnectNode;
                    var removeConnectionNodes = Nodes == PrevNodes ? lastNode.NextNodes : lastNode.PrevNodes;
                    RemoveTheReference(removeConnectionNodes, this);
                }


                Nodes.Remove(lastNodeConnection);
            }
        }
        else
        {
            while (Nodes.Count != NewNodeNum)
            {
                Nodes.Add(new NodeConnectModel()
                {
                    ConnectIndex = Nodes.Count
                });
            }
        }
    }

    public void RemoveTheReference(ObservableCollection<NodeConnectModel> ConnectedNodes, NodeBase RemoveNode)
    {
        foreach (var connectedNode in ConnectedNodes)
        {
            if (connectedNode.ConnectNode == RemoveNode)
            {
                connectedNode.ConnectNode = null;
            }
        }
    }

}
