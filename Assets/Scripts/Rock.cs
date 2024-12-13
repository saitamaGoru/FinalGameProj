using UnityEngine;
using Unity.Cinemachine;
public class Rock : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] float _shakeMod = 10f;
    float _maxTimerLimit = 1f;
    float timer = 1f;
     [SerializeField] AudioSource _fxAudio;
   CinemachineImpulseSource _cineMchImplseSrce;

   void Awake()
   {
    _cineMchImplseSrce = GetComponent<CinemachineImpulseSource>();
     _fxAudio = GetComponent<AudioSource>();
    _particleSystem = GetComponentInChildren<ParticleSystem>();
   }


    void Update()
   {
        timer += Time.deltaTime;
   }
   void OnCollisionEnter(Collision other)
    {
        if(timer < _maxTimerLimit) return;
        FireImpulse();
        CollisionFX(other);
        timer = 0;

    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeInt = (1f / distance) * _shakeMod;
        shakeInt = Mathf.Min(shakeInt, 1f);
        _cineMchImplseSrce.GenerateImpulse(shakeInt);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        _particleSystem.transform.position = contactPoint.point;
        _particleSystem.Play();
        _fxAudio.Play();
    }
}
