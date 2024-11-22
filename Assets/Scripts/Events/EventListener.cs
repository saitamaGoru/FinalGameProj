using UnityEngine;
using UnityEngine.Events;

public abstract class EventListener<T> : MonoBehaviour
{
   [SerializeField] private EventChannel<T> _channel;
   [SerializeField] private UnityEvent<T> _unityEvents;


   protected void Awake()
   {
        _channel.Subscribe(this);
   }

   protected void OnDestroy()
   {
     _channel.UnSubscribe(this);
   }

   public void Raise(T value) =>  _unityEvents?.Invoke(value);
  
}
