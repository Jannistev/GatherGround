using UnityEngine;

[RequireComponent (typeof(Inventory))]
public class ItemPicker : MonoBehaviour, IPausable
{
    [SerializeField, Header("RaySettings")] private float _rayLength;
    [SerializeField] private float _radius;

    //inventory waar alle items in worden gedaan
    private Inventory _inventory;

    private bool _itemSelected;

    [SerializeField, Header("UI")] private ItemPickerUI _itemPickerUI;

    public float Radius { get => _radius; set => _radius = value; }
    public float RayLength { get => _rayLength; set => _rayLength = value; }
    public bool ItemSelected => _itemSelected;

    private void Start()
    {
        _inventory = GetComponent<Inventory>();
        _itemPickerUI = GetComponent<ItemPickerUI>();
    }
    /// <summary>
    /// Maakt een spherecast aan die checkt of die een item kan vinden
    /// </summary>
    /// <param name="pCamera">camera waarmee er word gecheckt in welke richting die moet gaan</param>
    public void CastRay(Camera pCamera)
    {
        _itemSelected = false;

        //geeft de gameobject terug die de spherecast heeft gevonden
        if (Physics.SphereCast(transform.position, _radius, pCamera.transform.rotation * Vector3.forward, out RaycastHit hit, _rayLength))
        {
            //print("Geraakt: " + hit.collider.name);

            //probeert de item component te pakken van dat bepaalde object en checkt of de item een pickable component heeft
            if (hit.collider.TryGetComponent(out Item item) && item.Pickable != null) 
            {
                OnItemFound(item);
            }
        }

        //update de UI van de itempicker als die bestaat
        if (_itemPickerUI != null)
            _itemPickerUI.UpdateCrosshair(_itemSelected);
    }
    /// <summary>
    /// Functie die word aangeroepen als de spherecast een item heeft gevonden met een pickable component
    /// </summary>
    /// <param name="pItem"></param>
    private void OnItemFound(Item pItem)
    {
        _itemSelected = true;

        if (Input.GetMouseButtonDown(0))
        {
            _inventory.AddItem(pItem);
        }
    }
}
