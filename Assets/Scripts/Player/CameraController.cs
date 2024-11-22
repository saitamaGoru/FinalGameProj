using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSys;
    [SerializeField] float _minFOV = 35f;
    [SerializeField] float _maxFov = 85f;
    [SerializeField] float _endDuration = 1f;
    [SerializeField] float _speedMod = 5f;
    CinemachineCamera _camera;

    void Awake()
    {
        _camera = GetComponent<CinemachineCamera>();
    }
    // Update is called once per frame
   public void ChangeCameraFocusSpeed(float speedAmnt)
   {
        StopAllCoroutines();
        StartCoroutine(ChangeFOV(speedAmnt));
        if(speedAmnt > 0)
        {
            _particleSys.Play();
        }
   }

    IEnumerator ChangeFOV(float speedAmnt)
    {
        float startFOV = _camera.Lens.FieldOfView;
        float targetFov = Mathf.Clamp(startFOV + speedAmnt * _speedMod, _minFOV, _maxFov);

        float elapsedTime = 0f;
        while(elapsedTime < _endDuration)
        {
            float t = elapsedTime / _endDuration;
            elapsedTime += Time.deltaTime;
            _camera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFov, t);
            yield return null;
        }
        _camera.Lens.FieldOfView = targetFov;
    }
}
