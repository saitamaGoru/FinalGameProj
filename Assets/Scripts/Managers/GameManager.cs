using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerCont;
    [SerializeField] TMP_Text _score;
    [SerializeField] GameObject _gameOver;

    [SerializeField] float _startTime = 6f;
     public float _runTime {get; set;}
     
    bool _gameIsOver = false;

    public float _newTime;

    public bool GameOver => _gameIsOver;
    void Start()
    {   
        _runTime = _startTime;
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
    }

    private void DecreaseTime()
    {
        if (_gameIsOver) return;
        _runTime -= Time.deltaTime;
        _score.text = _runTime.ToString("F1");

        if (_runTime <= 0f) GameOverScreen();
    }

    public void AddTime(float addTime)
    {
        _newTime = _runTime + addTime;

        if (_newTime != _runTime)
        {
            _runTime = _newTime;
        }
    }

    void GameOverScreen()
    {
        _gameIsOver = true;
        _playerCont.enabled = false;
        _gameOver.SetActive(true);
        Time.timeScale = 0.5f;
    }
}
