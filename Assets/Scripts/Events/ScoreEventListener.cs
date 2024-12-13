using UnityEngine;

public class ScoreListener : MonoBehaviour
{
    public ScoreEventChannel scoreEventChannel;

    private void OnEnable()
    {
        scoreEventChannel.OnScoreAdded += OnScoreAdded;
    }

    private void OnDisable()
    {
        scoreEventChannel.OnScoreAdded -= OnScoreAdded;
    }

    private void OnScoreAdded(int amount)
    {
        ScoreManager.Instance.IncreaseScore(amount);
    }
}