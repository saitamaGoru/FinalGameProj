using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Speed))]
public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject[] _platformPrefab;
    [SerializeField] GameObject _checkpointPrefab;
    [SerializeField] Transform _platformParent;

    [Header("Level Settings")]
    [Tooltip("Platform Length should not  be changed")]
    [SerializeField] float _platformLength = 10f; //size platform is 10 so the space will be equal
    [SerializeField] int _platformPrefabAmount = 12;
    [SerializeField] float _platformMoveSpeed = 9f;
    [SerializeField]  float _minSpeed = 8f;
    [SerializeField] float _maxMoveSpeed = 20f;
     [SerializeField]  float _minGravitySpeed = -22f;
    [SerializeField] float _maxGravitySpeed = -2f;
    [SerializeField] int _countSet = 8;

   // GameObject[] _platforms = new GameObject[12]; //setting 12 size of the array 

    List<GameObject> _platforms = new List<GameObject>();

   [SerializeField]int _platformCount = 0;


    [SerializeField] CameraController _cameraCont;
    private Speed _speed;
    private float _currSpeed;
   GameObject platPref;


    void Awake()
    {
        _speed = GetComponent<Speed>();
        _currSpeed = _platformMoveSpeed;
    }
    void Start()
    {
        
        GeneratePlatforms();

    }


    void Update()
    {
        MovePlatforms();
    }

    void GeneratePlatforms()
    {
        
        for (int i = 0; i < _platformPrefabAmount; i++)
        {
            SpawnPlatform();
            // if(_platformCount > 8) _platformCount = 0;
           
        }
    }

    private void SpawnPlatform()
    {
        ChoosePlatform();
        float posZ = CalculateZPosition();
        Vector3 platformSpawnPos = new Vector3(transform.position.x, transform.position.y, posZ);
        GameObject platform = Instantiate(platPref, platformSpawnPos,Quaternion.identity, _platformParent);
        _platforms.Add(platform);


        Platform newPlatform = platform.GetComponent<Platform>();
        newPlatform.Init(this);
        _platformCount++;
    }

    float CalculateZPosition()
    {
        float spwPosZ; 
        if(_platforms.Count == 0 )spwPosZ = transform.position.z;
        else spwPosZ = _platforms[_platforms.Count - 1].transform.position.z + _platformLength;
        return spwPosZ;
    }
    private void  ChoosePlatform()
    {
        if (_platformCount % _countSet == 0 && _platformCount != 0)
        {
            platPref = _checkpointPrefab;
            // _platformCount = 0;
        }
        else
        {
            platPref = _platformPrefab[Random.Range(0, _platformPrefab.Length)];
        }
    }

    public void UpdateSpeed(float speedAmnt)
    {
        float newMoveSpeed = _platformMoveSpeed + speedAmnt;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, _minSpeed, _maxMoveSpeed);
        
        
        if( newMoveSpeed != _platformMoveSpeed)
        {
            _platformMoveSpeed = newMoveSpeed;
            float newGravityZ = Physics.gravity.z - speedAmnt;
            newGravityZ = Mathf.Clamp(newGravityZ, _minGravitySpeed, _maxGravitySpeed);
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y,newGravityZ);
            _cameraCont.ChangeCameraFocusSpeed(speedAmnt);
        }

       // _speed.UpdateSpeed(_currSpeed);
    }

    void MovePlatforms()
    {
        for (int i = 0; i < _platforms.Count; i++)
        {
            GameObject platform = _platforms[i];
            platform.transform.Translate(-transform.forward * (_platformMoveSpeed * Time.deltaTime));

            if(platform.transform.position.z <= Camera.main.transform.position.z - _platformLength)
            {
                _platforms.Remove(platform);
                Destroy(platform);
               SpawnPlatform();
                
            }
        }
    }

}
