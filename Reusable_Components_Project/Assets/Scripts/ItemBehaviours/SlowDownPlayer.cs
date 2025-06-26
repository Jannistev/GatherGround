using UnityEngine;

/// <summary>
/// Component die ervoor zorgt dat de speler langzamerhand langzamer word
/// </summary>
public class SlowDownPlayer : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }


    private IMovement _movement;

    [SerializeField] private float _decreaseTime;
    [SerializeField] private float _minSpeed;
    private float _startSpeed;

    public void InventoryBehaviour()
    {
       float speed = Time.deltaTime * (1 / _decreaseTime);
        _movement.MovementSpeed = Mathf.Clamp(_movement.MovementSpeed - speed, _minSpeed, _startSpeed);
    }

    public void ItemInteraction()
    {
        return; 
    }

    public void PickedUp()
    {
        Player player = FindObjectOfType<Player>();
        _movement = player.Movement;

        if (_movement == null)
            throw new System.Exception("no component to decrease speed");

        _startSpeed = _movement.MovementSpeed;
    }

    public void PutDown()
    {
        _movement.MovementSpeed = _startSpeed;
    }
}
