using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(GridLayoutGroup))]
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private KeyCode _openInventoryButton;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _textToSpawn;
    [SerializeField] private GameObject _object;

    private bool _activated = false;
    private readonly List<GameObject> _spawnedButtons = new();

    /// <summary>
    /// functie die checkt of de inventory geopend moet worden
    /// </summary>
    /// <param name="pInventory"></param>
    public void CheckActivate(Inventory pInventory)
    {
        if (Input.GetKeyDown(_openInventoryButton))
        {
            _activated = !_activated;
            UIManager.Instance.ToggleUIMode(_activated);
            _object.SetActive(_activated);
            
            if (_activated)
                UpdateUI(pInventory);
        }
    }
    /// <summary>
    /// toggled een bepaald gameobject
    /// </summary>
    /// <param name="pValue">bool die bepaald of die aan of uit moet</param>
    private void ToggleObject(bool pValue)
    {
        _activated = pValue;
        UIManager.Instance.ToggleUIMode(pValue);
        _object.SetActive(pValue);
    }
    /// <summary>
    /// Updated de aantal buttons in de inventory gebaseerd op hoeveel items er in de inventory zitten
    /// </summary>
    /// <param name="pInventory">de inventory</param>
    public void UpdateUI(Inventory pInventory)
    {
        DestroyButtons();

        foreach (Item item in pInventory.Items)
        {
            Button button = CreateButton(item.Pickable.ItemName);
            button.onClick.AddListener(() => pInventory.RemoveItem(item));
            button.onClick.AddListener(() => ToggleObject(false)); 
        }
    }
    /// <summary>
    /// Maakt een nieuwe button aan voor de UI
    /// </summary>
    /// <param name="pMessage">bericht die de knop moet weergeven</param>
    /// <returns>de gegenereerde button</returns>
    private Button CreateButton(string pMessage)
    {
        Button button = Instantiate(_button, transform);

        TMP_Text text = button.gameObject.GetComponentInChildren<TMP_Text>();
        text.text = pMessage;

        _spawnedButtons.Add(button.gameObject);

        return button;
    }
    /// <summary>
    /// verwijdert alle bestaande buttons
    /// </summary>
    private void DestroyButtons()
    {
        foreach (GameObject button in _spawnedButtons)
        {
            Destroy(button);
        }

        _spawnedButtons.Clear();
    }
}
