using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NodeForWinUI.Models;

namespace NodeForWinUI.ViewModels;
public partial class NodeViewModel : ObservableRecipient
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

    [ObservableProperty]
    private double _result;


    public ObservableCollection<NodeInConnectionViewModel> InConnections{get;}

    public ObservableCollection<NodeOutConnectionViewModel> OutConnections{get;}

    public NodeBase InnerModel
    {
        get; private set;
    }

    public NodeViewModel(NodeBase node)
    {
        InnerModel = node;
        Width = 200;
        Height = 200;

        InConnections = new ObservableCollection<NodeInConnectionViewModel>();
        foreach (var prevNode in InnerModel.PrevNodes)
        {
            InConnections.Add(new NodeInConnectionViewModel(this, prevNode));
        }

        InnerModel.PrevNodes.CollectionChanged += (s, e) =>
        {
        
        };

        OutConnections = new ObservableCollection<NodeOutConnectionViewModel>();
        foreach (var nextNodes in InnerModel.NextNodes)
        {
            OutConnections.Add(new NodeOutConnectionViewModel(this, nextNodes));
        }
    }

    partial void OnXChanged(double value) => InnerModel.X = value;
    partial void OnYChanged(double value) => InnerModel.Y = value;

    partial void OnNameChanged(string value) => InnerModel.Name = value;


}
