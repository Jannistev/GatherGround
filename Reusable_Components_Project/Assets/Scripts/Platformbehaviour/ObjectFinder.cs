using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    [Header("Boxcast Settings")]

    //boxsize
    private Vector3 _boxSize;
    //eventuele extra size van de platform
    [SerializeField] private Vector3 _extraSize;
    private Vector3 _totalSize;
    //offset van de platform
    [SerializeField] private Vector3 _offset;

    private void Start()
    {
        _boxSize = transform.localScale;
        _totalSize = _boxSize += _extraSize;
    }
    /// <summary>
    /// Gaat op zoek naar een bepaald component en haalt elk component op die er is gevonden tussen alle gameobjects
    /// </summary>
    /// <typeparam name="T">component waar die naar opzoek moet gaan</typeparam>
    /// <returns>alle gevonden objecten</returns>
    public T[] FindObjects<T>() where T : Component
    {
        List<T> foundComponents = new(); //List waar alle components tijdelijk worden opgeslagen

        Vector3 position = transform.position + _offset; //positie van de overlapbox word berekend
        Collider[] hits = Physics.OverlapBox(position, _totalSize / 2f); //alle gameobjects die zijn gevonden worden opgeslagen

        foreach (Collider hit in hits) //loopt door elk gevonden object heen
        {
            //probeert in elk gevonden object de aangegeven component te vinden
            if (hit.TryGetComponent(out T component)) 
            {
                foundComponents.Add(component);
            }
        }

        return foundComponents.ToArray();
    }
}
