using UnityEngine;

public class Watch : PickupItem
{
    const string PlayerTag = "Player";

    [SerializeField] float TimeIncrease = 1f;
    GameManager _gameManager;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PlayerTag))
        {
            _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            _gameManager._runTime += TimeIncrease;
            Destroy(gameObject);
        }
    }
    
    
    protected override void OnPickup()
    {
       Debug.Log("Watch Picked up!!");
    }
}
