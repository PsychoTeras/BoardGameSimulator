namespace BoardGameSimulator.Controls.Map.ItemElements
{
    public interface IItemElement
    {
        ItemElementType ElementType { get; }
        object UserObject { get; set; }
    }
}
