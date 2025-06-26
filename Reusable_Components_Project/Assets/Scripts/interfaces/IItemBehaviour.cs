/// <summary>
/// Interface met methods die worden aangeroepen op elk Item
/// </summary>
public interface IItemBehaviour
{
    /// <summary>
    /// Item waarop de behaviour word gezet
    /// </summary>
    public Item Item { get; set; }
    /// <summary>
    /// Word altijd aangeroepen
    /// </summary>
    public void ItemInteraction();
    /// <summary>
    /// Word alleen aangeroepen als item in een inventory zit
    /// </summary>
    public void InventoryBehaviour();
    /// <summary>
    /// word aangeroepen als de item is opgepakt
    /// </summary>
    public void PickedUp();
    /// <summary>
    /// word aangeroepen als de item is neergezet
    /// </summary>
    public void PutDown();
}
