using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// component die ervoor zorgt dat alle behaviours van de platform worden geupdate
/// </summary>
public class Platform : MonoBehaviour
{
    //list met alle behaviours
    private readonly List<IPlatformBehaviour> _behaviours = new();

    private ObjectFinder _objectFinder;
    public ObjectFinder ObjectFinder => _objectFinder;

    private void Start()
    {
        _behaviours.AddRange(GetComponents<IPlatformBehaviour>().ToList());
        _objectFinder = GetComponent<ObjectFinder>();
    }
    private void Update()
    {
        if (_objectFinder != null)
        {
            UpdatePlatform();
        }
    }
    /// <summary>
    /// update elk behaviour van de platform en geeft de objectfinder mee
    /// </summary>
    private void UpdatePlatform()
    {
        for (int i = 0; i < _behaviours.Count; i++)
        {
            _behaviours[i].PlatformUpdate(_objectFinder);
        }
    }
    /// <summary>
    /// zoekt naar een bepaalde platform behaviour 
    /// </summary>
    /// <typeparam name="T">bepaalde behaviour waar je naar zoekt</typeparam>
    /// <returns>de gevonden behaviour of null</returns>
    public T GetBehaviour<T>() where T : class, IPlatformBehaviour
    {
        foreach (IPlatformBehaviour platformBehaviour in _behaviours)
        {
            if (platformBehaviour is T behaviour)
            {
                return behaviour;
            }
        }

        return null;
    }
}
