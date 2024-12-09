using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    
    public void toLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
