using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeForWinUI.ViewModels;
public class NodeNetworkViewModel
{
    public ObservableCollection<NodeViewModel> Nodes
    {
        get; private set;
    } = new ObservableCollection<NodeViewModel>();

    public ObservableCollection<NodeConnectionViewModel> Connections
    {
        get; private set;
    } = new ObservableCollection<NodeConnectionViewModel>();


    public NodeNetworkViewModel()
    {

    }
}
