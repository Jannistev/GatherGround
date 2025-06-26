using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Component die ervoor zorgt dat je items kunt oppakken
/// </summary>
public class Pickable : MonoBehaviour
{
    [SerializeField, Header("Item Settings")] private string _itemName;
    [SerializeField] private float _itemWeight;
    [SerializeField] private float _worth;

    public float ItemWeight { get => _itemWeight; set => _itemWeight = value; }
    public float Worth { get => _worth; set => _worth = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }

    [Header("Events")]
    [SerializeField] private UnityEvent _onPicked;
    [SerializeField] private UnityEvent _onPutDown;
    [SerializeField] private UnityEvent _onPickedUpdate;
   
    public UnityEvent OnPicked { get => _onPicked; set => _onPicked = value; }
    public UnityEvent OnPutdown { get => _onPutDown; set => _onPutDown = value; }
    public UnityEvent OnPickedUpdate { get => _onPickedUpdate; set => _onPickedUpdate = value; }

}
