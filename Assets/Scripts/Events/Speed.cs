using UnityEngine;
using UnityEngine.Rendering;

public class Speed : MonoBehaviour
{
   [SerializeField] private float _minSpeed = 9f;
   [SerializeField] private SpeedEventChannel _speedChannel;
   private float _speed;

   void Awake()
   {
     _speed = _minSpeed;
   }

   void PublishSpeedPercentage() => _speedChannel?.Invoke(_speed/_minSpeed);

   public void UpdateSpeed(float value)
   {
        _speed = value;
        PublishSpeedPercentage();
   }
}
