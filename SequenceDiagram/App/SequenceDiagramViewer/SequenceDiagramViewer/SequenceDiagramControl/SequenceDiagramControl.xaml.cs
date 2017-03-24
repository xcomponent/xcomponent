using System;
using System.Linq.Dynamic;
using System.Windows;
using System.Windows.Controls;
using Northwoods.GoXam;
using Northwoods.GoXam.Model;

namespace SequenceDiagramViewer.SequenceDiagramControl
{
    /// <summary>
    /// Interaction logic for SequenceDiagramControl.xaml
    /// </summary>
    public partial class SequenceDiagramControl : UserControl
    {
        private ILinkSelector _iLinkSelector;
        public SequenceDiagramControl()
        {
            InitializeComponent();
            DataContextChanged += delegate (object sender, DependencyPropertyChangedEventArgs args)
            {
                if (DataContext is GraphLinksModel<NodeData, String, String, LinkData>)
                {
                    myDiagram.Model = DataContext as GraphLinksModel<NodeData, String, String, LinkData>;
                    _iLinkSelector = DataContext as ILinkSelector;
                }
            };

            myDiagram.SelectionChanged += MyDiagram_SelectionChanged;
        }

        private void MyDiagram_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!e.AddedItems.Any())
            {
                return;
            }

            if (e.AddedItems[0] is Link)
            {
                if (_iLinkSelector != null)
                {
                    _iLinkSelector.OnLinkSelected(((Link)e.AddedItems[0]).Data as LinkData);
                }
            }
        }
    }
}
