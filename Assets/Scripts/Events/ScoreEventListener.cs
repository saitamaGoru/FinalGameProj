using UnityEngine;

public class ScoreListener : EventListener<bool>
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