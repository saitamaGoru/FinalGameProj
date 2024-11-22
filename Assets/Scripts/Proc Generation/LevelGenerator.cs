using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Speed))]
public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject _platformPrefab;
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

   // GameObject[] _platforms = new GameObject[12]; //setting 12 size of the array 

    List<GameObject> _platforms = new List<GameObject>();

   


    [SerializeField] CameraController _cameraCont;
    private Speed _speed;
    private float _currSpeed;
   


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
            GameObject platform = Instantiate(_platformPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + (_platformLength * i)),
            quaternion.identity, _platformParent);

            _platforms.Add(platform);

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
                GameObject platformNew = Instantiate(_platformPrefab, 
                new Vector3(transform.position.x, transform.position.y, transform.position.z + (_platformLength *   ((_platforms.Count-1) - i))),
                quaternion.identity,
                 _platformParent);
                
                _platforms.Add(platformNew);
            }
        }
    }

}
