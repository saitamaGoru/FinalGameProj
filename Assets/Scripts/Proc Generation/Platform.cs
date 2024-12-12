
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Platform : MonoBehaviour
{

    [Header("References")]
   [SerializeField] GameObject _fencePrefab;
   [SerializeField] GameObject _itemPickup;
   [SerializeField] GameObject _coinPrefab;
   [SerializeField] GameObject _watchPrefab;

    [Header("Platform Values and Settings")]
    [SerializeField] float _itemSpawnChnce = 0.7f;
    [SerializeField] float _coinSpawnChnce = 0.5f;
    [SerializeField] float _watchSpawnChnce = 0.5f;
    [SerializeField] float offSet = 1f;
     [SerializeField] float coindDistanceOffset = 2f;
   [SerializeField] float[] lanes = {-3.5f, 0, 3.5f};

    List<int> lanesAvail = new List<int> {0,1,2};
    LevelGenerator _levelGen;
    GameManager _gameManager;

    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoins();
        SpawnWatch();
    }

    public void Init(LevelGenerator levelGen)
    {
        _levelGen = levelGen;
    }


   void SpawnFence()
   {
        int fenceToSpawn = Random.Range(0,lanes.Length);

        for (int i=0; i<fenceToSpawn; i++)
        {
            //failsafe condition 
            if (lanesAvail.Count <= 0) break;
            int selectedLane = SelectLane();

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(_fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }

    }


    void SpawnApple()
    {
        if (Random.value > _itemSpawnChnce || lanesAvail.Count <= 0) return;
        CreateOffset();

        int selectedLane = SelectLane();

        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Apple apple = Instantiate(_itemPickup, spawnPos, Quaternion.identity, this.transform).GetComponent<Apple>();
        apple.Init(_levelGen);

    }

    void SpawnWatch()
    {
        if (Random.value > _watchSpawnChnce || lanesAvail.Count <= 0) return;
        CreateOffset();

        int selectedLane = SelectLane();

        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y+1, transform.position.z);
        Watch watch = Instantiate(_watchPrefab, spawnPos, Quaternion.identity, this.transform).GetComponent<Watch>();
        watch.Init(_gameManager);
    }
   
    void SpawnCoins()
    {
        if(Random.value > _coinSpawnChnce || lanesAvail.Count <=0) return;

        //create distance between the item spawned
        CreateOffset();

        int selectedLane = SelectLane();

        //spawning coins per platform between 1, 5
        for(int i =0; i<=Random.Range(0,4); i++)
        {
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z + (i + coindDistanceOffset));
            Instantiate(_coinPrefab, spawnPos, Quaternion.identity, this.transform);
        }
       
        
    }

     int SelectLane()
    {
        

        //Randomly select index then lane is selected and passed in Vector3
        int randomLanIndex = Random.Range(0, lanesAvail.Count);
        int selectedLane = lanesAvail[randomLanIndex];
        lanesAvail.Remove(randomLanIndex);
        return selectedLane;
    }

     void CreateOffset()
    {
        Debug.Log($"{_itemPickup.transform.position.z}");
        if (_itemPickup.transform.position.z == _fencePrefab.transform.position.z)
        {
             Debug.Log($"{_itemPickup.transform.position.z}");
           
        }
            
    }

   

}
