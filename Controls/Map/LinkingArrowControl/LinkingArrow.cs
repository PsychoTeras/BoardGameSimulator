using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoardGameSimulator.Controls.Map.LinkingArrowControl
{
    internal class LinkingArrow : IDisposable
    {

#region Private members

        private const int LinkingArrowPen = 5;
        private readonly Pen _linkingArrowBorderPen;

#endregion

#region Properties

        public MapItem SourceItem { get; set; }
        public MapItem DestinationItem { get; set; }
        public Point EndPoint { get; set; }

        public LinkingArrowState State { get; private set; }

#endregion

#region Class functions

        public LinkingArrow(MapItem sourceItem, MapItem destinationItem,
            LinkingArrowState state)
        {
            SourceItem = sourceItem;
            DestinationItem = destinationItem;
            State = state;

            _linkingArrowBorderPen = new Pen(Color.White, LinkingArrowPen);
            _linkingArrowBorderPen.EndCap = LineCap.ArrowAnchor;
            _linkingArrowBorderPen.DashStyle = DashStyle.Dot;
            _linkingArrowBorderPen.DashCap = DashCap.Round;
            _linkingArrowBorderPen.DashOffset = 0.08f;
        }

        public void Link(MapItem destinationItem)
        {
            DestinationItem = destinationItem;
            State = LinkingArrowState.Linked;
        }

        public void Unlink()
        {
            DestinationItem = null;
            State = LinkingArrowState.Linking;
        }

        public void Draw(Graphics graphics, Point startPoint, Point endPoint)
        {
            if (State != LinkingArrowState.None)
            {
                graphics.DrawLine(_linkingArrowBorderPen, startPoint, endPoint);
            }
        }

        public void Dispose()
        {
            _linkingArrowBorderPen.Dispose();
        }

#endregion

    }
}
