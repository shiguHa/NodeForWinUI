using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace NodeForWinUI.Models;
public sealed partial class NodeConnectionModel : ObservableObject
{

    [ObservableProperty]
    private NodeConnectorModel _input;

    [ObservableProperty]
    private NodeConnectorModel _output;


}
