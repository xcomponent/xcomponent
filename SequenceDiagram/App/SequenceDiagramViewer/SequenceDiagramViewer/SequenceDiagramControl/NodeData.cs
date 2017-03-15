using System;
using System.Xml.Linq;
using Northwoods.GoXam.Model;

namespace SequenceDiagramViewer.SequenceDiagramControl
{
    public class NodeData : GraphLinksModelNodeData<String>
    {
        public double Length
        {
            get { return _Length; }
            set
            {
                if (_Length != value)
                {
                    double old = _Length;
                    _Length = value;
                    RaisePropertyChanged("Length", old, value);
                }
            }
        }
        private double _Length = 100.0;

        // write the extra property
        public override XElement MakeXElement(XName n)
        {
            XElement e = base.MakeXElement(n);
            e.Add(XHelper.Attribute("Length", this.Length, 100.0));
            return e;
        }

        // read the extra property
        public override void LoadFromXElement(XElement e)
        {
            base.LoadFromXElement(e);
            this.Length = XHelper.Read("Length", e, 100.0);
        }
    }
}
