﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

    public ObservableCollection<NodeConnectorModel> Inputs { get; private set; } = new ObservableCollection<NodeConnectorModel>();

    public ObservableCollection<NodeConnectorModel> Outputs { get; private set; } = new ObservableCollection<NodeConnectorModel>();


    public NodeBase InnerModel
    {
        get; private set;
    }


    public NodeViewModel(NodeBase node)
    {
        InnerModel = node;
        Inputs.Add(new());
        Inputs.Add(new());
        Outputs.Add(new());

        InnerModel.Inputs.CollectionChanged += (s, e) =>
        {
            Inputs = (ObservableCollection<NodeConnectorModel>)s;
        };

        InnerModel.Outputs.CollectionChanged += (s, e) =>
        {
            Outputs = (ObservableCollection<NodeConnectorModel>)s;
        };
    }


    public void AddInputConnector()
    {
        InnerModel.AddInputConnector();
    }

    public void AddOutputConnector()
    {
        InnerModel.AddOutputConnector();
    }

    private void OnXChanged()
    {
           InnerModel.X = X;
     }
    private void OnYChanged()
    {
        InnerModel.Y = Y;
    }

    private void OnWidthChanged()
    {
        InnerModel.Width = Width;
    }

    private void OnHeightChanged()
    {
        InnerModel.Height = Height;
    }

}