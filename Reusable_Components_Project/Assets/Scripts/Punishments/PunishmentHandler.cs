using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// component die elk punishment bijhoudt voor wanneer de speler van de map afvalt
/// </summary>
public class PunishmentHandler : MonoBehaviour
{
    //list met gevonden punishments
    private readonly List<IPunishment> _punishments = new();

    private void Start()
    {
        IPunishment[] punishments = GetComponents<IPunishment>();

        foreach (IPunishment punishment in punishments)
        {          
            _punishments.Add(punishment);
        }
    }
    /// <summary>
    /// voert een random punishment uit
    /// </summary>
    public void ActivateRandomPunishment()
    {
        IPunishment p = _punishments[Random.Range(0, _punishments.Count)];
        p.Punish();
    }
    /// <summary>
    /// voert alle punishments uit
    /// </summary>
    public void ActivateAllPunishments()
    {
        foreach (IPunishment p in _punishments)
        {
            p.Punish();
        }
    }
}
