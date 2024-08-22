using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _onGameStart, _onGamePause, _onGameResume, _onGameEnd;
    private bool isPaused;
    public bool IsPaused
    {
        get => isPaused;
        private set
        {
            isPaused = value;
            if (isPaused)
            {
                Time.timeScale = 0f;
                PauseGame();
            }
            else
            {
                Time.timeScale = 1f;
                ResumeGame();
            }

        }
    }

    public void StartGame()
    {
        _onGameStart?.Invoke();
    }
    private void PauseGame()
    {
        _onGamePause?.Invoke();
    }
    private void ResumeGame()
    {
        _onGameResume?.Invoke();
    }
    public void EndGame()
    {
        _onGameEnd?.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }
    }
}