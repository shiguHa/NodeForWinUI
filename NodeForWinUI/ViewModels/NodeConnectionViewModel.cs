using System;
using System.Collections;
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

        const double connectorDiameter = 15;// このコード非常によくないけど仕方なく書いてる。

        var node1 = Connector1.EquippedNode;
        var node2 = Connector2.EquippedNode;

        var connector1MiddleX = node1.X + node1.Width / 2;
        var connector1MiddleY = node1.Y + (Connector1.IsInput ? 0 : node1.Height);
        var connector2MiddleX = node2.X + node2.Width / 2;
        var connector2MiddleY = node2.Y + (Connector2.IsInput ? 0 : node2.Height);

        var connectorCount1 = Connector1.IsInput ? node1.Inputs.Count() : node1.Outputs.Count();
        var connectorCount2 = Connector2.IsInput ? node2.Inputs.Count() : node2.Outputs.Count();

       
        if (connectorCount1 > 1)
        {
            var connector1Spacing = node1.ConnectorSpaceing;
            var connector1Offset = connector1Spacing / 2 + connectorDiameter / 2;
            double middleIndex = connectorCount1 / 2;

            if (connectorCount1 > 2 && Connector1.ConnectIndex == middleIndex)
            {
                //真ん中の場合はオフセットを考慮しない    
            }
            else if (Connector1.ConnectIndex < middleIndex)
            {
                // 前半
                connector1MiddleX -= (connectorCount1 - Connector1.ConnectIndex - 1) * connector1Offset;
            }
            else
            {
                //後半
                connector1MiddleX += (connectorCount1 - Connector1.ConnectIndex + 1) * connector1Offset;
            }
        }

        if (connectorCount2 > 1)
        {
            var connector2Spacing = node2.ConnectorSpaceing;
            double middleIndex = connectorCount2 / 2;
            var connector2Offset = connector2Spacing / 2 + connectorDiameter / 2;

            if (connectorCount2 > 2 && Connector2.ConnectIndex == middleIndex)
            {
                //真ん中の場合はオフセットを考慮しない    
            }
            else if (Connector2.ConnectIndex < middleIndex)
            {
                // 前半
                connector2MiddleX -= (connectorCount2- Connector2.ConnectIndex -1  ) * connector2Offset;
            }
            else
            {
                //後半
                connector2MiddleX += (connectorCount2 -Connector2.ConnectIndex +1 ) * connector2Offset;
            }
        }

        BeziePathData = $"M {connector1MiddleX},{connector1MiddleY} C {connector1MiddleX},{connector2MiddleY} {connector2MiddleX},{connector1MiddleY} {connector2MiddleX},{connector2MiddleY}";
    }





    partial void OnLineFromXChanged(double value) => UpdateBeziePathData();
    partial void OnLineFromYChanged(double value) => UpdateBeziePathData();
    partial void OnLineToXChanged(double value) => UpdateBeziePathData();
    partial void OnLineToYChanged(double value) => UpdateBeziePathData();
}

