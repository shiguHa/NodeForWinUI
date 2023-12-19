using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using NodeForWinUI.Models;
using Windows.Devices.Input;

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
    private Visibility _visible = Visibility.Visible;

    private NodeConnectorModel Connector1;

    private NodeConnectorModel Connector2;

    public SolidColorBrush Color { get; } = new SolidColorBrush(Colors.Red);


    public NodeConnectionModel InnerModel
    {
        get; private set;
    }

    #endregion

    public NodeConnectionViewModel(NodeConnectionModel nodeConnectionModel)
    {
        InnerModel = nodeConnectionModel;
    }

    public void Connect(NodeConnectorModel connector1, NodeConnectorModel connector2)
    {
        Connector1 = connector1;
        Connector2 = connector2;


        UpdateBeziePathData();
    }


    private void UpdateBeziePathData()
    {
        const double connectorDiameter = 15;

        var node1 = Connector1.EquippedNode;
        var node2 = Connector2.EquippedNode;

        var connector1MiddleX = CalculateMiddleX(node1, Connector1.IsInput);
        var connector1MiddleY = CalculateMiddleY(node1, Connector1);
        var connector2MiddleX = CalculateMiddleX(node2, Connector2.IsInput);
        var connector2MiddleY = CalculateMiddleY(node2, Connector2);

        var connectorCount1 = Connector1.IsInput ? node1.Inputs.Count() : node1.Outputs.Count();
        var connectorCount2 = Connector2.IsInput ? node2.Inputs.Count() : node2.Outputs.Count();

        double connector1Offset = CalculateOffset(connectorCount1, node1.ConnectorSpaceing, connectorDiameter, Connector1.ConnectIndex);
        double connector2Offset = CalculateOffset(connectorCount2, node2.ConnectorSpaceing, connectorDiameter, Connector2.ConnectIndex);

        connector1MiddleX += connector1Offset;
        connector2MiddleX += connector2Offset;

        BeziePathData = $"M {connector1MiddleX},{connector1MiddleY} C {connector1MiddleX},{connector2MiddleY} {connector2MiddleX},{connector1MiddleY} {connector2MiddleX},{connector2MiddleY}";
    }


    private double CalculateMiddleX(NodeBase node, bool isInput)
    {
        return node.X + node.Width / 2;
    }

    private double CalculateMiddleY(NodeBase node, NodeConnectorModel connector)
    {
        return node.Y + (connector.IsInput ? 0 : node.Height);
    }

    private double CalculateOffset(int connectorCount, double spacing, double diameter, double connectIndex)
    {
        if (connectorCount <= 1)
            return 0;

        double offset = spacing / 2 + diameter / 2;
        double middleIndex = connectorCount / 2;

        if (connectorCount > 2 && connectIndex == middleIndex)
            return 0;
        else if (connectIndex < middleIndex)
            return -(connectorCount - connectIndex - 1) * offset;
        else
            return (connectorCount - connectIndex + 1) * offset;
    }



    partial void OnLineFromXChanged(double value) => UpdateBeziePathData();
    partial void OnLineFromYChanged(double value) => UpdateBeziePathData();
    partial void OnLineToXChanged(double value) => UpdateBeziePathData();
    partial void OnLineToYChanged(double value) => UpdateBeziePathData();
}

