using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPausable
{   
    //component die checkt of de item oppakbaar moet zijn
    private Pickable _pickable;

    //component die de spawnpoint zet van de item
    private SpawnPointSetter _spawnSetter;

    //inventory waar de item in zit
    private Inventory _inventory;

    //list met elk behaviour van de item
    private readonly List<IItemBehaviour> _behaviours = new();

    [SerializeField] private float _minY = -40;

    public Inventory Inventory { get => _inventory; set => _inventory = value; }
    public Pickable Pickable => _pickable;
    public SpawnPointSetter SpawnSetter => _spawnSetter;

    private void Awake()
    {
        //elk gevonden IItemBehaviour word in de list gestopt
        _behaviours.AddRange(GetComponents<IItemBehaviour>());

        //bij elke IItemBehaviour word de item meegegeven
        foreach (IItemBehaviour behaviour in _behaviours)
        {
            behaviour.Item = this;
        }
    }
    private void Start()
    {
        _pickable = GetComponent<Pickable>();
        _spawnSetter = GetComponent<SpawnPointSetter>();
     
        if (_pickable != null)
        {
            _pickable.OnPicked.AddListener(ItemPickedUp);
            _pickable.OnPickedUpdate.AddListener(InteractInventoryItems);
            _pickable.OnPutdown.AddListener(ItemPutDown);
        }
    }
    private void Update()
    {
        UpdateBehaviours();

        if (_spawnSetter != null && transform.position.y <= _minY) 
            _spawnSetter.ReturnToSpawn();
    }
    /// <summary>
    /// update elk item
    /// </summary>
    private void UpdateBehaviours()
    {
        foreach (IItemBehaviour behaviour in _behaviours)
        {
            behaviour.ItemInteraction();
        }
    }   
    /// <summary>
    /// Zoekt naar een bepaalde itembehaviour
    /// </summary>
    /// <typeparam name="T">bepaalde behaviour waar je naar opzoek bent</typeparam>
    /// <returns>de gevonden behaviour of null</returns>
    public T GetBehaviour<T>() where T : class, IItemBehaviour
    {
        foreach (IItemBehaviour itemBehaviour in _behaviours)
        {
            if (itemBehaviour is T behaviour)
            {
                return behaviour;
            }
        }

        return null;
    }

    /// <summary>
    /// roept elk behaviour aan wanneer die in de inventory zit
    /// </summary>
    private void InteractInventoryItems()
    {
        foreach (IItemBehaviour behaviour in _behaviours)
        {
            behaviour.InventoryBehaviour();
        }
    }
    /// <summary>
    /// Roept van elk behaviour de pickup aan
    /// </summary>
    private void ItemPickedUp()
    {
        foreach (IItemBehaviour behaviour in _behaviours)
        {
            behaviour.PickedUp();
        }
    }
    /// <summary>
    /// roept van elke behaviour de putdown aan
    /// </summary>
    private void ItemPutDown()
    {
        foreach (IItemBehaviour behaviour in _behaviours)
        {
            behaviour.PutDown();
        }
    }

    /// <summary>
    /// kun je random behaviour toevoegen
    /// </summary>
    /// <param name="pBehaviour"></param>
    public void AddBehaviour(IItemBehaviour pBehaviour)
    {
        _behaviours.Add(pBehaviour);
    }
    /// <summary>
    /// kun je random behaviour removen
    /// </summary>
    /// <param name="pBehaviour"></param>
    public void RemoveBehaviour(IItemBehaviour pBehaviour)
    {
        _behaviours.Remove(pBehaviour);
    }
}