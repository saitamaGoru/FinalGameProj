using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score {get; private set; }

    public void IncreaseScore(int score)
    {
        Score += score;
    }
}
