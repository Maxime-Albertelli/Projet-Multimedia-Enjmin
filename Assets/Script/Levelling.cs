using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Levelling : MonoBehaviour
{
    int level;
    float experience;
    float experienceCap;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TMP_Text levelLabel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = 1;
        experience = 0;
        experienceCap = 10;
        xpSlider.maxValue = experienceCap;
        levelLabel.text = level.ToString();
    }

    public void gainExperience(int quantity)
    {
        experience += quantity;
        Debug.Log("Exp : " + experience);
    }

    private void Update()
    {
        xpSlider.value = experience;
        if (experience >= experienceCap)
        {
            experience = 0;
            experienceCap = experienceCap * 1.5f;
            xpSlider.maxValue = experienceCap;
            ++level;
            levelLabel.text = level.ToString();
            Debug.Log("Vous êtes passé lvl " + level);
        }
    }

   
}
