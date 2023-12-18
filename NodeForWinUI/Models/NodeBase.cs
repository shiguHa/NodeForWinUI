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

