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
    private Visibility _visible = Visibility.Visible;

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
    }

    public void Connect(NodeConnectorModel src, NodeConnectorModel dst)
    {
        Input = src;
        Output = dst;

        LineFromX = src.EquippedNode.X;
        LineFromY = src.EquippedNode.Y;
        LineToX = dst.EquippedNode.X;
        LineToY = dst.EquippedNode.Y;

        UpdateBeziePathData();
    }

    //private void UpdateBeziePathData()
    //{
    //    BeziePathData = $"M {LineFromX},{LineFromY} C {LineFromX},{LineToY} {LineToX},{LineFromY} {LineToX},{LineToY}";
    //}

    private void UpdateBeziePathData()
    {
        var inputMiddleX = Input.EquippedNode.X + Input.EquippedNode.Width / 2;
        var inputMiddleY = Input.EquippedNode.Y + Input.EquippedNode.Height;
        var outputMiddleX = Output.EquippedNode.X + Output.EquippedNode.Width / 2;
        var outputMiddleY = Output.EquippedNode.Y;


        BeziePathData = $"M {inputMiddleX},{inputMiddleY} C {inputMiddleX},{outputMiddleY} {outputMiddleX},{inputMiddleY} {outputMiddleX},{outputMiddleY}";
    }



    partial void OnLineFromXChanged(double value) => UpdateBeziePathData();
    partial void OnLineFromYChanged(double value) => UpdateBeziePathData();
    partial void OnLineToXChanged(double value) => UpdateBeziePathData();
    partial void OnLineToYChanged(double value) => UpdateBeziePathData();
}

