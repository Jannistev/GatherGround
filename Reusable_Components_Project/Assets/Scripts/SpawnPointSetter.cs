
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// zorgt ervoor dat er een spawnpoint word gezet voor het object
/// </summary>
public class SpawnPointSetter : MonoBehaviour
{
    private Vector3 _spawnPoint;

    [SerializeField] private UnityEvent _onReturn;
    public UnityEvent OnReturn => _onReturn;
    public Vector3 SpawnPoint => _spawnPoint;
    private void Start()
    {
        _spawnPoint = transform.position;
    }
    /// <summary>
    /// zorgt ervoor dat het object retourneert naar de oorspronkelijke locatie
    /// </summary>
    public void ReturnToSpawn()
    {
        gameObject.transform.position = _spawnPoint;
        _onReturn?.Invoke();
    }
}
