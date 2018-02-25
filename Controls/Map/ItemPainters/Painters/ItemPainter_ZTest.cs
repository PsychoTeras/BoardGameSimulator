using System.Drawing;
using System.Drawing.Drawing2D;
using BoardGameSimulator.Controls.Map.ItemControls;

namespace BoardGameSimulator.Controls.Map.ItemPainters.Painters
{
    internal sealed class ItemPainter_ZTest : ItemPainter_Base
    {
        public override void Paint(MapItem item, ItemControls.ItemScrollBar scrollBar,
            ItemLinkPoint[] linkPoints)
        {
            Rectangle rectangle = item.ClientRectangle;
            ItemPainterHelper.DrawRoundedRectangleShadow(item.Buffer,
                ref rectangle, CornerRadius, ShadowDistance, ShadowColor);

            Pen pen = new Pen(Color.FromArgb(255, Color.Green), 5);
            rectangle.Inflate(-(int)pen.Width, -(int)pen.Width);
            item.ItemRegion = ItemPainterHelper.CalculateRoundedRectangleGraphicsPath(
                rectangle, CornerRadius);

            pen.EndCap = pen.StartCap = LineCap.Flat;
            item.Buffer.DrawPath(pen, item.ItemRegion);
        }

        public override string Name
        {
            get { return null; }
        }
    }
}
