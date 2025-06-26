/// <summary>
/// Een interface voor platform behaviour
/// </summary>
public interface IPlatformBehaviour
{
    /// <summary>
    /// functie die een objectfinder meegeeft
    /// </summary>
    /// <param name="pFinder">Component waarmee je alle components van elk object kan vinden</param>
    public void PlatformUpdate(ObjectFinder pFinder);
}
