using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerCollisionHandler : MonoBehaviour
{
   [SerializeField] Animator _animatorStumble;
    [SerializeField] AudioClip _adClip;
    [SerializeField] float _collCoolDown = 1f;
    [SerializeField] float _changePlatformSpeed = - 2f;
    float timer = 0f;
    const string hitString = "Hit";
    LevelGenerator _levelGen;
    AudioSource _adSource;

    bool hit;

    void Start()
    {
        _levelGen = FindFirstObjectByType<LevelGenerator>();
        _adSource = GetComponent<AudioSource>();
        hit = false;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if(hit)
        {
            _adSource.PlayOneShot(_adClip);
            hit = false;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(timer < _collCoolDown) return;
        _levelGen.UpdateSpeed(_changePlatformSpeed);
        hit = true;
        _animatorStumble.SetTrigger(hitString);
        timer = 0f;
    }

}
