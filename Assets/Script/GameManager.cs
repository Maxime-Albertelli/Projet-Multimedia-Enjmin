using System;
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
    [SerializeField] GameObject mobSpawners;

    private float _timer = 300.0f;
    private float _timeEllapsed = 0f;
    public EnemySpawning[] listSpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathMenu.enabled = false;
        winMenu.enabled = false;
        listSpawner = mobSpawners.GetComponentsInChildren<EnemySpawning>();
        setSpawnSpeed(7);
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion du temps de jeu restant
        _timer -= Time.deltaTime;
        _timeEllapsed += Time.deltaTime;
        timerLabel.text = $"{_timer / 60:00}:{_timer % 60:00}";
        if(_timer <= 0)
        {
            PauseGame("win");
        }

        print(_timeEllapsed);
        //changement de la rapidité d'apparition des ennemis en fonction du temps passé
        switch ((int) _timeEllapsed)
        {
            case 30:
                setSpawnSpeed(6.5f);
                break;
            case 60:
                setSpawnSpeed(6f);
                break;
            case 120:
                setSpawnSpeed(5.5f);
                break;
            case 180:
                setSpawnSpeed(5f);
                break;
            case 240:
                setSpawnSpeed(4);
                break;
            case 300:
                setSpawnSpeed(3);
                break;
        }
    }

    void setSpawnSpeed(float speed)
    {
        for (int i = 0; listSpawner.Length > i; ++i)
        {
            listSpawner[i].setSpawnSpeed(speed);
            print(listSpawner[i].timeSinceLastSpawn);
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
