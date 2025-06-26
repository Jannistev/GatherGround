using TMPro;
using UnityEngine;
/// <summary>
/// optionele UI voor de pickablecounter
/// </summary>
public class PickableCounterUI : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private TMP_Text _amountText;

    public void UpdateUI(PickableCounter pPickableCounter)
    {
        _amountText.text = $"{_text}{pPickableCounter.Amount.ToString()} / {pPickableCounter.AmountNeeded}";
    }
}
