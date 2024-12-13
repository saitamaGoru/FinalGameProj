using UnityEngine;
using System;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score {get; private set; }

    public event Action OnScoreChanged;

        protected override void Awake()
    {
        base.Awake();
        Debug.Log("ScoreManager Initialized: " + Score);
        DontDestroyOnLoad(gameObject); // Keep the ScoreManager alive across scenes
    }

    public void IncreaseScore(int score)
    {
        Score += score;
        Debug.Log("Current Score: " + Score);
        OnScoreChanged?.Invoke();
    }
}
