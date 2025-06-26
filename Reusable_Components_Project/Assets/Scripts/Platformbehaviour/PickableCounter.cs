using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// platformbehaviour die telt hoeveel waarde aan items er op de platform ligt
/// </summary>
public class PickableCounter : MonoBehaviour, IPlatformBehaviour
{
    [Header("Money Settings")]
    [SerializeField] private float _amountNeeded; //aantal die je nodig hebt om een event te aanroepen
    [SerializeField] private UnityEvent _onSucceed;
    private bool _succeeded;
    private float _amount;

    [Header("UI")]
    [SerializeField] private PickableCounterUI pickCounterUI;

    public bool Succeeded => _succeeded;
    public UnityEvent OnSucceed => _onSucceed;
    public float AmountNeeded { get => _amountNeeded; set => _amountNeeded = value; }
    public float Amount => _amount;
  
    /// <summary>
    /// functie waarop de platform word geupdate
    /// </summary>
    /// <param name="pFinder">component die elk item kan zoeken</param>
    public void PlatformUpdate(ObjectFinder pFinder)
    {
        List<Pickable> pickables = pFinder.FindObjects<Pickable>().ToList();

       _amount = GetAmount(pickables);

        if (pickCounterUI != null && pickCounterUI.enabled)
            pickCounterUI.UpdateUI(this);

        if (!_succeeded)
            WinCheck();
    }  
    /// <summary>
    /// functie die berekend hvl geld er op de platform ligt
    /// </summary>
    /// <param name="pPickables"></param>
    /// <returns></returns>
    private float GetAmount(List<Pickable> pPickables)
    {
        float count = 0;

        foreach (Pickable p in pPickables)
        {
            count += p.Worth;
        }

        return count;
    }
    /// <summary>
    /// functie die checkt of de aantal genoeg is
    /// </summary>
    private void WinCheck()
    {
        if (_amount >= _amountNeeded)
        {
            _succeeded = true;
            _onSucceed?.Invoke();
        }
    }
}
