using UnityEngine;

public class Apple : PickupItem
{
    LevelGenerator _levelGen;

    void Start()
    {
        _levelGen = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
       Debug.Log("Apple Picked up!!");
       _levelGen.UpdateSpeed(3f);
    }
}
