using UnityEngine;

public class Apple : PickupItem
{
    LevelGenerator _levelGen;

    [SerializeField] AudioClip _aClip;
   
    [SerializeField] SpeedEventChannel _speedBoostSound;
    public void Init(LevelGenerator levelGen) 
    {
        _levelGen = levelGen;
    }
   
    protected override void OnPickup()
    {
       _speedBoostSound.Invoke(0);
       if(_levelGen !=null)
        _levelGen.UpdateSpeed(3f);
    }
}
