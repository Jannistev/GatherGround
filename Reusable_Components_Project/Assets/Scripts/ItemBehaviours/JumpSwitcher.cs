using UnityEngine;

public class JumpSwitcher : MonoBehaviour, IItemBehaviour
{
    private Item _item;
    public Item Item { get => _item; set => _item = value; }

    private Player _player;

    //Component naar waarmee de upforce van de player word geswapped
    private IUpForce _upForceToChange;
    //variabel waar de upforce van de speler word bewaard
    private IUpForce _savedUpForce;

    private void Start()
    {
        _upForceToChange = GetComponentInChildren<IUpForce>();
        _player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        //print("nullchecker: " + (_upForceToChange == null));
    }
    public void InventoryBehaviour() { }


    public void ItemInteraction() { }
 

    public void PickedUp()
    {
        //jumpforce word geswapped
        print("activated");
        _savedUpForce = _player.Upforce;
        _player.Upforce = _upForceToChange;
    }
   

    public void PutDown()
    {
        //jumpforce word terug gezet
        print("deactivated");
        _player.Upforce = _savedUpForce;
    }
   
}
