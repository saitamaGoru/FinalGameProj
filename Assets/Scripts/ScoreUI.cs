using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

private void OnEnable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScore;
        }

        UpdateScore();
    }

    private void OnDisable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateScore;
        }
    }

    public void UpdateScore()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + ScoreManager.Instance.Score.ToString();
        }
        else
        {
            Debug.LogWarning("Score Text UI element is not assigned.");
        }
    }
}