using System;
using System.Xml.Linq;
using Northwoods.GoXam.Model;

namespace SequenceDiagramViewer.SequenceDiagramControl
{
    public class LinkData : GraphLinksModelLinkData<String, String>
    {
        public double Time
        {
            get { return _Time; }
            set
            {
                if (_Time != value)
                {
                    double old = _Time;
                    _Time = value;
                    RaisePropertyChanged("Time", old, value);
                }
            }
        }
        private double _Time = 0.0;

        public double Duration
        {
            get { return _Duration; }
            set
            {
                if (_Duration != value)
                {
                    double old = _Duration;
                    _Duration = value;
                    RaisePropertyChanged("Duration", old, value);
                }
            }
        }
        private double _Duration = 1.0;

        // write the extra property
        public override XElement MakeXElement(XName n)
        {
            XElement e = base.MakeXElement(n);
            e.Add(XHelper.Attribute("Time", this.Time, 0.0));
            e.Add(XHelper.Attribute("Duration", this.Duration, 1.0));
            return e;
        }

        // read the extra property
        public override void LoadFromXElement(XElement e)
        {
            base.LoadFromXElement(e);
            this.Time = XHelper.Read("Time", e, 0.0);
            this.Duration = XHelper.Read("Duration", e, 1.0);
        }

        public object Data { get; set; }
    }
}
