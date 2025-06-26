using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Randomizer die bepaalde behaviours randomized
/// </summary>
[RequireComponent(typeof(Item))]
public class BehaviourRandomizer : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    private IItemBehaviour _activeBehaviour;
    private List<IItemBehaviour> _allItemBehaviours = new();

    private void Start()
    {
        //haalt elk component op met de IItemBehaviour interface en stopt ze in de list
        _allItemBehaviours.AddRange(GetComponentsInChildren<IItemBehaviour>());

        foreach (IItemBehaviour behaviour in _allItemBehaviours)
        {
            behaviour.Item = _item;
        }
    }
    /// <summary>
    /// Update de random uitgekozen behaviour
    /// </summary>
    public void InventoryBehaviour()
    {
        _activeBehaviour.InventoryBehaviour();
    }
    /// <summary>
    /// word aangeroepen als het object is opgepakt
    /// </summary>
    public void PickedUp()
    {
        _activeBehaviour = GetRandomBehaviour();

        _activeBehaviour.PickedUp();
    }
    /// <summary>
    /// word aangeroepen als de object is neergezet
    /// </summary>
    public void PutDown()
    {
       _activeBehaviour.PutDown();
    }
    public void ItemInteraction() { }
    
    /// <summary>
    /// haalt een random behaviour op uit de list
    /// </summary>
    /// <returns>de random behaviour</returns>
    private IItemBehaviour GetRandomBehaviour()
    {
        int random = Random.Range(0, _allItemBehaviours.Count);

        return _allItemBehaviours[random];
    }

}
