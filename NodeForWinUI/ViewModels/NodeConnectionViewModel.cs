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

    [ObservableProperty]
    private NodeConnectorModel _input;

    [ObservableProperty]
    private NodeConnectorModel _output;

    public SolidColorBrush Color { get; } = new SolidColorBrush(Colors.Red);


    public NodeConnectionModel InnerModel
    {
        get; private set;
    }

    #endregion

    public NodeConnectionViewModel(NodeConnectionModel nodeConnectionModel)
    {
        InnerModel = nodeConnectionModel;
        Visible = Visibility.Visible;
    }

    public void Connect(NodeConnectorModel src, NodeConnectorModel dst)
    {
        LineFromX = src.ConnectNode.X;
        LineFromY = src.ConnectNode.Y;
        LineToX = dst.ConnectNode.X;
        LineToY = dst.ConnectNode.Y;

        UpdateBeziePathData();
    }

    public void Connect(NodeViewModel src, NodeViewModel dst)
    {
        LineFromX = src.X;
        LineFromY = src.Y;
        LineToX = dst.X;
        LineToY = dst.Y;

        UpdateBeziePathData();
    }


    private void UpdateBeziePathData()
    {
        BeziePathData = $"M {LineFromX},{LineFromY} C {LineFromX},{LineToY} {LineToX},{LineFromY} {LineToX},{LineToY}";
    }



    partial void OnLineFromXChanged(double value) => UpdateBeziePathData();
    partial void OnLineFromYChanged(double value) => UpdateBeziePathData();
    partial void OnLineToXChanged(double value) => UpdateBeziePathData();
    partial void OnLineToYChanged(double value) => UpdateBeziePathData();
}

