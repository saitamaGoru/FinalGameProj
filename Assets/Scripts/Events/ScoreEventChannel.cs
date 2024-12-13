using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/ScoreEventChannel")]
public class ScoreEventChannel : ScriptableObject
{
    public UnityAction<int> OnScoreAdded;

    public void RaiseEvent(int amount)
    {
        Debug.Log("Event Raised with Amount: " + amount);
        OnScoreAdded?.Invoke(amount);
    }
}