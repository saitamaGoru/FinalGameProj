using UnityEngine;

public class Watch : PickupItem
{
    GameManager _gameManager;

    public void Init(GameManager gameManager) 
    {
        _gameManager = gameManager;
    }
    
    
    protected override void OnPickup()
    {
       Debug.Log("Watch Picked up!!");
      // if(_gameManager !=null)
        //_gameManager.AddTime(0.15f);
    }
}
