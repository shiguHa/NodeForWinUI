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

    //private void UpdateBeziePathData()
    //{
    //    BeziePathData = $"M {LineFromX},{LineFromY} C {LineFromX},{LineToY} {LineToX},{LineFromY} {LineToX},{LineToY}";
    //}

    private void UpdateBeziePathData()
    {

        const double connectorDiameter = 15;// このコード非常によくないけど仕方なく書いてる。

        var connector1Spacing = Connector1.EquippedNode.ConnectorSpaceing;
        var connector2Spacing = Connector2.EquippedNode.ConnectorSpaceing;

        var connector1MiddleX = Connector1.EquippedNode.X + Connector1.EquippedNode.Width / 2;
        var connector1MiddleY = Connector1.EquippedNode.Y + (Connector1.IsInput ? 0 : Connector1.EquippedNode.Height);
        var connector2MiddleX = Connector2.EquippedNode.X + Connector2.EquippedNode.Width / 2;
        var connector2MiddleY = Connector2.EquippedNode.Y + (Connector2.IsInput ? 0 : Connector2.EquippedNode.Height);

        // Calculate the offset based on the number of inputs and the connector spacing
        var connectorCount1 = Connector1.IsInput ? Connector1.EquippedNode.Inputs.Count() : Connector1.EquippedNode.Outputs.Count();
        var connectorCount2 = Connector2.IsInput ? Connector2.EquippedNode.Inputs.Count() : Connector2.EquippedNode.Outputs.Count();

        var connector1Offset = connector1Spacing / 2 + connectorDiameter / 2;
        var connector2Offset = connector2Spacing / 2 + connectorDiameter / 2;

        if (connectorCount1 > 1)
        {
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
            double middleIndex = connectorCount2 / 2;


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

