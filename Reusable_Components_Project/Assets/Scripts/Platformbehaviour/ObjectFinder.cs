using System.Collections.Generic;
using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    [Header("Boxcast Settings")]

    //totale boxsize
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
    /// Gaat op zoek naar een bepaald component en haalt elk object op die die component bevat
    /// </summary>
    /// <typeparam name="T">component waar die naar opzoek moet gaan</typeparam>
    /// <returns>alle gevonden objecten</returns>
    public T[] FindObjects<T>() where T : Component
    {
        List<T> foundComponents = new();

        Vector3 position = transform.position + _offset;
        Collider[] hits = Physics.OverlapBox(position, _totalSize / 2f);

        foreach (Collider hit in hits)
        {
            if (hit.TryGetComponent(out T component))
            {
                foundComponents.Add(component);
            }
        }

        return foundComponents.ToArray();
    }
}
