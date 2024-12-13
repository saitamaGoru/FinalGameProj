using UnityEngine;
using TMPro;

public class Coin : PickupItem
{

    const string PlayerTag = "Player";

    [SerializeField] private int _score = 10;
    [SerializeField] private ScoreEventChannel _scoreChannel;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PlayerTag))
        {
            if(_gm.GameOver) return;
           _scoreChannel.Invoke(true);
            ScoreManager.Instance.IncreaseScore(10);
            GameObject.FindGameObjectWithTag("HUD").GetComponent<CountCounter>().coinHUDCount--;
            Destroy(gameObject);
        }
    }
    protected override void OnPickup()
    {
    
    }
}