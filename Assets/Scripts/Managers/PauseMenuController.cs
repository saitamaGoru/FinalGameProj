using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseScene");
        Time.timeScale = 1f;

        if (_playerController != null)
        {
            _playerController.enabled = true;
        }
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
