using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] TMP_Text scoreLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreLabel.text = score.ToString();
    }
}
