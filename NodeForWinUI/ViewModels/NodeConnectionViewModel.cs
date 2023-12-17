using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using NodeForWinUI.Models;

namespace NodeForWinUI.ViewModels;
public partial class NodeConnectionViewModel : ObservableObject
{
    #region プロパティ
    [ObservableProperty]
    private double _lineFromX;

    [ObservableProperty]
    private double _lineFromY;

    [ObservableProperty]
    private double _lineToX;

    [ObservableProperty]
    private double _lineToY;

    [ObservableProperty]
    private string _beziePathData;

    [ObservableProperty]
    private Visibility _visible;


    public NodeViewModel Parent
    {
        get; private set;
    }

    public NodeConnectModel InnerModel
    {
        get; private set;
    }

    #endregion

    public NodeConnectionViewModel(NodeViewModel node, NodeConnectModel nodeConnectModel)
    {
        Parent = node;

    }


    private void UpdateBeziePathData()
    {
        BeziePathData = $"M {LineFromX},{LineFromY} C {LineFromX},{LineToY} {LineToX},{LineFromY} {LineToX},{LineToY}";
    }

    public void Docking(NodeConnectionViewModel nodeConnectionViewModel)
    {

        if (nodeConnectionViewModel is NodeInConnectionViewModel)
        {

        }
        else if (nodeConnectionViewModel is NodeOutConnectionViewModel)
        {


        }
    }

    partial void OnLineFromXChanged(double value) => UpdateBeziePathData();
    partial void OnLineFromYChanged(double value) => UpdateBeziePathData();
    partial void OnLineToXChanged(double value) => UpdateBeziePathData();
    partial void OnLineToYChanged(double value) => UpdateBeziePathData();
}


public class NodeInConnectionViewModel : NodeConnectionViewModel
{
    public NodeInConnectionViewModel(NodeViewModel Node, NodeConnectModel nodeConnectModel)
        : base(Node, nodeConnectModel)
    {

    }

}

public class NodeOutConnectionViewModel : NodeConnectionViewModel
{
    public NodeOutConnectionViewModel(NodeViewModel Node, NodeConnectModel nodeConnectModel)
       : base(Node, nodeConnectModel)
    {
    }

}

public partial class NodeFixedConnectionViewModel : ObservableObject
{

    [ObservableProperty]
    private double _lineFromX;

    [ObservableProperty]
    private double _lineFromY;

    [ObservableProperty]
    private double _lineToX;

    [ObservableProperty]
    private double _lineToY;

    [ObservableProperty]
    private string _beziePathData;

    [ObservableProperty]
    private Visibility _visible;

    public SolidColorBrush Color { get; } = new SolidColorBrush(Colors.DarkGray);

    protected NodeViewModel Parent;
    private List<IDisposable> disposables = new List<IDisposable>();

    public NodeConnectModel InnerModel
    {
        get; private set;
    }

    public NodeFixedConnectionViewModel(NodeViewModel Node, NodeConnectModel nodeConnectModel)
    {
        Parent = Node;
        InnerModel = nodeConnectModel;

        LineFromX = 0;
        LineFromY = 0;
        LineToX = 0;
        LineToY = 0;
    }
}
