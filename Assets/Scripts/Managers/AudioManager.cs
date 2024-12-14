using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance { get; private set; }
    AudioSource _adSOurce;
   
    [SerializeField]AudioClip GameOnMusic, GameOverMusic, CoinClip, AppleClip, Lv2, Lv3, hourGlass;
    [SerializeField] CountCounter _cntCounter;
    [SerializeField] AudioEventChannel _adioChannel;

     private float musicVolume = 1f;  // Default music volume
    private float sfxVolume = 1f;    // Default sound effect volume


    void Awake()
    {
        // Singleton pattern: Ensure only one instance exists and it persists across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // Destroy duplicate AudioManager
        }
        else
        {
            Instance = this;
          //  DontDestroyOnLoad(gameObject);  // Make sure this instance doesn't get destroyed on scene load
        }
    }

     void Start()
    {
        _adSOurce = GetComponent<AudioSource>();

        // Load saved volumes (from PlayerPrefs if they exist)
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Set initial volume for music and sound effects
        _adSOurce.volume = musicVolume;

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
        AudioSource.PlayClipAtPoint(CoinClip, transform.position, sfxVolume);
    }

     public void PlayAppleCollectSound()
    {
        AudioSource.PlayClipAtPoint(AppleClip, transform.position, sfxVolume);
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

        public void MusicForEndScene()
    {
        _adSOurce.PlayOneShot(GameOverMusic, 0.15f);
        _adSOurce.loop = true;
    }
    public void MusicForLevel1()
    {
        _adSOurce.PlayOneShot(GameOnMusic, 0.15f);
    }
     public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);  // Save volume preference
        _adSOurce.volume = musicVolume;  // Apply the volume to the AudioSource
    }
     public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);  // Save volume preference
    }

    public void PlayWatchPickup()
    {
        _adSOurce.PlayOneShot(hourGlass);
    }
}