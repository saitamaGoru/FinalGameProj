using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator _animatorStumble;
    [SerializeField] float _collCoolDown = 1f;
    [SerializeField] float _changePlatformSpeed = - 2f;
    float timer = 0f;
    const string hitString = "Hit";
    LevelGenerator _levelGen;
    void Start()
    {
        _levelGen = FindFirstObjectByType<LevelGenerator>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
    }
    void OnCollisionEnter(Collision other)
    {
        if(timer < _collCoolDown) return;
        _levelGen.UpdateSpeed(_changePlatformSpeed);
        _animatorStumble.SetTrigger(hitString);
        timer = 0f;
    }
}
