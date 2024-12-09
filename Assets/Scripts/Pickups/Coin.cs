using UnityEngine;

public class Coin : PickupItem
{
    [SerializeField] private int _score = 10;
    [SerializeField] private ScoreEventChannel _scoreChannel;
    protected override void OnPickup()
    {
        if(_gm.GameOver) return;
        _scoreChannel.Invoke(_score);
      
    }
}
