using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.LogWarning("Quitting game...");
        Application.Quit();
    }
}
