using UnityEngine;

/// <summary>
/// Speler
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Rigidbody _rigid;

    private IMovement _movement;
    private ICamMovement _camMovement;
    private IUpForce _upForce;

    private Inventory _inventory;
    private ItemPicker _itemPicker;
    private FallChecker _fallChecker;
    private SpawnPointSetter _spawnPointSetter;

    public IMovement Movement { get => _movement; set => _movement = value; }
    public ICamMovement CamMovement { get => _camMovement; set => _camMovement = value; }
    public IUpForce Upforce { get => _upForce; set => _upForce = value; }


    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();

        _movement = GetComponent<IMovement>();
        _camMovement = GetComponent<ICamMovement>();
        _upForce = GetComponent<IUpForce>();

        _inventory = GetComponent<Inventory>();
        _itemPicker = GetComponent<ItemPicker>();
        _spawnPointSetter = GetComponent<SpawnPointSetter>();
        _fallChecker = GetComponent<FallChecker>();

        InitComponents();
    }
    private void InitComponents()
    {
        _inventory?.Init(transform);
        _camMovement?.Init(_camera);
    }

    private void Update()
    {
        print(_upForce.ToString());
        if (_movement != null && (_movement as MonoBehaviour).enabled)
            _movement.Move(_rigid);

        if (_camMovement != null && (_camMovement as MonoBehaviour).enabled)
            _camMovement.MoveCam(_camera);

        if (_upForce != null && (_upForce as MonoBehaviour).enabled)
            _upForce.Jump(_rigid);

        if (_inventory != null && (_inventory as Inventory).enabled)
            _inventory.UpdateInventory();

        if (_itemPicker != null && (_itemPicker as ItemPicker).enabled)
            _itemPicker.CastRay(_camera);
    }
}
