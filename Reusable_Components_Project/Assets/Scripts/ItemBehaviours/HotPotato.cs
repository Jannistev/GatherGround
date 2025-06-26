using UnityEngine;

/// <summary>
/// Component die ervoor zorgt dat de item na een bepaalde tijd uit de inventory word gegooid
/// </summary>
public class HotPotato : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    [SerializeField] private float _timeToHold;
    private float _time;

    public void InventoryBehaviour()
    {
        _time += Time.deltaTime;

        if (_time >= _timeToHold)
        {
            _time = 0;
            _item.Inventory.RemoveItem(_item);
        }
    }
    public void ItemInteraction() { }
    public void PickedUp() { }
    public void PutDown() { }  
}
