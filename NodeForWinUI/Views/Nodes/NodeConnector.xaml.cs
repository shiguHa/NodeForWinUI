using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NodeForWinUI.Views.Nodes;
public sealed partial class NodeConnector : UserControl
{

    public static readonly DependencyProperty ConnectorColorProperty =DependencyProperty.Register(
                        "ConnectorColor",
                        typeof(SolidColorBrush),
                        typeof(NodeConnector),
                        new PropertyMetadata(
                        new SolidColorBrush(Colors.DarkBlue),
                        ConnectorColorPropertyChanged));
    public SolidColorBrush ConnectorColor
    {
        get
        {
            return (SolidColorBrush)GetValue(ConnectorColorProperty);
        }
        set
        {
            SetValue(ConnectorColorProperty, value);
        }
    }


    private static void ConnectorColorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var thisInstance = d as NodeConnector;
        if (thisInstance != null)
        {
            thisInstance.Connector.Fill = e.NewValue as SolidColorBrush;
        }
    }



    public NodeConnector()
    {
        this.InitializeComponent();

        //

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as Button;
        var trans = this.TransformToVisual(Connector);
        var point = trans.TransformPoint(new Point(0, 0));
    }
}
