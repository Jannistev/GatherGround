using UnityEngine;

public class TestBehaviour1 : MonoBehaviour, IItemBehaviour 
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    public void InventoryBehaviour()
    {
        print("In Inventory");
    }

    public void InventoryBehaviour(Item pItem)
    {
        throw new System.NotImplementedException();
    }

    public void ItemInteraction()
    {
        print("Always");
    }

    public void PickedUp()
    {
        print("PickedUp");
    }

    public void PickedUp(Item pItem)
    {
        throw new System.NotImplementedException();
    }

    public void PutDown()
    {
        print("PutDown");
    }

    public void PutDown(Item pItem)
    {
        throw new System.NotImplementedException();
    }
}
