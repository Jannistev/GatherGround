using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// class die verantwoordelijk is van het switchen van scenes
/// </summary>
public class ScenesManager : MonoBehaviour
{
    /// <summary>
    /// switcht naar een bepaalde scene
    /// </summary>
    /// <param name="pSceneName"></param>
    public void SwitchScene(string pSceneName)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene(pSceneName);
    }
    /// <summary>
    /// stopt het spel
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
