using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class MenuController : MonoBehaviour
{

    [SerializeField] PlayableDirector timeline;
    [SerializeField] TimelineAsset timelineAsset;


    public void toLevel1()
    {
        timeline.Play();
        StartCoroutine(waitUntilTimelineEnd());

    }

    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    IEnumerator waitUntilTimelineEnd()
    {

        Debug.Log("Timeline started");
        yield return new WaitForSeconds(4);
        Debug.Log("Timeline has ended.");        
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }
}
