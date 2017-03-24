using System.Windows;
using Northwoods.GoXam;

namespace SequenceDiagramViewer.SequenceDiagramControl
{
    public class BarRoute : Route
    {
        public override Point GetLinkPoint(Node node, FrameworkElement port, Spot spot, bool from,
                                           bool ortho, Node othernode, FrameworkElement otherport)
        {
            Point p = node.GetElementPoint(port, Spot.Center);
            Rect r = new Rect(node.GetElementPoint(port, Spot.TopLeft),
                              node.GetElementPoint(port, Spot.BottomRight));
            Point op = othernode.GetElementPoint(otherport, Spot.Center);

            LinkData data = this.Link.Data as LinkData;
            double y = (data != null ? ConvertTimeToY(data.Time) : 0);

            bool right = op.X > p.X;
            double dx = ActivityWidth / 2;
            if (from)
            {
                Group grp = node as Group;
                if (grp != null)
                {
                    // see if there is an Activity Node at this point -- if not, connect the link directly with the Group's lifeline
                    bool found = false;
                    foreach (Node mem in grp.MemberNodes)
                    {
                        NodeData d = mem.Data as NodeData;
                        if (d != null && d.Location.Y <= y && y <= d.Location.Y + d.Length)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) dx = 0;
                }
            }
            double x = right ? p.X + dx : p.X - dx;
            return new Point(x, y);
        }

        protected override double GetLinkDirection(Node node, FrameworkElement port, Point linkpoint, Spot spot,
                                                   bool from, bool ortho, Node othernode, FrameworkElement otherport)
        {
            Point p = node.GetElementPoint(port, Spot.Center);
            Point op = othernode.GetElementPoint(otherport, Spot.Center);
            bool right = op.X > p.X;
            return right ? 0 : 180;
        }

        public static double ConvertTimeToY(double t)
        {
            return t * MessageSpacing + LineStart;
        }

        // some parameters
        public static double LineStart = 30;  // vertical starting point in document for all Messages and Activations
        public static double LineTrail = 40;  // vertical extension of lifeline beyond all Activities
        public static double MessageSpacing = 20;  // vertical distance between Messages at different steps
        public static double ActivityInset = 3;  // vertical distance from the top or bottom that the links connect at
        public static double ActivityWidth = 15;  // width of each vertical activity bar
    }
}
