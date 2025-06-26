using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    //singleton omdat het dan aangeroepen word en er is maar 1 component hiervan nodig
    private static UIManager _uIManager;
    public static UIManager Instance => _uIManager;

    private void Awake()
    {
        _uIManager = this;
    }

    //achtergrond die laat zien dat de speler in ui modus zit
    [SerializeField] private GameObject _uiBackground;

    //event die word aangeroepen als UI modus word geactiveerd
    [SerializeField, Header("Events")] private UnityEvent _onUIModeEnable;

    //event die word aangeroepen als UI modus word gedeactiveerd
    [SerializeField] private UnityEvent _onUIModeDisable;

    //event die word aangeroepen als UI modus word veranderd
    [SerializeField] private UnityEvent<bool> _onUIModeChange;

    //bool die bijhoud of UI modus is geactiveerd
    private bool _activated = false;
    public bool Activated => _activated;
    public UnityEvent OnUIModeEnable => _onUIModeEnable;
    public UnityEvent OnUIModeDisable => _onUIModeDisable;
    public UnityEvent<bool> OnUIModeChange => _onUIModeChange;
    private void Start()
    {
        _onUIModeChange.AddListener(SetBackground);
        _onUIModeChange.AddListener(SetCursorState);
    }
    /// <summary>
    /// zet de UI achtergrond aan of uit
    /// </summary>
    /// <param name="pValue">bool die bepaalt of de UI mode aan of uit moet</param>
    public void ToggleUIMode(bool pValue)
    {
        //zoekt alle components op (de true zorgt ervoor dat components die uit staan ook worden meegerekend)
        MonoBehaviour[] allMonoBehaviours = FindObjectsOfType<MonoBehaviour>(true);

        foreach (MonoBehaviour mono in allMonoBehaviours)
        {
            if (mono is IPausable)
            {
                mono.enabled = !pValue;
            }
        }
        
        _activated = pValue;
        CheckEvent();
    }
    /// <summary>
    /// Checkt welke events er moeten worden aangeroepen
    /// </summary>
    private void CheckEvent()
    {
        switch (_activated)
        {
            case true:
                _onUIModeEnable.Invoke(); break;
            case false:
                _onUIModeDisable.Invoke(); break;
        }

        _onUIModeChange.Invoke(_activated);
    }
    /// <summary>
    /// zet achtergrond aan of uit
    /// </summary>
    /// <param name="pValue">bool die bepaald of die aan of uit gaat</param>
    private void SetBackground(bool pValue)
    {
        if (_uiBackground != null) 
        _uiBackground.SetActive(_activated);
    }
    /// <summary>
    /// functie die checkt wat de current mousestate moet zijn
    /// </summary>
    /// <param name="pValue"></param>
    private void SetCursorState(bool pValue)
    {
        switch (_activated)
        {
            case true:
                Cursor.lockState = CursorLockMode.None; break;
            case false:
                Cursor.lockState = CursorLockMode.Locked; break;
        }

        Cursor.visible = _activated;
    }
    
}
