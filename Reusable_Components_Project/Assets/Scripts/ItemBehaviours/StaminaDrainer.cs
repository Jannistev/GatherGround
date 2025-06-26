using System;
using UnityEngine;

/// <summary>
/// Component die ervoor zorgt dat je stamina ietsjes sneller gedrained word
/// </summary>
public class StaminaDrainer : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }


    private IStaminaMovement _movement;

    [SerializeField] private float _decreaseForce = 1;

    public void InventoryBehaviour()
    {
       _movement.Stamina -= Time.deltaTime * _decreaseForce;
    }

    public void ItemInteraction() { }
    public void PickedUp()
    {
        //zoekt door de hele hierarchy voor de player component
        Player player = FindObjectOfType<Player>();

        //zoekt van het gevonden object de IStaminaMovement Interface
        _movement = player.GetComponent<IStaminaMovement>();

        if (_movement == null)
            throw new Exception("No Stamina movement component found to drain");
    }
    public void PutDown() { }
}
