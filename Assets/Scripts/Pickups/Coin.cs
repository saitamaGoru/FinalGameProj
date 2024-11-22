using UnityEngine;

public class Coin : PickupItem
{
    [SerializeField] private int _score = 10;
    [SerializeField] private ScoreEventChannel _scoreChannel;
    protected override void OnPickup()
    {
        _scoreChannel.Invoke(_score);
      
    }
}
