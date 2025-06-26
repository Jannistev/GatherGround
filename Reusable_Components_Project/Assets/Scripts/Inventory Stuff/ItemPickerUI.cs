using UnityEngine;
using UnityEngine.UI;

public class ItemPickerUI : MonoBehaviour
{
    //Image van de crosshair
    [SerializeField] private Image _crosshair;

    //sprite die word laten zien als er geen item is gevonden
    [SerializeField] private Sprite _normalCrosshair;
    //sprite die word laten zien als er een item is gevonden
    [SerializeField] private Sprite _selectedCrosshair;

    /// <summary>
    /// Functie die checkt welke sprite moet worden laten zien
    /// </summary>
    /// <param name="pCondition">de condition</param>
    public void UpdateCrosshair(bool pCondition)
    {
        switch (pCondition)
        {
            case true:
                _crosshair.sprite = _selectedCrosshair; break;
            case false:
                _crosshair.sprite = _normalCrosshair; break;
        }
    }
}
