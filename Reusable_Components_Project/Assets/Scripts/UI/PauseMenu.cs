using UnityEngine;

/// <summary>
/// component die zorgt voor de pausemenu
/// </summary>
public class PauseMenu : MonoBehaviour
{
    //key om pausemenu mee te openen
    [SerializeField] private KeyCode _key;

    //panel die word gedactiveerd
    [SerializeField] private GameObject _panel;

    //bool die bijhoudt of de panel is geactiveerd
    private bool _activated = false;

    private void Start()
    {
        _panel.SetActive(false);

    }
    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            TogglePanel();
        }
    }
    /// <summary>
    /// functie die panel aan of uit zet
    /// </summary>
    public void TogglePanel()
    {
        _activated = !_panel.activeSelf;
        UIManager.Instance.ToggleUIMode(_activated);
        _panel.SetActive(_activated);
    }
}
