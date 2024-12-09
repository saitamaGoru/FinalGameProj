using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    const string PlayerTag = "Player";

    [SerializeField] float increaseTime = 5f;
    GameManager _gm;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PlayerTag))
        {
            _gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            _gm._runTime += increaseTime;
        }
    }
}
