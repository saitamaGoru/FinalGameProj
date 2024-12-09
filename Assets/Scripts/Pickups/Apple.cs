using UnityEngine;

public class Apple : PickupItem
{
    LevelGenerator _levelGen;

    public void Init(LevelGenerator levelGen) 
    {
        _levelGen = levelGen;
    }
    
    
    protected override void OnPickup()
    {
       Debug.Log("Apple Picked up!!");
       if(_levelGen !=null)
        _levelGen.UpdateSpeed(3f);
    }
}
