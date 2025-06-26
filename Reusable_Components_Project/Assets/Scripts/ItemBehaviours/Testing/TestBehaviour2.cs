using UnityEngine;

public class TestBehaviour2 : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    public void InventoryBehaviour()
    {
        print("dddddd");
    }

    public void ItemInteraction()
    {
        print("cccc");
    }

    public void PickedUp()
    {
        print("aaaaa");
    }

    public void PutDown()
    {
        print("bbbbbb");
    }
}
