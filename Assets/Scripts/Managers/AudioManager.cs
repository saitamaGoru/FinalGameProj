using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{

    AudioSource _adSOurce;
   
    [SerializeField]AudioClip GameOnMusic, GameOverMusic, CoinClip, AppleClip, Lv2, Lv3, hourGlass;
    [SerializeField] CountCounter _cntCounter;
    [SerializeField] AudioEventChannel _adioChannel;
     void Start()
    {
        _adSOurce = GetComponent<AudioSource>();
        
     
     PlayMusic();
       
    }

    // Update is called once per frame
    public void PlayGameOverMusic()
    {
        _adSOurce.PlayOneShot(GameOverMusic);
    }

    public void StopInGameMusic()
    {
        _adSOurce.Stop();
    }

     public void PlayCoinCollectSound()
    {
         _adSOurce.PlayOneShot(CoinClip);
    }

     public void PlayAppleCollectSound()
    {
         _adSOurce.PlayOneShot(AppleClip);
    }

    public void PlayMusic()
    {
        
         _adioChannel.Invoke(true);
       
    }

    public void MusicForLevel2()
    {
      
         _adSOurce.PlayOneShot(Lv2, 0.15f);
         _adSOurce.loop = true;
    }

    public void MusicForLevel3()
    {
        _adSOurce.PlayOneShot(Lv3, 0.15f);
        _adSOurce.loop = true;
    }
    public void MusicForLevel1()
    {
        _adSOurce.PlayOneShot(GameOnMusic, 0.15f);
    }

    public void PlayWatchPickup()
    {
        _adSOurce.PlayOneShot(hourGlass);
    }
}
