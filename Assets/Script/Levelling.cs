using UnityEngine;

public class Levelling : MonoBehaviour
{
    int level;
    float experience;
    float experienceCap;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = 1;
        experience = 0;
        experienceCap = 10;
    }

    public void gainExperience(int quantity)
    {
        experience += quantity;
        Debug.Log("Exp : " + experience);
    }

    private void Update()
    {
        if (experience >= experienceCap)
        {
            experience = 0;
            experienceCap = experienceCap * 1.5f;
            ++level;
            Debug.Log("Vous êtes passé lvl " + level);
        }
    }

   
}
