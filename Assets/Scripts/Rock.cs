using UnityEngine;
using Unity.Cinemachine;
public class Rock : MonoBehaviour
{
    [SerializeField] float _shakeMod = 10f;
   CinemachineImpulseSource _cineMchImplseSrce;

   void Awake()
   {
    _cineMchImplseSrce = GetComponent<CinemachineImpulseSource>();
   }

   void OnCollisionEnter(Collision other)
   {
    float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
    float shakeInt = (1f/distance) * _shakeMod;
    shakeInt = Mathf.Min(shakeInt, 1f);
    _cineMchImplseSrce.GenerateImpulse(shakeInt);

   }
}
