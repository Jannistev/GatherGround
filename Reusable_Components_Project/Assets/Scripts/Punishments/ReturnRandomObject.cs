using UnityEngine;

/// <summary>
/// Punishment die ervoor zorgt dat 1 random object van de platform word afgehaald
/// </summary>
public class ReturnRandomObject : MonoBehaviour, IPunishment
{
    [SerializeField] private Platform _platform;
    public void Punish()
    {
        //zoekt naar alle items op die platform
        Item[] items = _platform.ObjectFinder.FindObjects<Item>();

        if (items.Length <= 0)
            return;

        //zoekt een random item uit om terug te sturen naar spawn
        Item randomItem = items[Random.Range(0, items.Length)];

        SpawnPointSetter spawnsetter = randomItem.GetComponent<SpawnPointSetter>();

        spawnsetter.ReturnToSpawn();
    }
}
