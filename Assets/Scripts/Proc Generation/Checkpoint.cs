using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   const string PlayerTag = "Player";

    [SerializeField] float increaseTime = 5f;
    [SerializeField] float blockDecreaseTimeAmnt = 0.2f;
    GameManager _gm;
    BlockSpawner _blockSpwner;

    void Start()
    {
         _gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
         _blockSpwner = FindFirstObjectByType<BlockSpawner>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(PlayerTag))
        {
           
            _gm._runTime += increaseTime;
            _blockSpwner.DecreaseObstacleSpawnTime(blockDecreaseTimeAmnt);
        }
    }
}
