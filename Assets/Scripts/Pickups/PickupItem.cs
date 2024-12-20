using UnityEngine;



public abstract class PickupItem : MonoBehaviour
{
    const string PlayerTag = "Player";
    protected GameManager _gm;
    [SerializeField] float rotationSpeed = 100f;

   void Awake()
   {
      _gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
   }
    void Update()
    {
      transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f );
    }
   void OnTriggerEnter(Collider other)
   {
      if(other.CompareTag(PlayerTag))
      {
         OnPickup();
         Destroy(gameObject);
      }
      
   }

   protected abstract void  OnPickup();
}
