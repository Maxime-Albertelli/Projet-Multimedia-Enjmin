using UnityEngine;

public class Levelling : MonoBehaviour
{
    int level;
    int experience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        level = 1;
        experience = 0;
    }

    public void gainExperience(int quantity)
    {
        experience += quantity;
        Debug.Log(experience);
    }

    private void gainLevel()
    {

    }
}
