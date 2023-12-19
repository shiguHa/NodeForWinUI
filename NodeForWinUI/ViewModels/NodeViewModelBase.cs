using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using NodeForWinUI.Models;

namespace NodeForWinUI.ViewModels;


public partial class NodeViewModelBase : ObservableRecipient
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
    private int _connectorSpaceing;

    public ObservableCollection<NodeConnectorModel> Inputs { get; private set; } = new ObservableCollection<NodeConnectorModel>();

    public ObservableCollection<NodeConnectorModel> Outputs { get; private set; } = new ObservableCollection<NodeConnectorModel>();


    public NodeBase InnerModel
    {
        get; private set;
    }


    public NodeViewModelBase(NodeBase node)
    {
        InnerModel = node;
        X = InnerModel.X;
        Y = InnerModel.Y;
        Width = InnerModel.Width;
        Height = InnerModel.Height;
        Name = InnerModel.Name;
        ConnectorSpaceing = InnerModel.ConnectorSpaceing;


        InnerModel.PropertyChanged += (s, e) =>
        {

            switch (e.PropertyName)
            {
                case nameof(InnerModel.X):
                    X = InnerModel.X;
                    break;
                case nameof(InnerModel.Y):
                    Y = InnerModel.Y;
                    break;
                case nameof(InnerModel.Width):
                    Width = InnerModel.Width;
                    break;
                case nameof(InnerModel.Height):
                    Height = InnerModel.Height;
                    break;
                case nameof(InnerModel.Name):
                    Name = InnerModel.Name;
                    break;
                case nameof(InnerModel.ConnectorSpaceing):
                    ConnectorSpaceing = InnerModel.ConnectorSpaceing;
                    break;
            };
        };

        InnerModel.Inputs.CollectionChanged += (s, e) =>
        {
            Inputs = (ObservableCollection<NodeConnectorModel>)s;
        };

        InnerModel.Outputs.CollectionChanged += (s, e) =>
        {
            Outputs = (ObservableCollection<NodeConnectorModel>)s;
        };


        AddInputConnector();
        AddInputConnector();
        AddOutputConnector();
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
