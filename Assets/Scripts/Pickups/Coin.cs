using UnityEngine;
using TMPro;

public class Coin : PickupItem
{
    [SerializeField] private int _score = 10;
    [SerializeField] private ScoreEventChannel _scoreChannel;

    protected override void OnPickup()
    {
        if(_gm.GameOver) return;
        _scoreChannel.Invoke(_score);
        GameObject.FindGameObjectWithTag("HUD").GetComponent<CountCounter>().coinHUDCount--;
    }
}