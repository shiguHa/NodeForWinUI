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
    private double width;

    [ObservableProperty]
    private double height;

    [ObservableProperty]
    private double name;

    [ObservableProperty]
    private double result;


    public ObservableCollection<object> In{get;}

    public NodeViewModel(NodeBase node)
    {
    
    }

}
