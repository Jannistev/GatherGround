using UnityEngine; 

/// <summary>
/// Component die ervoor zorgt dat je jump word gelimiteerd
/// </summary>
public class JumpDisabler : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }


    private IUpForce _upForce;

    [SerializeField] private float _newJumpForce;

    public float NewJumpForce { get => _newJumpForce; set => _newJumpForce = value; }

    private float _startForce;
    public void InventoryBehaviour()
    {
       
    }

    public void ItemInteraction()
    {
        
    }

    public void PickedUp()
    {
        //zoekt naar de speler
        Player player = FindObjectOfType<Player>();
        _upForce = player.Upforce;

        if (_upForce == null)
            throw new System.Exception("no upforce component found to disable");

        _startForce = _upForce.JumpForce;
        _upForce.JumpForce = _newJumpForce;
    }

    public void PutDown()
    {
       _upForce.JumpForce = _startForce;
    }
}
