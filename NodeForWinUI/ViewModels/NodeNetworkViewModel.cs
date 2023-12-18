using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NodeForWinUI.ViewModels;
public partial class NodeNetworkViewModel : ObservableRecipient
{
    public ObservableCollection<NodeViewModelBase> Nodes
    {
        get; private set;
    } = new ObservableCollection<NodeViewModelBase>();

    public ObservableCollection<NodeConnectionViewModel> Connections
    {
        get; private set;
    } = new ObservableCollection<NodeConnectionViewModel>();


    public NodeNetworkViewModel()
    {

    }

    [RelayCommand]
    private void ForDebug()
    {

    }

}
