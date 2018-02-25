using System;
using BoardGameSimulator.Controls.Map.ItemControls;

namespace BoardGameSimulator.Controls.Map.ItemPainters
{
    internal interface IItemPainter : IComparable<IItemPainter>, IDisposable
    {
        string Name { get; }
        void UpdateLinkPoints(MapItem item, ItemLinkPoint[] linkPoints);
        void Paint(MapItem item, ItemControls.ItemScrollBar scrollBar, 
            ItemLinkPoint[] linkPoints);
    }
}
