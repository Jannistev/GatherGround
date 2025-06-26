using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Checkt of het object onder een bepaald yLevel zit
/// </summary>
public class FallChecker : MonoBehaviour
{
    [SerializeField, Header("Settings")] private float _yLevel;

    //event die word aangeroepen als het object zich onder de ylevel bevind
    [SerializeField, Header("Events")] private UnityEvent _onFallen;

    public UnityEvent OnFallen => _onFallen;
   
    private void Update()
    {
        if (gameObject.transform.position.y <= _yLevel)
        {
            _onFallen?.Invoke();
        }
    }
}
