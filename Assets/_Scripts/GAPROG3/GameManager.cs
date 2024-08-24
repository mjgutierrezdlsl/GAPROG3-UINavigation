using UnityEngine;
using UnityEngine.Events;

namespace GAPROG3.Assets._Scripts.GAPROG3
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onGameStart, _onGamePause, _onGameResume, _onGameEnd;
        public bool IsGameRunning { get; private set; }

        public void StartGame()
        {
            IsGameRunning = true;
            Time.timeScale = 1f;
            _onGameStart?.Invoke();
        }
        public void PauseGame()
        {
            Time.timeScale = 0f;
            _onGamePause?.Invoke();
        }
        public void ResumeGame()
        {
            Time.timeScale = 1f;
            _onGameResume?.Invoke();
        }
        public void EndGame()
        {
            IsGameRunning = false;
            Time.timeScale = 1f;
            _onGameEnd?.Invoke();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                IsGameRunning = !IsGameRunning;
                if (IsGameRunning)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
    }
}