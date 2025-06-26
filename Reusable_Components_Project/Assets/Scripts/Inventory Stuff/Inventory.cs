using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private float _maxWeight;
    [SerializeField] private int _maxItemCount;

    [SerializeField] private InventoryUI _inventoryUI;

    private readonly List<Item> _items = new();
    private Transform _ownerTransform;

    /// <summary>
    /// List met elk item die in de inventory zit
    /// </summary>
    public List<Item> Items => _items; 
    /// <summary>
    /// Maximale aantal gewicht die in de inventory mogen zitten
    /// </summary>
    public float MaxWeight { get => _maxWeight; set => _maxWeight = value; }
    /// <summary>
    /// Maximale aantal items die in de inventory mogen zitten
    /// </summary>
    public int MaxItemCount { get => _maxItemCount; set => _maxItemCount = value; }

    public void Init(Transform pTransform)
    {
        _items.Clear();
        UpdateInventory();

        _ownerTransform = pTransform;        
    }
    /// <summary>
    /// Update de inventorybehaviour van elk item die in de inventory zit
    /// </summary>
    public void UpdateInventory()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            Item item = _items[i];
            item.Pickable.OnPickedUpdate?.Invoke();
        }

        //if statement die checkt of er UI is voor de inventory
        if (_inventoryUI != null && _inventoryUI.enabled) 
            _inventoryUI.CheckActivate(this);
    }
    /// <summary>
    /// Voegt een item toe aan de inventory
    /// </summary>
    /// <param name="pItem">De item die toegevoegd moet worden</param>
    public void AddItem(Item pItem)
    {
        Pickable pickable = pItem.Pickable;

        if (pItem.Pickable == null)
            return;

        if (GetTotalWeight() + pickable.ItemWeight >= _maxWeight || _items.Count >= _maxItemCount)
            return;

        _items.Add(pItem);
        pItem.Inventory = this;

        pickable.OnPicked?.Invoke();
        pItem.gameObject.SetActive(false);
    }
    /// <summary>
    /// pakt een random item van de inventory
    /// </summary>
    /// <returns>de random item</returns>
    public Item GetRandomItem()
    {
        int random = Random.Range(0, _items.Count);
        return _items[random];
    }
    /// <summary>
    /// Haalt elk item weg en zet ze terug op de spawnpoint
    /// </summary>
    public void RemoveAllItems()
    {
        for (int i = _items.Count - 1; i >= 0; i--)
        {
            Item item = _items[i];
            item.gameObject.SetActive(true);
            _items.RemoveAt(i);
            item.Inventory = null;
            item.Pickable.OnPutdown?.Invoke();
        }

        if (_inventoryUI != null)
            _inventoryUI.UpdateUI(this);
    }
    /// <summary>
    /// Haalt een bepaald item weg en zet ze neer op een bepaalde positie
    /// </summary>
    /// <param name="pItem">item die neergezet moet worden</param>
    public void RemoveItem(Item pItem)
    {
        if (_items.Contains(pItem))
        {
            _items.Remove(pItem);
            Pickable pickable = pItem.Pickable;

            pickable.OnPutdown?.Invoke();
            pItem.Inventory = null;

            Quaternion rotation = Quaternion.LookRotation(_ownerTransform.forward) * pItem.transform.rotation;

            pItem.gameObject.transform.SetPositionAndRotation(GetPosition(pItem), rotation);
            pItem.gameObject.SetActive(true);

            if (_inventoryUI != null)
                _inventoryUI.UpdateUI(this);
        }
    }
    /// <summary>
    /// Functie die berekend hoeveel gewicht er in de inventory zit
    /// </summary>
    /// <returns>het aantal gewicht dat in de inventory zit</returns>
    private float GetTotalWeight()
    {
        float weight = 0;

        foreach (Item item in _items)
        {
            weight += item.Pickable.ItemWeight;
        }

        return weight;
    }
    /// <summary>
    /// Berekend de nieuwe positie van het object wanneer het is gedropt
    /// </summary>
    /// <param name="pItem">de item waarvan de nieuwe positie berekend moet worden</param>
    /// <returns>de nieuwe positie van de item</returns>
    private Vector3 GetPosition(Item pItem)
    {
        MeshRenderer renderer = pItem.gameObject.GetComponent<MeshRenderer>();

        float forwardOffset;
        float verticalOffset;

        if (renderer == null)
        {
            forwardOffset = pItem.transform.localScale.z;
            verticalOffset = pItem.transform.localScale.y / 2f;
        }
        else
        {
            forwardOffset = renderer.bounds.size.z;
            verticalOffset = renderer.bounds.size.y / 2f;
        }
       
        Vector3 spawnPosition = _ownerTransform.position +
                                (_ownerTransform.forward * forwardOffset) +
                                (Vector3.up * verticalOffset);

        return spawnPosition;
    }
}
