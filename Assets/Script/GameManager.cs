using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] CharacterMvmt playerInput;
    [SerializeField] TMP_Text timerLabel;
    [SerializeField] Canvas deathMenu;
    [SerializeField] Canvas winMenu;
    [SerializeField] TMP_Text winScoreLabel;

    private float _timeElapsed = 180.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathMenu.enabled = false;
        winMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du temps de jeu restant
        _timeElapsed -= Time.deltaTime;
        timerLabel.text = $"{_timeElapsed / 60:00}:{_timeElapsed % 60:00}";
        if(_timeElapsed <= 0)
        {
            PauseGame("win");
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreLabel.text = score.ToString();
    }

    public void PauseGame(string typeOfPause)
    {
        Time.timeScale = 0;
        playerInput.enabled = false;
        switch (typeOfPause) {
            case "death":
                deathMenu.enabled = true;
                break;
            case "win":
                winMenu.enabled = true;
                winScoreLabel.text = score.ToString() ;
                break;
        }
    }
}
