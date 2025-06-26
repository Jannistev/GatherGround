using UnityEngine;

/// <summary>
/// Itembehaviour die ervoor zorgt dat random items uit je inventory worden gegooid
/// </summary>
public class ItemDropper : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    [SerializeField] private float _minTimeUntilDropItem;
    [SerializeField] private float _maxTimeUntilDropItem;

    private float _chosenTime;
    private float _time;
    public void InventoryBehaviour()
    {
        _time += Time.deltaTime;

        if (_time >= _chosenTime)
        {
            _time = 0;
            _chosenTime = GetTime();

            _item.Inventory.RemoveItem(_item.Inventory.GetRandomItem());
        }
    }

    public void ItemInteraction() { }
   
    public void PickedUp()
    {     
        _chosenTime = GetTime();    
    }

    public void PutDown() { }
    
    private float GetTime()
    {
        return Random.Range(_minTimeUntilDropItem, _maxTimeUntilDropItem);
    }
}
