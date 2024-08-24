using UnityEngine;

namespace GAPROG3.Assets._Scripts.GAPROG3
{
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
}