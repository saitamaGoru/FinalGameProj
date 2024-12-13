using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountCounter : MonoBehaviour
{
    public TMP_Text textCointCounter;

    public int coinHUDCount = 50;

    void Start()
    {
    }


    void Update()
    {
        DisplayCoinCount();
            
            if (coinHUDCount == 0)
        {
            Debug.Log("Load Scene!!");
            LoadNextScene();
        }
        
    }

        void DisplayCoinCount()
    {
        textCointCounter.text = string.Format("{0}", coinHUDCount);
    }

    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

            Debug.Log("Score Before Scene Change: " + ScoreManager.Instance.Score);
            SceneManager.LoadScene(nextSceneIndex);
    }
}

